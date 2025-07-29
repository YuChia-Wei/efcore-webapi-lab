use SampleDb

go

create table EndTable
(
    EndId   int identity
        constraint EndTable_pk
            primary key nonclustered,
    EndData nvarchar(100)
)
    go

create table SubTable
(
    SubId   int identity
        constraint SubTable_pk
            primary key nonclustered,
    SubData nvarchar(100),
    EndId   int
        constraint SubTable_EndTalbe_EndId_fk
            references EndTable
)
    go

create table DataTreeRoot
(
    MainId        int identity
        constraint DataTreeRoot_pk
            primary key nonclustered,
    MainData      nvarchar(100),
    AmountField   decimal,
    DateTimeField datetime2,
    SubId         int
        constraint DataTreeRoot_SubTable_SubId_fk
            references SubTable
)
    go

create table SubListTable
(
    SubId   int identity
        constraint SubListTable_pk
            primary key nonclustered,
    SubData nvarchar(100),
    MainId  int
        constraint SubListTable_MainTable_MainId_fk
            references DataTreeRoot
)
    go

create table EndListTable
(
    EndId   int identity
        constraint EndListTable_pk
            primary key nonclustered,
    EndData nvarchar(100),
    SubId   int
        constraint EndListTable_SubTable_SubId_fk
            references SubListTable
)
    go
