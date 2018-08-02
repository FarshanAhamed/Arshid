BEGIN;
alter table UserLocations add Latitude numeric(10,6);
alter table UserLocations add Longitude numeric(10,6);
COMMIT;