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

create table DbFirstTable
(
    MainId        int identity
        constraint DbFirstTable_pk
            primary key nonclustered,
    MainData      nvarchar(100),
    AmountField   decimal,
    DateTimeField datetime2,
    SubId         int
        constraint DbFirstTable_SubTable_SubId_fk
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
            references DbFirstTable
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

create table OtherData
(
    OtherId int identity
        constraint OtherData_pk
            primary key,
    Data    nvarchar
)
    go

create unique index OtherData_OtherId_uindex
    on OtherData (OtherId)
    go

create table EditInfo
(
    OldId  int
        constraint EditInfo_OtherData_OtherId_fk_Old
            references OtherData,
    NewId  int
        constraint EditInfo_OtherData_OtherId_fk_New
            references OtherData,
    EditId int identity
        constraint EditInfo_pk
            primary key
)
    go

create unique index EditInfo_EditId_uindex
    on EditInfo (EditId)
    go

