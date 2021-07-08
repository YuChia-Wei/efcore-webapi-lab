create table DbFirstTable
(
	Id int identity
		constraint DbFirstTable_pk
			primary key nonclustered,
	DateTimeField datetime2,
	AmountField decimal,
	StringField nvarchar
)
go

exec sp_addextendedproperty 'MS_Description', '我是 PK', 'SCHEMA', 'DbFirstSample', 'TABLE', 'DbFirstTable', 'COLUMN', 'Id'
go

exec sp_addextendedproperty 'MS_Description', '我是日期欄位', 'SCHEMA', 'DbFirstSample', 'TABLE', 'DbFirstTable', 'COLUMN', 'DateTimeField'
go

exec sp_addextendedproperty 'MS_Description', '我是金額欄位 (金額一定要 decimal)', 'SCHEMA', 'DbFirstSample', 'TABLE', 'DbFirstTable', 'COLUMN', 'AmountField'
go

exec sp_addextendedproperty 'MS_Description', '我是文字欄位', 'SCHEMA', 'DbFirstSample', 'TABLE', 'DbFirstTable', 'COLUMN', 'StringField'
go

