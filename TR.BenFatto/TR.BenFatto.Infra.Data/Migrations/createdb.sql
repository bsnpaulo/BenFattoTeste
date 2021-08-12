﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Category" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" character varying(150) NOT NULL,
    CONSTRAINT "PK_Category" PRIMARY KEY ("Id")
);

CREATE TABLE "Orders" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "OrderNumber" integer NOT NULL,
    CONSTRAINT "PK_Orders" PRIMARY KEY ("Id")
);

CREATE TABLE "UserLogs" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "IpAdress" character varying(15) NOT NULL,
    "DateFromLog" timestamp without time zone NOT NULL,
    "NormalizedDate" text NULL,
    "LogHour" interval NOT NULL,
    "UserAgent" character varying(500) NOT NULL,
    "NormalizedLog" text NULL,
    CONSTRAINT "PK_UserLogs" PRIMARY KEY ("Id")
);

CREATE TABLE "Products" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" character varying(150) NOT NULL,
    "Points" integer NOT NULL,
    "Brand" text NULL,
    "CategoryId" integer NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Products_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Category" ("Id") ON DELETE CASCADE
);

CREATE TABLE "OrderProduct" (
    "OrdersId" integer NOT NULL,
    "ProductsId" integer NOT NULL,
    CONSTRAINT "PK_OrderProduct" PRIMARY KEY ("OrdersId", "ProductsId"),
    CONSTRAINT "FK_OrderProduct_Orders_OrdersId" FOREIGN KEY ("OrdersId") REFERENCES "Orders" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_OrderProduct_Products_ProductsId" FOREIGN KEY ("ProductsId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

INSERT INTO "Category" ("Id", "Name")
VALUES (1, 'Recicláveis');
INSERT INTO "Category" ("Id", "Name")
VALUES (2, 'Eletrônicos');

CREATE INDEX "IX_OrderProduct_ProductsId" ON "OrderProduct" ("ProductsId");

CREATE INDEX "IX_Products_CategoryId" ON "Products" ("CategoryId");

CREATE INDEX "IX_UserLogs_IpAdress" ON "UserLogs" ("IpAdress");

CREATE INDEX "IX_UserLogs_LogHour" ON "UserLogs" ("LogHour");

CREATE INDEX "IX_UserLogs_UserAgent" ON "UserLogs" ("UserAgent");

SELECT setval(
    pg_get_serial_sequence('"Category"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "Category") + 1,
        nextval(pg_get_serial_sequence('"Category"', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210812004601_initial', '5.0.7');

COMMIT;
