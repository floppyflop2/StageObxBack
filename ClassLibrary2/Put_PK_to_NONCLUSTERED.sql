SET NOCOUNT ON

PRINT '*** START OF SCRIPT ***'
PRINT ''
PRINT 'Server Name :  ' + @@SERVERNAME
PRINT 'Database Name :' + DB_NAME()
PRINT ''
PRINT '*** DISABLE CONSTRAINTS ON ALL TABLES *** '
PRINT ''

EXEC sp_MSforeachtable @command1='PRINT '' => ALTER TABLE ? NOCHECK CONSTRAINT ALL''' , @command2='ALTER TABLE ? NOCHECK CONSTRAINT ALL'

DECLARE @primarykeys 
	TABLE 
		(
			PrimaryKey varchar(100), 
			ColumnName varchar(100), 
			TableName varchar(100),
			SchemaName varchar(100),
			ObjectID INT
		);
DECLARE @foreignkeys 
	TABLE 
		(
			ForeignKey varchar(100), 
			ColumnName varchar(100), 
			ReferenceColumnName varchar(100),
			TableName varchar(100),
			ReferenceTableName varchar(100),
			SchemaName varchar(100)
		);

INSERT INTO @primarykeys
SELECT  DISTINCT k.name, 
				 null, 
				 t.name, 
				 s.name,
				 k.parent_object_id
FROM    sys.key_constraints k
INNER JOIN sys.tables t on t.object_id = k.parent_object_id
INNER JOIN sys.schemas s on s.schema_id = t.schema_id
WHERE k.type = 'PK';


DECLARE	@objectID INT , @ColumnName NVARCHAR(255);
DECLARE columnsCursor CURSOR FOR 
	SELECT  [objectID] = ic.object_id , 
			[ColumnName] = c.name
	FROM    sys.index_columns ic
	INNER JOiN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
	INNER JOIN sys.columns c ON c.object_id = ic.object_id AND ic.column_id = c.column_id
	INNER JOIN sys.key_constraints k ON k.parent_object_id = c.object_id AND i.index_id = k.unique_index_id
	WHERE k.type = 'PK';

OPEN columnsCursor;

FETCH NEXT FROM columnsCursor INTO @objectID ,@ColumnName;

WHILE @@FETCH_STATUS <> -1
BEGIN
	
	DECLARE @ColName NVARCHAR(255)
	
	SELECT @ColName = ISNULL(ColumnName , '')
	FROM @primarykeys
	WHERE ObjectID = @objectID
	
	
	IF(@ColName = '')
	BEGIN
		SET @ColName = '[' + @ColumnName + ']'
	END
	ELSE
	BEGIN
		SET @ColName = @ColName + ',[' + @ColumnName + ']'
	END
	
	UPDATE @primarykeys
	SET ColumnName = @ColName
	WHERE ObjectID = @objectID
	
	FETCH NEXT FROM columnsCursor INTO @objectID ,@ColumnName;
END

CLOSE columnsCursor;
DEALLOCATE columnsCursor;

INSERT INTO @foreignkeys
SELECT DISTINCT k.name AS 'ForeignKey', 
				c1.name as 'ColumnName', c2.name AS 'ReferenceColumnName', 
				t1.name as 'TableName', t2.name AS 'ReferenceTableName',
				s.name as 'SchemaName'
FROM    sys.foreign_keys k
INNER JOIN sys.foreign_key_columns k2 ON k.object_id = k2.constraint_object_id
INNER JOIN sys.columns c1 ON c1.object_id = k2.parent_object_id and c1.column_id = k2.parent_column_id
INNER JOIN sys.columns c2 ON c2.object_id = k2.referenced_object_id and c2.column_id = k2.referenced_column_id
INNER JOIN sys.tables t1 ON t1.object_id = k.parent_object_id
INNER JOIN sys.tables t2 ON t2.object_id = k.referenced_object_id
INNER JOIN sys.schemas s on s.schema_id = t1.schema_id

DECLARE @sqlPK NVARCHAR(2000)
DECLARE @sqlDropFK NVARCHAR(2000)
DECLARE @sqlCreateFK NVARCHAR(2000)

PRINT ''
PRINT '*** REMOVE FOREIGN KEY CONSTRAINTS ON ALL TABLES *** '
PRINT ''

DECLARE fkDropCursor CURSOR FOR
SELECT	ForeignKey , ColumnName, ReferenceColumnName, TableName, ReferenceTableName, SchemaName
FROM	@foreignkeys

OPEN	fkDropCursor

DECLARE @FKDROP VARCHAR(100), @COLDROP VARCHAR(100), @REFCOLDROP VARCHAR(100), @TBLDROP VARCHAR(100), @REFTBLDROP VARCHAR(100), @SCHEMA VARCHAR(100)

FETCH NEXT FROM fkDropCursor INTO @FKDROP, @COLDROP, @REFCOLDROP, @TBLDROP, @REFTBLDROP, @SCHEMA

WHILE(@@FETCH_STATUS <> -1)
BEGIN
	SET @sqlDropFK = 'ALTER TABLE [' + @SCHEMA +'].[' + @TBLDROP + '] DROP CONSTRAINT [' + @FKDROP + ']'
	SET @sqlDropFK += ' '
	
	exec sp_executesql @sqlDropFK
	PRINT ' => ' + @sqlDropFK
	
	FETCH NEXT FROM fkDropCursor INTO @FKDROP, @COLDROP, @REFCOLDROP, @TBLDROP, @REFTBLDROP, @SCHEMA
	
END

CLOSE	fkDropCursor
DEALLOCATE fkDropCursor

PRINT ''
PRINT '*** RECREATE PRIMARY KEYS (NONCLUSTERED) ON ALL TABLES *** '
PRINT ''

DECLARE pkCursor CURSOR FOR
SELECT	PrimaryKey , ColumnName , TableName, SchemaName
FROM	@primarykeys

OPEN	pkCursor

DECLARE @PK VARCHAR(100), @COL VARCHAR(100), @Tbl VARCHAR(100), @SCHPK VARCHAR(100)

FETCH NEXT FROM pkCursor INTO @PK, @COL, @Tbl,@SCHPK

WHILE(@@FETCH_STATUS <> -1)
BEGIN
	SET @sqlPK = 'ALTER TABLE [' + @SCHPK +'].[' + @Tbl + '] DROP CONSTRAINT [' + @PK + ']'
	SET @sqlPK += ' '
	SET @sqlPK += 'ALTER TABLE [' + @SCHPK +'].[' + @Tbl + '] ADD CONSTRAINT [' + @PK + '] PRIMARY KEY NONCLUSTERED ( ' +  @COL + ')'
	SET @sqlPK += ' WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]'
	SET @sqlPK += ' '
	
	exec sp_executesql @sqlPK
	PRINT ' => ' + @sqlPK
	
	FETCH NEXT FROM pkCursor INTO @PK, @COL, @Tbl, @SCHPK
	
END

CLOSE	pkCursor
DEALLOCATE pkCursor

PRINT ''
PRINT '*** RECREATE FOREIGN KEY CONSTRAINTS ON ALL TABLES *** '
PRINT ''

DECLARE fkCreateCursor CURSOR FOR
SELECT	ForeignKey , ColumnName, ReferenceColumnName, TableName, ReferenceTableName, SchemaName
FROM	@foreignkeys

OPEN	fkCreateCursor

DECLARE @FKCREATE VARCHAR(100), @COLCREATE VARCHAR(100), @REFCOLCREATE VARCHAR(100), @TBLCREATE VARCHAR(100), @REFTBLCREATE VARCHAR(100), @SCHEMAFK VARCHAR(100)

FETCH NEXT FROM fkCreateCursor INTO @FKCREATE, @COLCREATE, @REFCOLCREATE, @TBLCREATE, @REFTBLCREATE, @SCHEMAFK

WHILE(@@FETCH_STATUS <> -1)
BEGIN
	SET @sqlCreateFK = 'ALTER TABLE [' + @SCHEMAFK +'].[' + @TBLCREATE + '] WITH NOCHECK ADD CONSTRAINT [' + @FKCREATE + ']'
	SET @sqlCreateFK += ' FOREIGN KEY ([' + @COLCREATE+ '])'
	SET @sqlCreateFK += ' REFERENCES [' + @SCHEMAFK +'].[' + @REFTBLCREATE+ '](['+ @REFCOLCREATE +']) '
	
	exec sp_executesql @sqlCreateFK
	PRINT ' => ' + @sqlCreateFK
	FETCH NEXT FROM fkCreateCursor INTO @FKCREATE, @COLCREATE, @REFCOLCREATE, @TBLCREATE, @REFTBLCREATE, @SCHEMAFK
	
END

CLOSE	fkCreateCursor
DEALLOCATE fkCreateCursor

PRINT ''
PRINT '*** ENABLE CONSTRAINTS ON ALL TABLES *** '
PRINT ''

EXEC sp_MSforeachtable @command1='PRINT '' => ALTER TABLE ? CHECK CONSTRAINT ALL'''  , @command2='ALTER TABLE ? CHECK CONSTRAINT ALL'


PRINT ''
PRINT '*** SUCCESS ! *** '
PRINT '*** END OF SCRIPT *** '
PRINT ''
