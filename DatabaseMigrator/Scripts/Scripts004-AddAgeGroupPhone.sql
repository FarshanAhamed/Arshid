BEGIN;
alter table GlobalUsers add Age varchar(64);
alter table Groups add GroupContact varchar(256);
COMMIT;