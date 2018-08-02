BEGIN;
alter table GlobalUsers add Gender varchar(256);
alter table GlobalUsers add ContactNumber varchar(256);
COMMIT;