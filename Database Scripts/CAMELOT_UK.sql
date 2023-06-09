if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_BANKDETAILS_ADRESSES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[BANK_DETAILS] DROP CONSTRAINT FK_BANKDETAILS_ADRESSES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_COMPANY_ADDRESS_ADRESSES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[COMPANY_ADDRESS] DROP CONSTRAINT FK_COMPANY_ADDRESS_ADRESSES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CONTACT_ADDRESS_ADRESSES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CONTACT_ADDRESS] DROP CONSTRAINT FK_CONTACT_ADDRESS_ADRESSES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DEPARTMENT_MODULES_APPLICATION_MODULES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DEPARTMENT_MODULES] DROP CONSTRAINT FK_DEPARTMENT_MODULES_APPLICATION_MODULES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_COMPANY_BANK_BANKDETAILS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[COMPANY_BANK] DROP CONSTRAINT FK_COMPANY_BANK_BANKDETAILS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_RESIDENT_BANK_BANKDETAILS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[RESIDENT_BANK] DROP CONSTRAINT FK_RESIDENT_BANK_BANKDETAILS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_COMPANY_PAYMENTS_INVOICES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[COMPANY_INVOICES] DROP CONSTRAINT FK_COMPANY_PAYMENTS_INVOICES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_RESIDENTINVOICE_INVOICES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[RESIDENTINVOICE] DROP CONSTRAINT FK_RESIDENTINVOICE_INVOICES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_COMPANY_OBJECT_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[COMPANY_OBJECT] DROP CONSTRAINT FK_COMPANY_OBJECT_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_CHECKS_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_CHECKS] DROP CONSTRAINT FK_OBJECT_CHECKS_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_FACILITIES_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_FACILITIES] DROP CONSTRAINT FK_OBJECT_FACILITIES_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_PICTURES_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_PICTURES] DROP CONSTRAINT FK_OBJECT_PICTURES_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_ROUTE_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_ROUTE] DROP CONSTRAINT FK_OBJECT_ROUTE_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_RESIDENT_OBJECT_OBJECTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[RESIDENT_OBJECT] DROP CONSTRAINT FK_RESIDENT_OBJECT_OBJECTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_CHECK_METERS_OBJECT_METER]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_CHECK_METERS] DROP CONSTRAINT FK_OBJECT_CHECK_METERS_OBJECT_METER
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_COMPANYPAYMENTS_PAYMENTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[COMPANYPAYMENTS] DROP CONSTRAINT FK_COMPANYPAYMENTS_PAYMENTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_RESIDENTPAYMENTS_PAYMENTS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[RESIDENTPAYMENTS] DROP CONSTRAINT FK_RESIDENTPAYMENTS_PAYMENTS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PAYMENTS_PAYMENTYPES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PAYMENTS] DROP CONSTRAINT FK_PAYMENTS_PAYMENTYPES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_RESIDENT_PROFILE_PROFILE_ATTRIBUTES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[RESIDENT_PROFILE] DROP CONSTRAINT FK_RESIDENT_PROFILE_PROFILE_ATTRIBUTES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OBJECT_ROUTE_ROUTES]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OBJECT_ROUTE] DROP CONSTRAINT FK_OBJECT_ROUTE_ROUTES
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VALIDATE_EMAIL]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[VALIDATE_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_COMPANY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_CONCOMP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_CONCOMP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_INSPECTION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_INSPECTION]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_MERGE_FIELD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_MERGE_FIELD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_METER_RATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_METER_RATE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_OBJCONT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_OBJCONT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_PHOTO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_PHOTO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_PROPERTY_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_PROPERTY_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADD_VET_SCAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ADD_VET_SCAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Auth_User]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Auth_User]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CGET_CORRESPONDENCE_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CGET_CORRESPONDENCE_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CGET_RECIPIENT_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CGET_RECIPIENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CHANGE_OWNER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CHANGE_OWNER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CHANGE_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CHANGE_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CHECK_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CHECK_COMPANY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CHECK_COMP_CONT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CHECK_COMP_CONT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CHECK_CONT_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CHECK_CONT_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_COMMENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_COMMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_DOCUMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_DOCUMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_INVOICE_ITEMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_INVOICE_ITEMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_MERGE_FIELDS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_MERGE_FIELDS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_METER_RATES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_METER_RATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_METER_READING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_METER_READING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_PHOTO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_PHOTO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_READING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_READING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_ROUTE_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_ROUTE_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DELETE_VET_SCAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DELETE_VET_SCAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEL_COMP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DEL_COMP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEL_CONCOMP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DEL_CONCOMP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEL_CONT_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DEL_CONT_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEL_OBJCONT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DEL_OBJCONT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FIND_COMPANIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FIND_COMPANIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FIND_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FIND_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ACCOUNT_MANAGERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ACCOUNT_MANAGERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ACTION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ACTION]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ACTIONS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ACTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ACTIVE_ROUTES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ACTIVE_ROUTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ALL_OPEN_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ALL_OPEN_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ALL_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ALL_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ALL_RESOLVED_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ALL_RESOLVED_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_AREAS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_AREAS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ATTACH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ATTACH]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_BINSPECTION_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_BINSPECTION_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CALLBACK_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CALLBACK_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_BANK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_CONTACTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_CONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_CONTACTS_COMPLAINTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_CONTACTS_COMPLAINTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_CONTACTS_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_CONTACTS_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_NOTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_NOTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_NOTES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_NOTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPANY_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPANY_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPLAINT_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPLAINT_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPLAINT_EMPLOYEE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPLAINT_EMPLOYEE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPLAINT_GUARDIAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPLAINT_GUARDIAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMPLAINT_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMPLAINT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMP_CORR_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMP_CORR_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMP_STATS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMP_STATS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_COMP_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_COMP_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONTACT_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONTACT_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONTACT_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONTACT_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONTTYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONTTYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONT_CORR_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONT_CORR_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CONT_STATS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CONT_STATS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CORR_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CORR_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_CURRENT_PROPERTY_RESIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_CURRENT_PROPERTY_RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_DEFAULT_PRINTER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_DEFAULT_PRINTER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_DEF_PHOTOS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_DEF_PHOTOS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_DOCUMENT_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_DOCUMENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ECALLBACK_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ECALLBACK_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ECORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ECORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMAIL_COMPANIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMAIL_COMPANIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMAIL_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMAIL_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMAIL_GUARD_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMAIL_GUARD_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMAIL_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMAIL_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMAIL_RESIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMAIL_RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_EMPLOYEES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_EMPLOYEES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_FACILITIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_FACILITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_FACILITY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_FACILITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_FACILITY_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_FACILITY_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARDIAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARDIAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARDIAN_BANK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARDIAN_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARDIAN_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARDIAN_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARDIAN_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARDIAN_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARDIAN_VET]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARDIAN_VET]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARD_CORR_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARD_CORR_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARD_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARD_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_GUARD_STATS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_GUARD_STATS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INCIDENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INCIDENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INCIDENT_ACTIONS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INCIDENT_ACTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INCIDENT_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INCIDENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INCIDENT_URGENCIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INCIDENT_URGENCIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INC_SRCS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INC_SRCS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INC_STATS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INC_STATS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTIONS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION_COMMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION_COMMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION_COMMENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION_COMMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION_METERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSPECTION_REPORT_METERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSPECTION_REPORT_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_FACILITIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_FACILITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_GUARDIANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_GUARDIANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_METERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_METER_READINGS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_METER_READINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_NOTES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_NOTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_OPEN_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_OPEN_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_PROP_NL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_PROP_NL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_GUARDIANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_GUARDIANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_GUARDIANS_NL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_GUARDIANS_NL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_INCIDENTS_NL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_INCIDENTS_NL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_RES_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_RES_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_REPORT_RES_INCIDENTS_NL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_REPORT_RES_INCIDENTS_NL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INSP_SECURITIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INSP_SECURITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INVOICE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INVOICE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INVOICE_ITEMS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INVOICE_ITEMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_INVOICE_PERIODS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_INVOICE_PERIODS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_JOBTITLES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_JOBTITLES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_LAST_INSP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_LAST_INSP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MAINTAINERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MAINTAINERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_CONTACTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_CONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_DOCUMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_DOCUMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_FIELDS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_FIELDS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_GUARD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_GUARD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_MERGE_GUARDS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_MERGE_GUARDS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_METER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_METER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_METERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_METER_RATES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_METER_RATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_METER_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_METER_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_NEW_INSPECTION_METERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_NEW_INSPECTION_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_NON_METER_RATES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_NON_METER_RATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OBJECT_STATS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OBJECT_STATS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OBJECT_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OBJECT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OLD_PICTURES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OLD_PICTURES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OPEN_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OPEN_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OTHER_ADDRESS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OTHER_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_OUT_COMPANY_INVOICES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_OUT_COMPANY_INVOICES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PAID_COMPANY_INVOICES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PAID_COMPANY_INVOICES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PCONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PCONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PENDING_PROPERTY_RESIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PENDING_PROPERTY_RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PHOTO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PHOTO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PHOTOS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PHOTOS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PLACEMENT_PROPS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PLACEMENT_PROPS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PREVIOUS_PROPERTY_RESIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PREVIOUS_PROPERTY_RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_COMPANY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_COMPANY_CONTACTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_COMPANY_CONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_CONTACTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_CONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_CONTACTS_corr]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_CONTACTS_corr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_CORR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_CORR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_GUARDIANS_COMPLAINTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_GUARDIANS_COMPLAINTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROPERTY_NOTES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROPERTY_NOTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROP_CORR_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROP_CORR_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_PROP_RESIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_PROP_RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_READING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_READING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_READINGS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_READINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_REPORTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_REPORTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_RESOLVED_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_RESOLVED_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ROUTES_ACTIVE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ROUTES_ACTIVE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ROUTES_OLD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ROUTES_OLD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ROUTE_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ROUTE_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_ROUTE_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_ROUTE_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_RPT_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_RPT_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SCONTACTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SCONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SEARCH_GUARDIANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SEARCH_GUARDIANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SEARCH_OLD_GUARDIANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SEARCH_OLD_GUARDIANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SECURITIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SECURITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SECURITY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SECURITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SECURITY_TYPES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SECURITY_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_STATUS_HIST]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_STATUS_HIST]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_STATUS_HIST_CONT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_STATUS_HIST_CONT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_SUPPLIERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_SUPPLIERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_TITLES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_TITLES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_UNSENT_INSPECTIONS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_UNSENT_INSPECTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_USER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_USER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_VET_SCAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_VET_SCAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_VET_SCANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_VET_SCANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GET_VISIT_ADDRESS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GET_VISIT_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CORRESPONDENCE_DOCUMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_CORRESPONDENCE_DOCUMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CORRESPONDENCE_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_CORRESPONDENCE_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CORR_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_CORR_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CORR_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_CORR_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_DOCUMENT_RECIPIENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_DOCUMENT_RECIPIENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_EMAIL_DOCUMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_EMAIL_DOCUMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_EMAIL_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_EMAIL_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_EMAIL_RECIPIENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_EMAIL_RECIPIENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_INSP_COMMENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_INSP_COMMENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_INVOICE_ITEM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_INVOICE_ITEM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_METER_RATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_METER_RATE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_METER_READINGS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_METER_READINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_NEW_EMAIL_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_NEW_EMAIL_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_RECEIVED_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_RECEIVED_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_RECEIVED_CORR_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_RECEIVED_CORR_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_ROUTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_ROUTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_ROUTE_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSERT_ROUTE_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSP_REP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSP_REP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSP_REP_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSP_REP_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSP_REP_NL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[INSP_REP_NL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[REM_OBJCONT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[REM_OBJCONT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_ALL_OPEN_INCIDENTS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_ALL_OPEN_INCIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_ALL_OPEN_INCIDENTS_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_ALL_OPEN_INCIDENTS_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_ALL_VETTING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_ALL_VETTING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_ALL_VETTING_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_ALL_VETTING_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_CALAMITY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_CALAMITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_COLS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_COLS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_EMPTY_SPACES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_EMPTY_SPACES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_EMPTY_SPACES_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_EMPTY_SPACES_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_FACILITIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_FACILITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_GUARDIANS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_GUARDIANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_HDRS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_HDRS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_NO_VETTING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_NO_VETTING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_NO_VETTING_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_NO_VETTING_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_OWNERS_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_OWNERS_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_PROPERTIES]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_PROPERTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_PROPS_BY_STATUS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_PROPS_BY_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_PROPS_BY_STATUS_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_PROPS_BY_STATUS_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_PROSPECT_STATUS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_PROSPECT_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_PROSPECT_STATUS_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_PROSPECT_STATUS_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_VETTING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_VETTING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RPT_VETTING_DETAILS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RPT_VETTING_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SAVE_SECOND_ADDRESS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SAVE_SECOND_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SAVE_VISIT_ADDRESS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SAVE_VISIT_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SET_DEF_PHOTO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SET_DEF_PHOTO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SET_REP_SENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SET_REP_SENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_ADDADDRESS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_ADDADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_ACTION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_ACTION]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_COMPANY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_COMPANY_BANK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_COMPANY_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_COMPANY_NOTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_COMPANY_NOTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_CONTACT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_FACILITY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_FACILITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_GUARDIAN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_GUARDIAN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_GUARDIAN_BANK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_GUARDIAN_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_INCIDENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_INCIDENT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_INSPECTION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_INSPECTION]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_INVOICE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_INVOICE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_MERGE_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_MERGE_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_MERGE_DOC_DOC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_MERGE_DOC_DOC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_METER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_METER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_METERREADING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_METERREADING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_METER_READINGS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_METER_READINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_PROPERTY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_PROPERTY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_PROPERTY_NOTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_PROPERTY_NOTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_ROUTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_ROUTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_ROUTE_DATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_ROUTE_DATE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_SECURITY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_SECURITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_VETTING]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UPDATE_VETTING]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VALID_CONT_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[VALID_CONT_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VALID_GUARD_EMAIL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[VALID_GUARD_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WLSP_CreateCheckListRoute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WLSP_CreateCheckListRoute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WLSP_CreateNewTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WLSP_CreateNewTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WLSP_DropTheTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WLSP_DropTheTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WLSP_LastMonthsComments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WLSP_LastMonthsComments]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WLSP_MonthlyPropertyManagementReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WLSP_MonthlyPropertyManagementReport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACCOUNT_MANAGERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ACCOUNT_MANAGERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADDRESSES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ADDRESSES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ADDRESS_TYPE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ADDRESS_TYPE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[APPLICATION_MODULES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APPLICATION_MODULES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[APPLICATION_OPTIONS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APPLICATION_OPTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[APP_DEFS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APP_DEFS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AREA]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AREA]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ATTRIBUTE_VALUES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ATTRIBUTE_VALUES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BANK_DETAILS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BANK_DETAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANYPAYMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANYPAYMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_ADDRESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_BANK]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_CONTACT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_INVOICES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_INVOICES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_OBJECT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_OBJECT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_PAYMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_PAYMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_STATUS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPANY_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPANY_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_ACTIONS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_ACTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_HISTORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_HISTORY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_SOURCES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_SOURCES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_SOURCE_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_SOURCE_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_STATUS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COMPLAINT_URGENCY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COMPLAINT_URGENCY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_ADDRESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_CONTACTTYPE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_CONTACTTYPE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_HISTORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_HISTORY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_SALES_ACTIVITY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_SALES_ACTIVITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_STATUS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_STATUS_HISTORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_STATUS_HISTORY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTACT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTACT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CONTROL_CHECK_PICTURES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CONTROL_CHECK_PICTURES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CORRESPONDENCE_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CORRESPONDENCE_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CORRESPONDENCE_EMAIL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CORRESPONDENCE_EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CORRESPONDENCE_SCANS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CORRESPONDENCE_SCANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CORRESPONDENCE_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CORRESPONDENCE_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COUNTIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COUNTIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[COUNTRIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[COUNTRIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DATABASES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DATABASES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEPARTMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DEPARTMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DEPARTMENT_MODULES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DEPARTMENT_MODULES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DOCUMENT_COMMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DOCUMENT_COMMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DOCUMENT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DOCUMENT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DOCUMENT_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DOCUMENT_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DOCUMENT_TEMPLATES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DOCUMENT_TEMPLATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DOCUMENT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DOCUMENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ED]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ED]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAILS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAILS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_ADDRESSES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_ADDRESSES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_ATTACHMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_ATTACHMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_CONTACT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_CONTACT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_RECIPIENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_RECIPIENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMAIL_RECIPIENTS_NO_CRM]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMAIL_RECIPIENTS_NO_CRM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EMPLOYEES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EMPLOYEES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FACILITIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FACILITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FACILITY_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FACILITY_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FILTERTABEL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FILTERTABEL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FMT_COL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FMT_COL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FMT_HDR]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FMT_HDR]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FORM_TEMPLATE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FORM_TEMPLATE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GENDER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GENDER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSPECTION_COMMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INSPECTION_COMMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INTERNET_FORM]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INTERNET_FORM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INVOICES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INVOICES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INVOICE_ITEMS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INVOICE_ITEMS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INVOICE_PERIOD]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INVOICE_PERIOD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ISS_CheckList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ISS_CheckList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JOB_TITLES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[JOB_TITLES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LANGUAGES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LANGUAGES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MAILINGS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MAILINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MAINTAINERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MAINTAINERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MERGEFIELDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MERGEFIELDS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MERGE_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MERGE_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MERGE_FIELDS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MERGE_FIELDS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[METERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[METER_RATES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[METER_RATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[METER_READINGS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[METER_READINGS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[METER_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[METER_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NOTES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NOTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_CHECKS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_CHECKS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_CHECK_METERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_CHECK_METERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_COMPLAINTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_COMPLAINTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_CONTACT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_CONTACT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_CONTACT_TYPE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_CONTACT_TYPE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_FACILITIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_FACILITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_INQUIRIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_INQUIRIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_METER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_METER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_PICTURES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_PICTURES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_ROUTE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_ROUTE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_SECURITIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_SECURITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_STATUS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_STATUS_HISTORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_STATUS_HISTORY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OBJECT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OBJECT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PAYMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PAYMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PAYMENTYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PAYMENTYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PHOTOS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PHOTOS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PHOTO_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PHOTO_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PROFILE_ATTRIBUTES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PROFILE_ATTRIBUTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PROJECTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PROJECTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RATES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RATES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RECIPIENT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RECIPIENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[REMINDERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[REMINDERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[REPORTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[REPORTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENTINVOICE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENTINVOICE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENTPAYMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENTPAYMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENTS_FILTER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENTS_FILTER]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_ADDRESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_ADDRESS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_BANK]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_BANK]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_CORRESPONDENCE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_CORRESPONDENCE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_OBJECT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_OBJECT]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_PROFILE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_PROFILE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_STATUS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_STATUS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RESIDENT_TYPE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RESIDENT_TYPE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ROUTES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ROUTE_INSPECTIONS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ROUTE_INSPECTIONS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_ACTIVITY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SALES_ACTIVITY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SCAN_DOCUMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SCAN_DOCUMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SCAN_DOCUMENT_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SCAN_DOCUMENT_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SECURITIES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SECURITIES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SECURITY_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SECURITY_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SELECTED_INSP_COMMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SELECTED_INSP_COMMENTS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[T Vetting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[T Vetting]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TAAL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TAAL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TITLES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TITLES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Table1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Table1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USER_TYPES]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[USER_TYPES]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UTILITY_SUPPLIERS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[UTILITY_SUPPLIERS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VET_SCANS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[VET_SCANS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[results]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[results]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE FUNCTION VALIDATE_EMAIL
(
	@EMAIL VARCHAR(250)
)
RETURNS INT
AS  
BEGIN

DECLARE @VALID INT

SELECT @VALID = 1
WHERE
(
	CHARINDEX(' ',LTRIM(RTRIM(@EMAIL))) = 0 
AND  	LEFT(LTRIM(@EMAIL),1) <> '@' 
AND  	RIGHT(RTRIM(@EMAIL),1) <> '.' 
AND  	CHARINDEX('.',@EMAIL,CHARINDEX('@',@EMAIL)) - CHARINDEX('@',@EMAIL) > 1 
AND  	LEN(LTRIM(RTRIM(@EMAIL))) - LEN(REPLACE(LTRIM(RTRIM(@EMAIL)),'@','')) = 1 
AND  	CHARINDEX('.',REVERSE(LTRIM(RTRIM(@EMAIL)))) >= 3 
AND  	(CHARINDEX('.@',@EMAIL) = 0 AND CHARINDEX('..',@EMAIL) = 0) 
) 

RETURN @VALID

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[ACCOUNT_MANAGERS] (
	[EMPLOYEE_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ADDRESSES] (
	[ADDRESS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[HOUSENAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HOUSENUMBER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STREETNAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS4] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS5] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POSTALCODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CITY] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTY] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AREA_ID] [int] NULL ,
	[COUNTRY] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ADDRESS_TYPE] (
	[ADDRESS_TYPE] [int] IDENTITY (1, 1) NOT NULL ,
	[ADDRESS_TYPE_CODE] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APPLICATION_MODULES] (
	[MODULE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[MODULE_CODE] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MODULE_DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APPLICATION_OPTIONS] (
	[APP_OPTION] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[OPTION_VALUE] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APP_DEFS] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[KEY_NAME] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL ,
	[KEY_VALUE] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AREA] (
	[AREA_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ATTRIBUTE_VALUES] (
	[ATTRIBUTE_ID] [int] NOT NULL ,
	[POSSIBLE_VALUE] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LANGUAGE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PROFILE_CODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BANK_DETAILS] (
	[BANKDETAIL_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[SORTCODE] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ACCOUNTNUMBER] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ACCOUNTNAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ADDRESS_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANIES] (
	[COMPANY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COMPANY_NAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DEBITEURNR] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SEARCH_CODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENERAL_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENERAL_FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENERAL_EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENERAL_WEBSITE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COMPANY_TYPE] [int] NULL ,
	[STATUS_ID] [int] NULL ,
	[STATUS_EFFECTIVE] [smalldatetime] NULL ,
	[ACCOUNT_MANAGER] [int] NOT NULL ,
	[SALES_MANAGER] [int] NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL ,
	[ESTABLISHMENT] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MODIFIER] [int] NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANYPAYMENTS] (
	[PAYMENTID] [int] NOT NULL ,
	[COMPANYID] [int] NOT NULL ,
	[INVOICEID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_ADDRESS] (
	[COMPANY_ID] [int] NOT NULL ,
	[ADDRESS_ID] [int] NOT NULL ,
	[ADDRESS_TYPE] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_BANK] (
	[COMPANY_ID] [int] NOT NULL ,
	[BANKDETAIL_ID] [int] NOT NULL ,
	[DEBIT_DAY] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_CONTACT] (
	[COMPANY_ID] [int] NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[CONTACT_TYPE] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_CORRESPONDENCE] (
	[COMPANY_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_INVOICES] (
	[COMPANYID] [int] NOT NULL ,
	[INVOICEID] [int] NOT NULL ,
	[PAID] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_OBJECT] (
	[COMPANY_ID] [int] NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[DATE_FROM] [smalldatetime] NOT NULL ,
	[DATE_TO] [smalldatetime] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_PAYMENTS] (
	[COMPANYID] [int] NOT NULL ,
	[INVOICEID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_STATUS] (
	[COMPANY_STATUS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COMPANY_STATUS_CODE] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPANY_TYPES] (
	[COMPANY_TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINTS] (
	[COMPLAINT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COMPLAINT_SOURCE] [int] NOT NULL ,
	[COMPANY_ID] [int] NULL ,
	[OBJECT_ID] [int] NULL ,
	[FACILITY_ID] [int] NULL ,
	[COMPLAINER] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INITIALS] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PREFIX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DEGREE] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TITLE] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENDER] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMAIL] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DESCRIPTION] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SOLUTION] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[URGENCY] [int] NULL ,
	[DATE_READY] [smalldatetime] NULL ,
	[COMPLAINT_TYPE] [int] NULL ,
	[FIXED] [bit] NULL ,
	[COMPLAINT_DATE] [smalldatetime] NOT NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CONTACT_ID] [int] NULL ,
	[DIRECT_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MOBILE_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RESOLUTION_DATE] [smalldatetime] NULL ,
	[C_NAME] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NAME_ID] [int] NULL ,
	[SHOW_OWNER] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_ACTIONS] (
	[COMPLAINT_ACTION_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_CORRESPONDENCE] (
	[COMPLAINT_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_HISTORY] (
	[ACTION_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COMPLAINT_ID] [int] NOT NULL ,
	[STATUS_CODE] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [datetime] NOT NULL ,
	[ACCOUNTABLE] [int] NULL ,
	[RESPONSIBLE] [int] NULL ,
	[ACTION_UNDERTAKEN] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DESCRIPTION] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SHOW_OWNER] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_SOURCES] (
	[COMPLAINT_SOURCE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SRC_TYPE_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_SOURCE_TYPES] (
	[C_SRC_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_STATUS] (
	[STATUS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RESOLVED] [bit] NOT NULL ,
	[INSP] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_TYPES] (
	[COMPLAINT_TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COMPLAINT_URGENCY] (
	[URGENCY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TIME_TO_SOLUTION] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACTS] (
	[CONTACT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CONTACT_STATUS_ID] [int] NULL ,
	[STAT_EFF] [smalldatetime] NULL ,
	[COMPANY_ID] [int] NULL ,
	[LASTNAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INITIALS] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PREFIX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FIRSTNAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TITLE] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SALUTATION] [varchar] (250) COLLATE Latin1_General_CI_AS NULL ,
	[PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[WEBSITE] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DIRECT_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DIRECT_FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DIRECT_EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MOBILE_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DEPARTMENT] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[JOB_TITLE] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECIEVE_MAIL] [bit] NULL ,
	[MAIL_VIA_POST] [bit] NULL ,
	[MAIL_VIA_EMAIL] [bit] NULL ,
	[MAIL_VIA_FAX] [bit] NULL ,
	[PRIVATE_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PRIVATE_FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PRIVATE_EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NOTES] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[DATE_ENDED] [smalldatetime] NULL ,
	[RECORD_MODIFIER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_LAST_CONTACT] [smalldatetime] NULL ,
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POL_PART] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_ADDRESS] (
	[CONTACT_ID] [int] NOT NULL ,
	[ADDRESS_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_CONTACTTYPE] (
	[CONTACT_ID] [int] NOT NULL ,
	[CONTACT_TYPE] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_CORRESPONDENCE] (
	[CONTACT_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_HISTORY] (
	[DOCUMENT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DOCUMENT_TYPE] [int] NOT NULL ,
	[DOCUMENT_DATE] [smalldatetime] NOT NULL ,
	[DOCUMENT_PATH] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DOCUMENT_REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COMPANY_ID] [int] NULL ,
	[OBJECT_ID] [int] NULL ,
	[CONTACT_ID] [int] NULL ,
	[RESIDENT_ID] [int] NULL ,
	[COMPLAINT_ID] [int] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_SALES_ACTIVITY] (
	[CONTACT_ID] [int] NOT NULL ,
	[SALES_ACTIVITY] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_STATUS] (
	[CONTACT_STATUS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_STATUS_HISTORY] (
	[CONTACT_ID] [int] NULL ,
	[STATUS_ID] [int] NULL ,
	[DATE_FROM] [smalldatetime] NULL ,
	[DATE_TO] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTACT_TYPES] (
	[CONTACT_TYPE] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CONTROL_CHECK_PICTURES] (
	[PICTURE_ID] [int] NOT NULL ,
	[OBJECT_CHECK_ID] [int] NOT NULL ,
	[DESCRIPTION] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RECORD_MANAGER_ID] [int] NOT NULL ,
	[DATE_TAKEN] [datetime] NOT NULL ,
	[PHOTO] [image] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CORRESPONDENCE] (
	[CORRESPONDENCE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[C_TYPE] [int] NULL ,
	[CORRESPONDENCE_DATE] [smalldatetime] NULL ,
	[SENDER] [varchar] (100) COLLATE Latin1_General_CI_AS NULL ,
	[DIRECTION] [bit] NULL ,
	[TARGET] [int] NULL ,
	[bulk] [int] NULL ,
	[object_id] [int] NULL ,
	[company_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CORRESPONDENCE_DOCUMENTS] (
	[DOCUMENT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[MERGE_FILE] [image] NULL ,
	[FILESIZE] [int] NULL ,
	[FILENAME] [varchar] (500) COLLATE Latin1_General_CI_AS NULL ,
	[type_id] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CORRESPONDENCE_EMAIL] (
	[EMAIL_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[SUBJECT] [varchar] (4000) COLLATE Latin1_General_CI_AS NOT NULL ,
	[BODY] [text] COLLATE Latin1_General_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CORRESPONDENCE_SCANS] (
	[CORR_ID] [char] (10) COLLATE Latin1_General_CI_AS NOT NULL ,
	[SCAN] [image] NOT NULL ,
	[CORR_DATE] [smalldatetime] NOT NULL ,
	[FILENAME] [varchar] (200) COLLATE Latin1_General_CI_AS NOT NULL ,
	[FILESIZE] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CORRESPONDENCE_TYPES] (
	[TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COUNTIES] (
	[COUNTY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COUNTY] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[COUNTRIES] (
	[COUNTRY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COUNTRY] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DATABASES] (
	[DATABASE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[IPADDRESS] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATABASE_NAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FRIENDLY_NAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DEPARTMENTS] (
	[DEPARTMENT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DEPARTMENT_NAME] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DEPARTMENT_MODULES] (
	[DEPARTMENT_ID] [int] NOT NULL ,
	[MODULE_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DOCUMENT_COMMENTS] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DOCUMENT_TYPE] [int] NOT NULL ,
	[DOC_BLURB] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DOCUMENT_CORRESPONDENCE] (
	[DOCUMENT_ID] [int] NOT NULL ,
	[CORRESPONDENCE_ID] [char] (10) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DOCUMENT_RECIPIENTS] (
	[DOCUMENT_ID] [int] NOT NULL ,
	[RECIPIENT] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DOCUMENT_TEMPLATES] (
	[TEMPLATE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TEMPLATE_NAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TEMPLATE_PATH] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DOCUMENT_TYPES] (
	[DOCUMENT_TYPE] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ED] (
	[Name] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL ,
	[Reference] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL] (
	[COR_EMAIL_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[SUBJECT] [varchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BODY] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAILS] (
	[EMAIL_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ADDRESS] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[CONTACT_TYPE] [int] NOT NULL ,
	[DEFUALT] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_ADDRESSES] (
	[Nieuwsbrief_ID] [int] NULL ,
	[Email] [varchar] (1025) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Contact_ID] [int] NULL ,
	[Resident_ID] [int] NULL ,
	[company_id] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_ATTACHMENTS] (
	[ATT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[EMAIL_ID] [int] NOT NULL ,
	[ATTACH] [image] NOT NULL ,
	[FILENAME] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FILESIZE] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_CONTACT_TYPES] (
	[TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_CORRESPONDENCE] (
	[EMAIL_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_DOCUMENTS] (
	[EMAIL_ID] [int] NOT NULL ,
	[DOC_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_RECIPIENTS] (
	[EMAIL_ID] [int] NOT NULL ,
	[RECIPIENT] [int] NOT NULL ,
	[TARGET_TYPE] [int] NOT NULL ,
	[TO_TYPE] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMAIL_RECIPIENTS_NO_CRM] (
	[EMAIL_ID] [int] NOT NULL ,
	[RECIPIENT] [varchar] (250) COLLATE Latin1_General_CI_AS NOT NULL ,
	[TO_TYPE] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EMPLOYEES] (
	[EMPLOYEE_ID] [int] NOT NULL ,
	[JOB_TITLE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FIRSTNAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LASTNAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[EMAIL] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[USERID] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ACTIVE] [bit] NULL ,
	[PERMISSIONS] [bit] NULL ,
	[USER_TYPE] [int] NULL ,
	[ACCMAN] [bit] NOT NULL ,
	[WORK_MOBILE] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[PRIVATE_MOBILE] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[DIRECT_PHONE] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[PASSWORD] [varchar] (50) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FACILITIES] (
	[FACILITY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[FACILITY_TYPE] [int] NULL ,
	[SERIAL_NUMBER] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DESCRIPTION] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LOCATION] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_INSTALLED] [smalldatetime] NULL ,
	[DATE_REMOVED] [smalldatetime] NULL ,
	[DATE_LAST_CHECK] [smalldatetime] NULL ,
	[DATE_NEXT_CHECK] [smalldatetime] NULL ,
	[MAINT_ID] [int] NULL ,
	[REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IN_USE] [bit] NULL ,
	[RESIDENT_ID] [int] NULL ,
	[PHOTO_ID] [int] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL ,
	[IN_INSP] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FACILITY_TYPES] (
	[FACILITY_TYPE] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[INSPECTION] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FILTERTABEL] (
	[RESIDENT_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FMT_COL] (
	[RPT_ID] [int] NULL ,
	[COL_ID] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COL_SIZE] [int] NULL ,
	[COL_JUST] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FMT_HDR] (
	[RPT_ID] [int] NULL ,
	[HDR_CELL_REF_COL] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HDR_CELL_REF_ROW] [int] NULL ,
	[HDR_TEXT] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HDR_BORDER] [int] NULL ,
	[HDR_FONT] [int] NULL ,
	[HDR_WEIGHT] [int] NULL ,
	[HDR_VER] [int] NULL ,
	[HDR_HOR] [int] NULL ,
	[HDR_WRAP] [int] NULL ,
	[HDR_MERGE_COL] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HDR_MERGE_ROW] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FORM_TEMPLATE] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TEMPLATE] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[GENDER] (
	[GENDER_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GENDER] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[INSPECTION_COMMENTS] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TEXT] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[INTERNET_FORM] (
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PROFILE_ATTRIBUTE_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[INVOICES] (
	[INVOICEID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATEOFISSUE] [datetime] NOT NULL ,
	[CONTACT_ID] [int] NULL ,
	[OVERDUEAFTER_ID] [int] NULL ,
	[AMOUNT] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[VAT] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DOCUMENT] [image] NULL ,
	[DOCUMENT_SIZE] [int] NULL ,
	[DOCUMENT_NAME] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[INVOICE_ITEMS] (
	[ITEM_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[INVOICEID] [int] NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AMOUNT] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[VAT] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[INVOICE_PERIOD] (
	[OVERDUE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PERIOD] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ISS_CheckList] (
	[OBJECT_ID] [int] NOT NULL ,
	[description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[OnRoute] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[JOB_TITLES] (
	[JOB_TITLE] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LANGUAGES] (
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MAILINGS] (
	[MAILING_NAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SQLSTRING] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[MAINTAINERS] (
	[MAINT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NAME] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CONTACT] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS1] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS2] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS3] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS4] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CITY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POSTCODE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTRY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMAIL] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TELEPHONE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MOBILE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[USED] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MERGEFIELDS] (
	[CONTACT_ID] [int] NULL ,
	[LASTNAME] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INITIALS] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PREFIX] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FIRSTNAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COMPANY_NAME] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[JOB_TITLE] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADRES1] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HOUSENUMBER] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STREETNAME] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADRES4] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADRES5] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POSTALCODE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CITY] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MERGE_DOCUMENTS] (
	[DOC_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DOC_LIST_NAME] [varchar] (250) COLLATE Latin1_General_CI_AS NOT NULL ,
	[DOC_NAME] [varchar] (250) COLLATE Latin1_General_CI_AS NOT NULL ,
	[DOC_TYPE] [int] NOT NULL ,
	[DESCRIPTION] [varchar] (1000) COLLATE Latin1_General_CI_AS NULL ,
	[DOCUMENT] [image] NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL ,
	[RECORD_MANAGER] [int] NOT NULL ,
	[FILESIZE] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[MERGE_FIELDS] (
	[FIELD] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL ,
	[ORD] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[METERS] (
	[METER_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[METERTYPE] [int] NULL ,
	[SerialNumber] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Location] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SUPP_ID] [int] NULL ,
	[NOTES] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[START_DATE] [smalldatetime] NULL ,
	[END_DATE] [smalldatetime] NULL ,
	[PHOTO_ID] [int] NULL ,
	[IN_USE] [bit] NULL ,
	[MODIFIED_BY] [int] NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[METER_RATES] (
	[Meter_id] [int] NOT NULL ,
	[Rate_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[METER_READINGS] (
	[READING_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[METER_ID] [int] NOT NULL ,
	[DATED] [datetime] NOT NULL ,
	[OPERATOR] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[READING] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OBJECT_CHECK_ID] [int] NULL ,
	[RATE_ID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[METER_TYPES] (
	[TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NOTES] (
	[ACTIVITY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[COMPANY_ID] [int] NULL ,
	[OBJECT_ID] [int] NULL ,
	[CONTACT_ID] [int] NULL ,
	[RESIDENT_ID] [int] NULL ,
	[ACTIVITY_DATE] [smalldatetime] NULL ,
	[REGARDING] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SAVED_IN_OUTLOOK] [bit] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL ,
	[IN_INSP] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECTS] (
	[OBJECT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[OBJECT_NAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PROPERTY_ID] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[HOUSENAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HOUSENUMBER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STREETNAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS4] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CITY] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POSTALCODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTY] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTRY] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AREA_ID] [int] NULL ,
	[MAX_NR_RESIDENTS] [int] NULL ,
	[ACTUAL_NR_RESIDENTS] [int] NULL ,
	[OBJECT_TYPE] [int] NULL ,
	[MONTHLY_FEE] [decimal](10, 2) NULL ,
	[LIC_FEE] [decimal](10, 2) NULL ,
	[DATE_STARTED] [smalldatetime] NULL ,
	[DATE_STOPPED] [smalldatetime] NULL ,
	[RETURN_DATE_RESIDENTS] [smalldatetime] NULL ,
	[RETURN_DATE_OWNER] [smalldatetime] NULL ,
	[PRESS_RELEASE] [bit] NULL ,
	[INQUIRY_FORM] [bit] NULL ,
	[REGION_MANAGER] [int] NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MODIFIER] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL ,
	[REMARKS] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STATUS_ID] [int] NULL ,
	[STAT_EFF] [smalldatetime] NULL ,
	[ACCOUNT_MANAGER] [int] NULL ,
	[PROPERTY_MANAGER] [int] NULL ,
	[PROPERTY_INSPECTOR] [int] NULL ,
	[GUARDIAN_MANAGER] [int] NULL ,
	[PHOTO_ID] [int] NULL ,
	[KEY_NUMBER] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CALAM_LIMIT] [decimal](10, 2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_CHECKS] (
	[OBJECT_CHECK_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[DATE_CHECK] [smalldatetime] NULL ,
	[OBJECT_TYPE] [int] NULL ,
	[COMPANY_ID] [int] NULL ,
	[REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INTERNAL_REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL ,
	[Damages] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Repairs] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CamelotAction] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ClientAction] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NextCamelotAction] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NextClientAction] [varchar] (1500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[REPORT_COMMENTS] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[REPORT_SENT] [bit] NOT NULL ,
	[DATE_SENT] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_CHECK_METERS] (
	[OBJECT_CHECK_ID] [int] NOT NULL ,
	[METER_ID] [int] NOT NULL ,
	[READING] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_COMPLAINTS] (
	[OBJECT_ID] [int] NOT NULL ,
	[COMPLAINT_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_CONTACT] (
	[OBJECT_ID] [int] NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[DATE_START] [smalldatetime] NOT NULL ,
	[DATE_END] [smalldatetime] NULL ,
	[REMARKS] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CONTACT_TYPE] [int] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_CONTACT_TYPE] (
	[OBJECT_ID] [int] NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[CONTACT_TYPE] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_CORRESPONDENCE] (
	[OBJECT_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_FACILITIES] (
	[OBJECT_ID] [int] NOT NULL ,
	[FACILITY_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_INQUIRIES] (
	[INQUIRY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[EXPECTATIONS] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SATISFACTION] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[REACHABILITY] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[REGION_MANAGER_SATISFACTION] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CALL_FOR_FOLLOW_UP] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PHONE_NUMBER] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STAYS_CUSTOMER] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IMPROVEMENT_SUGGESTIONS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NEW_SERVICES] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GENERAL_REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_METER] (
	[METER_ID] [int] NOT NULL ,
	[OBJECT_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_PICTURES] (
	[PHOTO_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_ROUTE] (
	[ROUTE_ID] [int] NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[ORDER_NO] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_SECURITIES] (
	[OBJECT_ID] [int] NOT NULL ,
	[SECURITY_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_STATUS] (
	[STATUS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[STATUS_DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MANAGED] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_STATUS_HISTORY] (
	[OBJECT_ID] [int] NOT NULL ,
	[STATUS_ID] [int] NOT NULL ,
	[DATE_FROM] [smalldatetime] NOT NULL ,
	[DATE_TO] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OBJECT_TYPES] (
	[OBJECT_TYPE_ID] [int] NOT NULL ,
	[OBJECT_TYPE_CODE] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PAYMENTS] (
	[PAYMENTID] [int] IDENTITY (1, 1) NOT NULL ,
	[PAYMENTTYPEID] [int] NOT NULL ,
	[DATE] [datetime] NOT NULL ,
	[AMOUNT] [decimal](18, 0) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PAYMENTYPES] (
	[PAYMENTTYPEID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PHOTOS] (
	[PHOTO_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[PHOTO_TYPE_ID] [int] NOT NULL ,
	[PARENT] [int] NOT NULL ,
	[PHOTO] [image] NOT NULL ,
	[THUMBNAIL] [image] NULL ,
	[FULL_PHOTO] [image] NULL ,
	[CONT_TYPE] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FILESIZE] [int] NOT NULL ,
	[THUMBSIZE] [int] NULL ,
	[FULLSIZE] [int] NULL ,
	[FILENAME] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IS_DEFAULT] [bit] NOT NULL ,
	[RECORD_MODIFIER] [int] NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[PHOTO_TYPES] (
	[Photo_Type_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PROFILE_ATTRIBUTES] (
	[PROFILE_ATTRIBUTE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[PROFILE_CODE] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FORM_CONTROL_TYPE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LANGUAGE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[REQUIRED_IN_FORM] [bit] NULL ,
	[SORT_ORDER] [varchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PROJECTS] (
	[PROJECT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[PROJECT_CODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PROJECT_NAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[START_DATE] [smalldatetime] NULL ,
	[END_DATE] [smalldatetime] NULL ,
	[PROJECT_MANAGER] [int] NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RATES] (
	[Rate_id] [int] IDENTITY (1, 1) NOT NULL ,
	[Rate_Desc] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Meter_type] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RECIPIENT_TYPES] (
	[TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[REMINDERS] (
	[REMINDER_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CONTACT_ID] [int] NOT NULL ,
	[REMINDER_DATE] [smalldatetime] NOT NULL ,
	[REMINDER_TEXT] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[REPORTS] (
	[REPORT_ID] [int] NOT NULL ,
	[REPORT_NAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATES] [bit] NULL ,
	[PROPERTY] [bit] NULL ,
	[COMPANY_TYPE] [bit] NULL ,
	[ACCOUNT] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENTINVOICE] (
	[RESIDENTID] [int] NOT NULL ,
	[INVOICEID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENTPAYMENTS] (
	[RESIDENTID] [int] NOT NULL ,
	[PAYMENTID] [int] NOT NULL ,
	[INVOICEID] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENTS] (
	[RESIDENT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DEBITEURNR] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SEARCH_CODE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RESIDENT_STATUS_ID] [int] NULL ,
	[STAT_EFF] [smalldatetime] NULL ,
	[LASTNAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INITIALS] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PREFIX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FIRSTNAME] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TITLE] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SALUTATION] [varchar] (250) COLLATE Latin1_General_CI_AS NULL ,
	[GENDER] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NATIONALITY] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[WEBSITE] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PARENT_PHONE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MOBILE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PRIVATE_MOBILE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PARENT_MOBILE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COMPANY_NAME] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DEPARTMENT] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[JOB_TITLE] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BIRTH_DATE] [smalldatetime] NULL ,
	[RECIEVE_MAIL] [bit] NULL ,
	[MAIL_VIA_POST] [bit] NULL ,
	[MAIL_VIA_EMAIL] [bit] NULL ,
	[MAIL_VIA_FAX] [bit] NULL ,
	[PRIVATE_PHONE] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PRIVATE_FAX] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PRIVATE_EMAIL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PARENT_EMAIL] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NOTES] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[DATE_ENDED] [smalldatetime] NULL ,
	[PICTURE_ID] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_LAST_CONTACT] [smalldatetime] NULL ,
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[STARTDATE_CONTRACT] [smalldatetime] NULL ,
	[RECORD_MODIFIER] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL ,
	[RESIDENT_TYPE] [int] NULL ,
	[RELIGION] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ETHNIC] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DISABLE] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CRIMINAL] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COURT] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[JOBS] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[P_CIT] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMPSIT] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CRITERIA] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CASH] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Reject] [bit] NULL ,
	[RENT] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[RENT_BREAK] [smalldatetime] NULL ,
	[BREAK_REASON] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FIREPACK] [smalldatetime] NULL ,
	[INSURANCE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PHOTO_ID] [bit] NOT NULL ,
	[APPLIC_FORM] [bit] NOT NULL ,
	[LICENSE] [bit] NOT NULL ,
	[BANK_UTIL] [bit] NOT NULL ,
	[REF] [bit] NOT NULL ,
	[BOOKLET] [bit] NOT NULL ,
	[STAND] [bit] NOT NULL ,
	[EXEC_DES] [bit] NOT NULL ,
	[VNOTES] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INOUT] [bit] NOT NULL ,
	[OUT_DATE] [smalldatetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENTS_FILTER] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[PROFILE_ATTRIBUTE_ID] [int] NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LANGUAGE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FILTER_VALUE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_ADDRESS] (
	[RESIDENT_ID] [int] NOT NULL ,
	[ADDRESS_ID] [int] NOT NULL ,
	[ADDRESS_TYPE] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_BANK] (
	[RESIDENT_ID] [int] NOT NULL ,
	[BANKDETAIL_ID] [int] NOT NULL ,
	[DEBIT_DAY] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_CORRESPONDENCE] (
	[RESIDENT_ID] [int] NOT NULL ,
	[CORR_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_OBJECT] (
	[RESIDENT_ID] [int] NOT NULL ,
	[OBJECT_ID] [int] NOT NULL ,
	[DATE_FROM] [smalldatetime] NOT NULL ,
	[DATE_TO] [smalldatetime] NULL ,
	[MAIN_RESIDENT] [bit] NOT NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL ,
	[ROOM] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_PROFILE] (
	[RESIDENT_ID] [int] NOT NULL ,
	[PROFILE_ATTRIBUTE_ID] [int] NOT NULL ,
	[PROFILE_VALUE] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_STATUS] (
	[RESIDENT_STATUS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[STATUS_CODE] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RESIDENT_TYPE] (
	[RESIDENT_TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTES] (
	[ROUTEID] [int] IDENTITY (1, 1) NOT NULL ,
	[NAME] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ACTIVE] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ROUTE_INSPECTIONS] (
	[ROUTE_ID] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[INSP_DATE] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SALES_ACTIVITY] (
	[SALES_ACTIVITY] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SCAN_DOCUMENTS] (
	[DOCUMENT_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TYPE] [int] NOT NULL ,
	[PARENT] [int] NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DOCUMENT] [image] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[SCAN_DOCUMENT_TYPES] (
	[TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SECURITIES] (
	[SECURITY_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[SECURITY_TYPE] [int] NULL ,
	[SERIAL_NUMBER] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DESCRIPTION] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LOCATION] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_INSTALLED] [smalldatetime] NULL ,
	[DATE_REMOVED] [smalldatetime] NULL ,
	[DATE_LAST_CHECK] [smalldatetime] NULL ,
	[DATE_NEXT_CHECK] [smalldatetime] NULL ,
	[MAINT_ID] [int] NULL ,
	[REMARKS] [nvarchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IN_USE] [bit] NULL ,
	[RESIDENT_ID] [int] NULL ,
	[PHOTO_ID] [int] NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_MODIFIED] [smalldatetime] NULL ,
	[CODE] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EM_CONT] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CONT_NO] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SECURITY_TYPES] (
	[SECURITY_TYPE] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RECORD_MANAGER] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DATE_ENTERED] [smalldatetime] NULL ,
	[INSPECTION] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SELECTED_INSP_COMMENTS] (
	[INSP_ID] [int] NOT NULL ,
	[COMM_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[T Vetting] (
	[VetKey] [int] NOT NULL ,
	[Surname1] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Initials1] [nvarchar] (10) COLLATE Latin1_General_CI_AS NULL ,
	[Checkd] [bit] NOT NULL ,
	[Building Code] [int] NULL ,
	[Employee] [bit] NOT NULL ,
	[Vetting Started] [smalldatetime] NULL ,
	[Guardian Vetting Completed] [smalldatetime] NULL ,
	[5 Yr Vetting Completed] [smalldatetime] NULL ,
	[10 Yr Vetting Completed] [smalldatetime] NULL ,
	[Applic Form Recd Date] [smalldatetime] NULL ,
	[Employer 1] [bit] NOT NULL ,
	[Employer 2] [bit] NOT NULL ,
	[Employer 3] [bit] NOT NULL ,
	[Employer 4] [bit] NOT NULL ,
	[Employer 5] [bit] NOT NULL ,
	[Employer 6] [bit] NOT NULL ,
	[Employer 7] [bit] NOT NULL ,
	[Employer 8] [bit] NOT NULL ,
	[Personal 1] [bit] NOT NULL ,
	[Personal 2] [bit] NOT NULL ,
	[Employer 1 Date] [smalldatetime] NULL ,
	[Employer 2 Date] [smalldatetime] NULL ,
	[Employer 3 Date] [smalldatetime] NULL ,
	[Employer 4 Date] [smalldatetime] NULL ,
	[Employer 5 Date] [smalldatetime] NULL ,
	[Employer 6 Date] [smalldatetime] NULL ,
	[Employer 7 Date] [smalldatetime] NULL ,
	[Employer 8 Date] [smalldatetime] NULL ,
	[Personal 1 Date] [smalldatetime] NULL ,
	[Personal 2 Date] [smalldatetime] NULL ,
	[NI Number] [nvarchar] (10) COLLATE Latin1_General_CI_AS NULL ,
	[ID Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Address Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Bank Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Work Permit Check (Employee)] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Naturalisation Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Kill] [bit] NOT NULL ,
	[Gaps] [ntext] COLLATE Latin1_General_CI_AS NULL ,
	[Photo] [bit] NOT NULL ,
	[Notes1] [ntext] COLLATE Latin1_General_CI_AS NULL ,
	[Employer 1 Relevant] [bit] NOT NULL ,
	[Employer 2 Relevant] [bit] NOT NULL ,
	[Employer 3 Relevant] [bit] NOT NULL ,
	[Employer 4 Relevant] [bit] NOT NULL ,
	[Employer 5 Relevant] [bit] NOT NULL ,
	[Employer 6 Relevant] [bit] NOT NULL ,
	[Employer 7 Relevant] [bit] NOT NULL ,
	[Employer 8 Relevant] [bit] NOT NULL ,
	[Last Change] [smalldatetime] NULL ,
	[Originated] [smalldatetime] NULL ,
	[SO Amount] [money] NULL ,
	[Qualified Sign Off] [bit] NOT NULL ,
	[DW] [bit] NOT NULL ,
	[Mr/Mrs] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Terminated] [bit] NOT NULL ,
	[Started] [bit] NOT NULL ,
	[ID Expiry] [smalldatetime] NULL ,
	[Msg1] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Msg2] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[No Vetting] [bit] NOT NULL ,
	[QS Reason] [nvarchar] (250) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TAAL] (
	[TAAL_CODE] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[OMSCHRIJVING] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HTMLSJABLOON] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SenderAddress] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SenderName] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[emailreactie] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[subject] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[logo] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[server] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Username] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Password] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[header_img] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[address] [varchar] (2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[afmeldtekst] [varchar] (2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TITLES] (
	[TITLE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TITLE] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Table1] (
	[t1] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[USER_TYPES] (
	[USER_TYPE_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MENU] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UTILITY_SUPPLIERS] (
	[SUPP_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NAME] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CONTACT] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS1] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS2] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS3] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ADDRESS4] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CITY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[POSTCODE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[COUNTRY] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EMAIL] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TELEPHONE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MOBILE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[VET_SCANS] (
	[VS_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RESIDENT_ID] [int] NOT NULL ,
	[SCAN_NAME] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SCAN_SIZE] [int] NOT NULL ,
	[SCAN] [image] NOT NULL ,
	[DESCRIPTION] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RECORD_MODIFIER] [int] NOT NULL ,
	[DATE_ENTERED] [smalldatetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[results] (
	[10 Yr Vetting Completed] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[5 Yr Vetting Completed] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Address Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Applic Form Recd Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Bank Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Building Code] [int] NULL ,
	[Checkd] [bit] NOT NULL ,
	[DW] [bit] NOT NULL ,
	[Employee] [bit] NOT NULL ,
	[Employer 1] [bit] NOT NULL ,
	[Employer 1 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 1 Relevant] [bit] NOT NULL ,
	[Employer 2] [bit] NOT NULL ,
	[Employer 2 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 2 Relevant] [bit] NOT NULL ,
	[Employer 3] [bit] NOT NULL ,
	[Employer 3 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 3 Relevant] [bit] NOT NULL ,
	[Employer 4] [bit] NOT NULL ,
	[Employer 4 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 4 Relevant] [bit] NOT NULL ,
	[Employer 5] [bit] NOT NULL ,
	[Employer 5 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 5 Relevant] [bit] NOT NULL ,
	[Employer 6] [bit] NOT NULL ,
	[Employer 6 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 6 Relevant] [bit] NOT NULL ,
	[Employer 7] [bit] NOT NULL ,
	[Employer 7 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 7 Relevant] [bit] NOT NULL ,
	[Employer 8] [bit] NOT NULL ,
	[Employer 8 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Employer 8 Relevant] [bit] NOT NULL ,
	[Gaps] [ntext] COLLATE Latin1_General_CI_AS NULL ,
	[Guardian Vetting Completed] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[ID Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[ID Expiry] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Initials1] [nvarchar] (10) COLLATE Latin1_General_CI_AS NULL ,
	[Kill] [bit] NOT NULL ,
	[Last Change] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Mr/Mrs] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Msg1] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Msg2] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Naturalisation Check] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[NI Number] [nvarchar] (10) COLLATE Latin1_General_CI_AS NULL ,
	[No Vetting] [bit] NOT NULL ,
	[Notes1] [ntext] COLLATE Latin1_General_CI_AS NULL ,
	[Originated] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Personal 1] [bit] NOT NULL ,
	[Personal 1 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Personal 2] [bit] NOT NULL ,
	[Personal 2 Date] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Photo] [bit] NOT NULL ,
	[QS Reason] [nvarchar] (250) COLLATE Latin1_General_CI_AS NULL ,
	[Qualified Sign Off] [bit] NOT NULL ,
	[SO Amount] [money] NULL ,
	[Started] [bit] NOT NULL ,
	[Surname1] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Terminated] [bit] NOT NULL ,
	[VetKey] [int] NOT NULL ,
	[Vetting Started] [varchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Work Permit Check (Employee)] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE ADD_COMPANY
(
	@COMP_NAME VARCHAR(250),
	@HOUSENAME VARCHAR(50),
	@STREETNAME VARCHAR(50),
	@ADDRESS4 VARCHAR(50),
	@ADDRESS5 VARCHAR(50),
	@CITY VARCHAR(50),
	@COUNTY VARCHAR(50),
	@POSTALCODE VARCHAR(50),
	@COUNTRY VARCHAR(50),
	@AREA_ID INT,
	@STATUS_ID INT,
	@COMPANY_TYPE INT,
	@STAT_EFF VARCHAR(20),
	@ACCOUNT_MANAGER INT,
	@SALES_MANAGER INT,
	@RECORD_MODIFIER INT,
	@TEL VARCHAR(50),
	@FAX VARCHAR(50),
	@EMAIL VARCHAR(50),
	@WEB VARCHAR(50)
)AS

DECLARE @ADD_ID AS INT
DECLARE @COMP_ID AS INT

INSERT INTO 
	ADDRESSES
SELECT
	@HOUSENAME,
	'',
	@STREETNAME,
	@ADDRESS4,
	@ADDRESS5,
	@POSTALCODE,
	@CITY,
	@COUNTY,
	@AREA_ID,
	@COUNTRY,
	GETDATE(),
	@RECORD_MODIFIER

SELECT @ADD_ID = @@IDENTITY
	

INSERT INTO 
	COMPANIES
SELECT
	@COMP_NAME,
	'',
	'',
	@TEL,
	@FAX,
	@EMAIL,
	@WEB,
	@COMPANY_TYPE,
	@STATUS_ID,
	CONVERT(SMALLDATETIME,@STAT_EFF,103),
	@ACCOUNT_MANAGER,
	@SALES_MANAGER,
	GETDATE(),
	'',
	RECORD_MODIFIER = @RECORD_MODIFIER,
	DATE_MODIFIED = getdate()

SELECT @COMP_ID = @@IDENTITY

INSERT INTO COMPANY_ADDRESS SELECT @COMP_ID, @ADD_ID,1

SELECT @COMP_ID, @COMP_NAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_CONCOMP
(
	@CONT_ID INT,
	@COMP_ID NUMERIC(18),
	@CONT_TYPE INT
) AS


INSERT INTO 
	COMPANY_CONTACT
SELECT
	@COMP_ID,
	@CONT_ID,
	@CONT_TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_DOC
(
	@FILENAME VARCHAR(250),
	@TYPE INT,
	@LIST_NAME VARCHAR(1000),
	@DESCRIPTION VARCHAR(4000),
	@DOC IMAGE,
	@SIZE NUMERIC(18),
	@RECORD_MODIFIER INT
) AS


INSERT INTO MERGE_DOCUMENTS
SELECT 
	@LIST_NAME,
	@FILENAME,
	@TYPE,
	@DESCRIPTION,
	@DOC,	
	GETDATE(),
	@RECORD_MODIFIER,
	@SIZE







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_INSPECTION
(
	@PROP_ID AS INT,
	@DATE VARCHAR(20),
	@INSPECTOR INT,
	@REPORT_COMMENTS VARCHAR(400)
) AS

INSERT INTO
	OBJECT_CHECKS (OBJECT_ID, DATE_CHECK,RECORD_MANAGER, REPORT_COMMENTS)
SELECT
	@PROP_ID,
	CONVERT(SMALLDATETIME,@DATE,103),
	@INSPECTOR,
	@REPORT_COMMENTS

SELECT @@IDENTITY








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE ADD_MERGE_FIELD
(
	@FIELD VARCHAR(50),
	@ORD INT
) AS

INSERT INTO 
	MERGE_FIELDS
SELECT
	@FIELD,
	@ORD








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_METER_RATE
(
	@RATE_DESC VARCHAR(500),
	@MET_TYPE INT
) AS

INSERT INTO RATES (RATE_DESC, METER_TYPE)
SELECT @RATE_DESC, @MET_TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_OBJCONT
(
	@CONT_ID INT,
	@PROP_ID NUMERIC(18),
	@CONT_TYPE INT
) AS


INSERT INTO 
	OBJECT_CONTACT_TYPE
SELECT
	@PROP_ID,
	@CONT_ID,
	@CONT_TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_PHOTO
(
	@FILENAME VARCHAR(250),
	@DESCRIPTION VARCHAR(4000),
	@PHOTO IMAGE,
	@THUMB IMAGE,
	@FULL IMAGE,
	@FILESIZE NUMERIC(18),
	@THUMBSIZE NUMERIC(18),
	@FULLSIZE NUMERIC(18),
	@CONT_TYPE VARCHAR(200),
	@PARENT NUMERIC(18),
	@PHOTO_TYPE INT,
	@RECORD_MODIFIER INT
) AS

DECLARE @CNT AS INT

SELECT @CNT = COUNT(*) FROM PHOTOS WHERE PARENT = @PARENT


IF @CNT > 0
BEGIN
	INSERT INTO PHOTOS
	SELECT 
		@PHOTO_TYPE,
		@PARENT,
		@PHOTO,
		@THUMB,
		@FULL,
		@CONT_TYPE,
		@FILESIZE,
		@THUMBSIZE,
		@FULLSIZE,
		@FILENAME,
		@DESCRIPTION,
		0,
		@RECORD_MODIFIER,
		GETDATE()
END
ELSE
BEGIN
	INSERT INTO PHOTOS
	SELECT 
		@PHOTO_TYPE,
		@PARENT,
		@PHOTO,
		@THUMB,
		@FULL,
		@CONT_TYPE,
		@FILESIZE,
		@THUMBSIZE,
		@FULLSIZE,
		@FILENAME,
		@DESCRIPTION,
		1,
		@RECORD_MODIFIER,
		GETDATE()
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE ADD_PROPERTY
(
	@NAME VARCHAR(250),
	@KEY_NUMBER VARCHAR(20),
	@HOUSENAME VARCHAR(50),
	@STREETNAME VARCHAR(50),
	@ADDRESS4 VARCHAR(50),
	@CITY VARCHAR(50),
	@COUNTY VARCHAR(50),
	@POSTALCODE VARCHAR(50),
	@COUNTRY VARCHAR(50),
	@AREA_ID INT = 1,
	@REGION_MANAGER INT,
	@MAX_NR_RESIDENTS INT,
	@STATUS_ID INT,
	@OBJECT_TYPE INT,
	@STAT_EFF SMALLDATETIME,
	@DATE_STOPPED SMALLDATETIME,
	@DATE_STARTED SMALLDATETIME,
	@ACCOUNT_MANAGER INT,
	@PROPERTY_MANAGER INT,
	@PROPERTY_INSPECTOR INT,
	@GUARDIAN_MANAGER INT,
	@RECORD_MODIFIER INT,
	@COMP_ID INT,
	@M_FEE VARCHAR(50),
	@L_FEE VARCHAR(50),
	@CALAM_LIMIT VARCHAR(50)
)AS

DECLARE @PROP_ID INTEGER


INSERT INTO 
	OBJECTS (OBJECT_NAME,KEY_NUMBER,
	HOUSENAME,
	STREETNAME,
	ADDRESS4,
	CITY,
	COUNTY,
	POSTALCODE,
	COUNTRY,
	AREA_ID,
	REGION_MANAGER,
	MAX_NR_RESIDENTS,
	STATUS_ID,
	OBJECT_TYPE,
	MONTHLY_FEE,
	LIC_FEE,
	CALAM_LIMIT,
	STAT_EFF,
	DATE_STOPPED,
	DATE_STARTED,
	ACCOUNT_MANAGER,
	PROPERTY_MANAGER,
	PROPERTY_INSPECTOR,
	GUARDIAN_MANAGER,
	RECORD_MODIFIER,
	DATE_MODIFIED)
SELECT
	@NAME,
	@KEY_NUMBER,
	@HOUSENAME,
	@STREETNAME,
	@ADDRESS4,
	@CITY,
	@COUNTY,
	@POSTALCODE,
	@COUNTRY,
	@AREA_ID,
	@REGION_MANAGER,
	@MAX_NR_RESIDENTS,
	@STATUS_ID,
	@OBJECT_TYPE,
	CONVERT(MONEY,@M_FEE),
	CONVERT(MONEY,@L_FEE),
	CONVERT(MONEY,@CALAM_LIMIT),
	@STAT_EFF,
	@DATE_STOPPED,
	@DATE_STARTED,
	@ACCOUNT_MANAGER,
	@PROPERTY_MANAGER,
	@PROPERTY_INSPECTOR,
	@GUARDIAN_MANAGER,
	@RECORD_MODIFIER,
	getdate()


	SELECT @PROP_ID = @@IDENTITY

	INSERT INTO 
		COMPANY_OBJECT
	SELECT
		@COMP_ID,
		@PROP_ID,
		GETDATE(),
		NULL,
		@RECORD_MODIFIER,
		GETDATE()

	INSERT INTO
		OBJECT_STATUS_HISTORY
	SELECT
		@PROP_ID,
		@STATUS_ID,
		@STAT_EFF,
		NULL

SELECT @PROP_ID, @NAME







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_PROPERTY_CONTACT
(
	@CONT INT,
	@PROP INT,
	@RECMAN INT
) AS

INSERT INTO
	OBJECT_CONTACT
SELECT
	@PROP,
	@CONT,
	GETDATE(),
	NULL,
	NULL,
	NULL,
	@RECMAN,
	GETDATE()








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE ADD_VET_SCAN
(
	@FILENAME VARCHAR(250),
	@RES_ID INT,
	@DESCRIPTION VARCHAR(4000),
	@SCAN IMAGE,
	@SIZE NUMERIC(18),
	@RECORD_MODIFIER INT
) AS


INSERT INTO VET_SCANS
SELECT 
	@RES_ID,
	@FILENAME,
	@SIZE,
	@SCAN,
	@DESCRIPTION,
	@RECORD_MODIFIER,
	GETDATE()








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE Auth_User
(
	@user varchar(50),
	@pass varchar(50)
)
AS

declare @res integer
declare @cnt int

select @res = 0
select @cnt = 0

select @cnt = count(*) from logins where userid = @user and active = 1
if @cnt = 0
begin
	select @res = 0
	select 
		0 as id,
		'uname' as name,
		'' as uname
end
else
begin
	select @cnt = count(*) from logins where userid = @user and password = @pass and active = 1
	if @cnt = 0
	begin
		select @res = 0
		select 
			0 as id,
			'pword' as name,
			'' as uname
	end
end


select 
	e.employee_id as id,
	e.userid as uname,
	d.database_name,
	d.connection_string
from
	logins e,
	databases d
where
	e.userid = @user
and	e.database_id = d.database_id
and	e.active = 1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE CGET_CORRESPONDENCE_TYPES AS

SELECT * FROM CORRESPONDENCE_TYPES









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE CGET_RECIPIENT_TYPES AS

SELECT * FROM RECIPIENT_TYPES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO












CREATE PROCEDURE CHANGE_OWNER
(
	@PROP_ID NUMERIC(18),
	@CCOMP_ID NUMERIC(18),
	@NCOMP_ID NUMERIC(18),
	@STAT_EFF SMALLDATETIME,
	@RECORD_MODIFIER INT
)
AS

DECLARE @COMP_ID NUMERIC(18)

IF @STAT_EFF = '1900-01-01' OR @STAT_EFF IS NULL
BEGIN
	SELECT @STAT_EFF = GETDATE()
END

UPDATE
	COMPANY_OBJECT
SET
	DATE_TO = @STAT_EFF
WHERE
	COMPANY_ID = @CCOMP_ID
AND	OBJECT_ID = @PROP_ID

SELECT @COMP_ID = COMPANY_ID FROM COMPANY_OBJECT WHERE OBJECT_ID = @PROP_ID AND COMPANY_ID = @NCOMP_ID

IF @COMP_ID IS NOT NULL
BEGIN
	UPDATE
		COMPANY_OBJECT
	SET
		COMPANY_ID = @NCOMP_ID,
		DATE_TO = NULL,
		RECORD_MANAGER = @RECORD_MODIFIER,
		DATE_ENTERED = GETDATE()
	WHERE
		OBJECT_ID = @PROP_ID
	AND 	COMPANY_ID = @COMP_ID
END
ELSE
BEGIN
	INSERT INTO
		COMPANY_OBJECT
	SELECT
		@NCOMP_ID,
		@PROP_ID,
		@STAT_EFF,
		NULL,
		@RECORD_MODIFIER,
		GETDATE()
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE CHANGE_PROPERTY
(
	@OPROP_ID NUMERIC(18),
	@NPROP_ID NUMERIC(18),
	@GUARD_ID NUMERIC(18),
	@STAT_EFF SMALLDATETIME,
	@RECORD_MODIFIER INT,
	@MAIN INT,
	@ROOM VARCHAR(250)
)
AS


IF @STAT_EFF = '1900-01-01'
BEGIN
	SELECT @STAT_EFF = GETDATE()
END

	UPDATE
		RESIDENT_OBJECT
	SET
		DATE_TO = @STAT_EFF
	WHERE
		RESIDENT_ID = @GUARD_ID
	AND	OBJECT_ID = @OPROP_ID


	INSERT INTO
		RESIDENT_OBJECT
	SELECT
		@GUARD_ID,
		@NPROP_ID,
		@STAT_EFF,
		'01/01/1900',
		@MAIN,
		@RECORD_MODIFIER,
		GETDATE(),
		@ROOM








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE CHECK_COMPANY
(
	@COMP VARCHAR(200),
	@POST VARCHAR(20)
) AS


SELECT
	COUNT(C.COMPANY_NAME) AS COUNT
FROM 
	COMPANIES C,
	ADDRESSES A,
	COMPANY_ADDRESS CA
WHERE
	C.COMPANY_ID = CA.COMPANY_ID
AND	A.ADDRESS_ID = CA.ADDRESS_ID
AND 	C.COMPANY_NAME = @COMP
AND	A.POSTALCODE = @POST








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE CHECK_COMP_CONT
(
	@COMP INT
) AS


SELECT
	COUNT(*) AS CNT
FROM
	COMPANY_CONTACT
WHERE
	COMPANY_ID = @COMP


SELECT 
	COUNT(*) AS CNT
FROM
	COMPANY_OBJECT
WHERE
	COMPANY_ID = @COMP
and	DATE_FROM < GETDATE()
AND	(DATE_TO > GETDATE() OR DATE_TO IS NULL)

select
	object_name
from
	objects
where
	object_id in (select object_id from company_object where company_id = @comp and date_from < getdate() and (date_to > getdate() or date_to is null) )






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE CHECK_CONT_CORR
(
	@CONT INT
)AS

select 
	count(cr.recipient) as cnt
from 
	correspondence  c,
	document_correspondence d,
	document_recipients cr
where 
	c.target = 2
and	c.correspondence_id = d.correspondence_id
and	cr.document_id = d.document_id
and	cr.recipient = @cont

select count(*) as cnt from object_contact where contact_id = @cont

select
	object_name
from
	objects
where
	object_id in (select object_id from object_contact where contact_id = @cont)






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_COMMENTS
(
	@INSP INT
)AS


DELETE FROM SELECTED_INSP_COMMENTS WHERE INSP_ID = @INSP








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE DELETE_DOCUMENT
(
	@DOC_ID INT
) AS


DELETE FROM
	MERGE_DOCUMENTS WHERE DOC_ID = @DOC_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_INVOICE_ITEMS
(
	@INV_ID INT
)AS

DELETE FROM INVOICE_ITEMS WHERE INVOICEID = @INV_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE DELETE_MERGE_FIELDS AS

DELETE FROM MERGE_FIELDS







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_METER_RATES
(
	@MET_ID INT
) AS

DELETE FROM METER_RATES WHERE METER_ID = @MET_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_METER_READING
(
	@MET_ID INT,
	@DATE SMALLDATETIME
) AS


DELETE FROM METER_READINGS WHERE METER_ID = @MET_ID AND DATED = @DATE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_PHOTO
(
	@PHOTO_ID INT
) AS

DELETE FROM PHOTOS WHERE PHOTO_ID = @PHOTO_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE DELETE_READING
(
	@READ_ID INT
) AS

DELETE FROM METER_READINGS WHERE READING_ID = @READ_ID









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_ROUTE_PROPERTIES
(
	@ROUTE_ID INT
) AS


DELETE FROM OBJECT_ROUTE WHERE ROUTE_ID = @ROUTE_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DELETE_VET_SCAN
(
	@SCAN_ID INT
) AS


DELETE FROM VET_SCANS WHERE VS_ID = @SCAN_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE DEL_COMP
(
	@COMP INT
) AS


DELETE FROM COMPANIES WHERE COMPANY_ID = @COMP






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DEL_CONCOMP
(
	@CONT_ID INT,
	@COMP_ID NUMERIC(18)
) AS


DELETE FROM COMPANY_CONTACT WHERE COMPANY_ID = @COMP_ID AND CONTACT_ID = @CONT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE DEL_CONT_CORR
(
	@CONT INT
) AS

delete from 
	document_recipients
where
	recipient = @cont
and	document_id in (select document_id from document_correspondence d, correspondence c where d.correspondence_id = c.correspondence_id and c.target = 2)

delete from company_contact where contact_id = @cont

delete from contacts where contact_id = @cont






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE DEL_OBJCONT
(
	@CONT_ID INT,
	@PROP_ID NUMERIC(18)
) AS


DELETE FROM OBJECT_CONTACT_TYPE WHERE OBJECT_ID = @PROP_ID AND CONTACT_ID = @CONT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE FIND_COMPANIES
(
	@SEARCH VARCHAR(250)
)AS


CREATE TABLE #RES
	(COMP_ID INT,
	COMP_DETS VARCHAR(4000))

INSERT INTO #RES
	SELECT 0, 'No Company'

IF DATALENGTH(@SEARCH) > 0
BEGIN

	INSERT INTO #RES
		SELECT
			C.COMPANY_ID, 
			ISNULL(C.COMPANY_NAME,'') + ' ' +
			ISNULL(A.HOUSENAME,'') + ' ' +
			ISNULL(A.HOUSENUMBER,'') + ' ' +
			ISNULL(STREETNAME,'') + ' ' +
			ISNULL(ADDRESS4,'') + ' ' +
			ISNULL(ADDRESS5,'') + ' ' +
			ISNULL(POSTALCODE,'') + ' ' +
			ISNULL(CITY,'') + ' ' +
			ISNULL(COUNTY,'')	
		FROM 
			COMPANIES C,
			COMPANY_ADDRESS CA,
			ADDRESSES A
		WHERE
			C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		ORDER BY 
			C.COMPANY_NAME
END

SELECT * FROM #RES WHERE COMP_DETS LIKE '%' + @SEARCH +'%' OR COMP_ID = 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE FIND_PROPERTIES
(
	@SEARCH VARCHAR(250)
)AS


CREATE TABLE #RES
	(PROP_ID INT,
	PROP_DETS VARCHAR(4000))

INSERT INTO #RES
	SELECT 0, 'No Property'

IF DATALENGTH(@SEARCH) > 0
BEGIN

	INSERT INTO #RES
		SELECT
			OBJECT_ID, 
			ISNULL(OBJECT_NAME,'') + ' ' +
			ISNULL(HOUSENAME,'') + ' ' +
			ISNULL(HOUSENUMBER,'') + ' ' +
			ISNULL(STREETNAME,'') + ' ' +
			ISNULL(ADDRESS4,'') + ' ' +
			ISNULL(POSTALCODE,'') + ' ' +
			ISNULL(CITY,'') + ' ' +
			ISNULL(COUNTY,'')	
		FROM 
			OBJECTS
		ORDER BY 
			OBJECT_NAME
END

SELECT * FROM #RES WHERE PROP_DETS LIKE '%' + @SEARCH +'%' OR PROP_ID = 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_ACCOUNT_MANAGERS AS


SELECT employee_id from employees where active = 1 and accman = 1






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_ACTION
(
	@ACT_ID INT
) AS

SELECT
	DATE_ENTERED,
	STATUS_CODE,
	DESCRIPTION,
	ACTION_UNDERTAKEN,
	DESCRIPTION,
	ACCOUNTABLE,
	RESPONSIBLE,
	RECORD_MANAGER,
	SHOW_OWNER
FROM 
	COMPLAINT_HISTORY
WHERE
	ACTION_ID = @ACT_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_ACTIONS AS

SELECT * FROM COMPLAINT_ACTIONS ORDER BY DESCRIPTION

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ACTIVE_ROUTES AS

SELECT * FROM ROUTES WHERE ACTIVE = 1








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_ALL_OPEN_INCIDENTS
(
	@SORT INT
)AS


IF @SORT = 0
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,C.COMPLAINT_DATE,113) DESC
END
ELSE IF @SORT = 1
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY C.COMPLAINT_ID DESC
END
ELSE IF @SORT = 2
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE,
		U.TIME_TO_SOLUTION
	ORDER BY U.TIME_TO_SOLUTION ASC
END
ELSE IF @SORT = 3
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CS.DESCRIPTION ASC
END
ELSE IF @SORT = 4
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CA.DESCRIPTION DESC
END
ELSE IF @SORT = 5
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,CH.DATE_ENTERED,113) DESC
END
ELSE IF @SORT = 6
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CT.DESCRIPTION ASC
END
ELSE IF @SORT = 7
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,C.RESOLUTION_DATE,113) DESC
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ALL_PROPERTIES AS


SELECT OBJECT_ID, OBJECT_NAME FROM OBJECTS ORDER BY OBJECT_NAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO












CREATE PROCEDURE GET_ALL_RESOLVED_INCIDENTS
(
	@SORT INT
)AS


IF @SORT = 0
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,C.COMPLAINT_DATE,113) DESC
END
ELSE IF @SORT = 1
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY C.COMPLAINT_ID DESC
END
ELSE IF @SORT = 2
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE,
		U.TIME_TO_SOLUTION
	ORDER BY U.TIME_TO_SOLUTION ASC
END
ELSE IF @SORT = 3
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CS.DESCRIPTION ASC
END
ELSE IF @SORT = 4
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CA.DESCRIPTION DESC
END
ELSE IF @SORT = 5
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,CH.DATE_ENTERED,113) DESC
END
ELSE IF @SORT = 6
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CT.DESCRIPTION ASC
END
ELSE IF @SORT = 7
BEGIN
	SELECT 
		C.COMPLAINT_ID AS INC,
		C.COMPLAINT_DATE AS INC_DATE,
		U.DESCRIPTION AS URGENCY,	
		CA.DESCRIPTION AS ACT_DESC,
		CH.DATE_ENTERED AS ACT_DATE,
		CS.DESCRIPTION AS STATUS,
		CT.DESCRIPTION AS TYPE,
		C.RESOLUTION_DATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		COMPLAINT_ACTIONS CA
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 1
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID
	AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
	GROUP BY
		C.COMPLAINT_ID ,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		CA.DESCRIPTION,
		CH.DATE_ENTERED,
		CT.DESCRIPTION ,
		CS.DESCRIPTION,
		C.RESOLUTION_DATE
	ORDER BY CONVERT(SMALLDATETIME,C.RESOLUTION_DATE,113) DESC
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_AREAS AS

SELECT * FROM AREA









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_ATTACH
(
	@DOC_ID INT
) AS

SELECT * FROM CORRESPONDENCE_DOCUMENTS WHERE DOCUMENT_ID = @DOC_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_BINSPECTION_EMAIL
(
	@INSP_ID INT
) AS


DECLARE @CNT INT

SELECT
	@CNT = COUNT(*)
FROM
	OBJECT_CONTACT_TYPE OCT,
	OBJECT_CHECKS OC
WHERE
	OC.OBJECT_CHECK_ID = @INSP_ID
AND	OC.OBJECT_ID = OCT.OBJECT_ID
AND	OCT.CONTACT_TYPE = 10


IF @CNT = 0
BEGIN
	SELECT @CNT
END
ELSE
BEGIN
	SELECT 
		@CNT = COUNT(*)
	FROM	
		OBJECT_CHECKS OC,
		OBJECT_CONTACT_TYPE OCT,
		CONTACTS C
	WHERE
		OC.OBJECT_CHECK_ID = @INSP_ID
	AND	OC.OBJECT_ID = OCT.OBJECT_ID
	AND	OCT.CONTACT_TYPE = 10
	AND	OCT.CONTACT_ID = C.CONTACT_ID
	AND	C.DIRECT_EMAIL <> ''
	AND	C.DIRECT_EMAIL IS NOT NULL

	IF @CNT = 0
	BEGIN
		SELECT @CNT = 1
	END
	ELSE
	BEGIN
		SELECT @CNT = 2
	END
END

SELECT @CNT

SELECT 
	C.CONTACT_ID,
	C.DIRECT_EMAIL
FROM	
	OBJECT_CHECKS OC,
	OBJECT_CONTACT_TYPE OCT,
	CONTACTS C
WHERE
	OC.OBJECT_CHECK_ID = @INSP_ID
AND	OC.OBJECT_ID = OCT.OBJECT_ID
AND	OCT.CONTACT_TYPE = 10
AND	OCT.CONTACT_ID = C.CONTACT_ID
AND	C.DIRECT_EMAIL <> ''
AND	C.DIRECT_EMAIL IS NOT NULL




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE GET_CALLBACK_RECIPIENTS
(
	@CORR_ID INT
)
AS

CREATE TABLE #R
(	A VARCHAR(4000))

DECLARE @DATE SMALLDATETIME
DECLARE @REC_CNT INT
DECLARE @TARGET INT

SELECT @TARGET = TARGET, @DATE = CORRESPONDENCE_DATE FROM CORRESPONDENCE WHERE CORRESPONDENCE_ID = @CORR_ID
	
SELECT @REC_CNT = COUNT(*) FROM DOCUMENT_RECIPIENTS DR, DOCUMENT_CORRESPONDENCE DC WHERE DR.DOCUMENT_ID = DC.DOCUMENT_ID AND DC.CORRESPONDENCE_ID = @CORR_ID

INSERT INTO #R SELECT 'Bulk Correspondence sent on ' + CONVERT(VARCHAR(20), @DATE,103) + ' to ' + CONVERT(VARCHAR(5),@REC_CNT) + ' recipients'

IF @TARGET = 1
BEGIN
	INSERT INTO #R SELECT 'NAME,PROPERTY,EMAIL,DIRECT PHONE, MOBILE'
	
	INSERT INTO #R
	select 
	isnull(r.firstname,'no name') + ' ' + isnull(r.lastname, 'no name') + ',' + isnull(O.OBJECT_NAME,'') + ',' + isnull(R.PHONE,'') + ',' + isnull(R.PRIVATE_MOBILE,'')
from 
	document_correspondence dc,
	document_recipients dr,
	residents r,
	RESIDENT_OBJECT RO,
	OBJECTS O
where 
	correspondence_id = @corr_id
and	dr.document_id = dc.document_id
and	dr.recipient = r.resident_id
and	r.resident_id = ro.resident_id
--AND	RO.DATE_FROM < @DATE
--AND	(RO.DATE_TO > @DATE OR RO.DATE_TO IS NULL)
AND	RO.OBJECT_ID = O.OBJECT_ID
order by
	r.lastname
END
ELSE IF @TARGET = 2 OR @TARGET = 3
BEGIN
	INSERT INTO #R SELECT 'NAME,COMPANY,JOB TITLE,EMAIL,DIRECT PHONE, MOBILE'
	
	INSERT INTO #R
	select 
		isnull(c.firstname,'no name') + ' ' + isnull(c.lastname, 'no name')  + ',' + ISNULL(CO.COMPANY_NAME,'') + ',' + ISNULL(C.JOB_TITLE,'') + ',' + ISNULL(DIRECT_EMAIL,'') + ',' + ISNULL(DIRECT_PHONE,'') + ',' + ISNULL(MOBILE_PHONE,'')
	from 
		document_correspondence dc,
		document_recipients dr,
		contacts c,
		COMPANIES CO
	where 
		correspondence_id = @CORR_ID
	and	dr.document_id = dc.document_id
	and	dr.recipient = c.contact_id
	AND	C.COMPANY_ID = CO.COMPANY_ID
	order by
		c.lastname
END

SELECT * FROM #R




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_COMPANIES
(
	@SEARCH varchar(50),
	@crit varchar(50)
) AS

DECLARE @SQL VARCHAR(4000)
DECLARE @SQL1 VARCHAR(4000)

IF @SEARCH = 'POSTALCODE' OR @SEARCH = 'CITY' OR @SEARCH = 'COUNTY'
BEGIN
	SELECT @SQL = 'select
				c.company_id,
				c.company_name,
				c.company_name as company_namei,
				ct.description,
				rtrim(isnull(a.housename,'''')) + '' '' + rtrim(isnull(a.housenumber,'''')) + '' '' + rtrim(isnull(a.streetname,'''')) as address
			from 
				addresses a,
				companies c,
				company_address ca,
				company_types ct
			where 
				a.address_id = ca.address_id
			and	c.company_id = ca.company_id
			and	ca.address_id = a.address_id
			and	c.company_type *= ct.company_type_id
			and       a.' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			AND	C.COMPANY_ID <> 0
			AND	CA.ADDRESS_TYPE = 1
			ORDER BY
				C.COMPANY_NAME'
END
ELSE IF @SEARCH = 'CONTACT_NAME'
BEGIN
	SELECT @SQL = 'select
				c.company_id,
				c.company_name,
				c.company_name as company_namei,
				ct.description,
				rtrim(isnull(a.housename,'''')) + '' '' + rtrim(isnull(a.housenumber,'''')) + '' '' + rtrim(isnull(a.streetname,'''')) as address
			from 
				addresses a,
				companies c,
				company_address ca,
				company_types ct,
				compaNy_contact cc,
				contacts co
			where 
				a.address_id = ca.address_id
			and	c.company_id = ca.company_id
			and	ca.address_id = a.address_id
			and	c.company_type *= ct.company_type_id
			and 	c.company_id = cc.company_id
			and	cc.contact_id = co.contact_id
			and       CO.FIRSTNAME + '' '' + CO.LASTNAME LIKE ''%' + @CRIT + '%''
			AND	C.COMPANY_ID <> 0
			AND	CA.ADDRESS_TYPE = 1
			ORDER BY
				C.COMPANY_NAME'
END
ELSE IF @SEARCH = 'COMPANY_NAME'
BEGIN
	SELECT @SQL = 'select
				c.company_id,
				c.company_name,
				c.company_name as company_namei,
				ct.description,
				rtrim(isnull(a.housename,'''')) + '' '' + rtrim(isnull(a.housenumber,'''')) + '' '' + rtrim(isnull(a.streetname,'''')) as address
			from 
				addresses a,
				companies c,
				company_address ca,
				company_types ct
			where 
				a.address_id = ca.address_id
			and	c.company_id = ca.company_id
			and	ca.address_id = a.address_id
			and	c.company_type *= ct.company_type_id
			and       C.' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			AND	C.COMPANY_ID <> 0
			AND	CA.ADDRESS_TYPE = 1
			ORDER BY
				C.COMPANY_NAME'
			
END
ELSE IF @SEARCH = 'DESCRIPTION'
BEGIN
	SELECT @SQL = 'select
				c.company_id,
				c.company_name,
				c.company_name as company_namei,
				ct.description,
				rtrim(isnull(a.housename,'''')) + '' '' + rtrim(isnull(a.housenumber,'''')) + '' '' + rtrim(isnull(a.streetname,'''')) as address
			from 
				addresses a,
				companies c,
				company_address ca,
				company_types ct,
				area ad
			where 
				a.address_id = ca.address_id
			and	c.company_id = ca.company_id
			and	ca.address_id = a.address_id
			and	c.company_type *= ct.company_type_id
			and 	a.area_id = ad.area_id
			and       ad.' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			AND	C.COMPANY_ID <> 0
			AND	CA.ADDRESS_TYPE = 1
			ORDER BY
				C.COMPANY_NAME'
END
ELSE IF @SEARCH = 'TYPE'
BEGIN
	SELECT @SQL = 'select
				c.company_id,
				c.company_name,
				c.company_name as company_namei,
				ct.description,
				rtrim(isnull(a.housename,'''')) + '' '' + rtrim(isnull(a.housenumber,'''')) + '' '' + rtrim(isnull(a.streetname,'''')) as address
			from 
				addresses a,
				companies c,
				company_address ca,
				company_types ct
			where 
				a.address_id = ca.address_id
			and	c.company_id = ca.company_id
			and	ca.address_id = a.address_id
			and	c.company_type = ct.company_type_id
			and       ct.description LIKE ''%' + @CRIT + '%''
			AND	C.COMPANY_ID <> 0
			AND	CA.ADDRESS_TYPE = 1
			ORDER BY
				C.COMPANY_NAME'
END

EXEC(@SQL)






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_COMPANY
(
	@COMP_ID INT
) AS

SELECT TOP 1
	ISNULL(C.COMPANY_NAME,'') AS COMPANY_NAME,
	ISNULL(A.HOUSENAME,'') AS HOUSENAME,
	ISNULL(A.STREETNAME,'') AS STREETNAME,
	ISNULL(A.ADDRESS4,'') AS ADDRESS4,
	ISNULL(A.ADDRESS5,'') AS ADDRESS5,
	ISNULL(A.CITY,'') AS CITY,
	ISNULL(A.COUNTY,'') AS COUNTY,
	ISNULL(A.POSTALCODE,'') AS POSTALCODE,
	ISNULL(A.COUNTRY,'') AS COUNTRY,
	ISNULL(A.AREA_ID,1) AS AREA_ID,
	ISNULL(C.ACCOUNT_MANAGER,22) AS ACCOUNT_MANAGER,
	ISNULL(C.SALES_MANAGER,22) AS SALES_MANAGER,
	ISNULL(C.STATUS_ID,1) AS STATUS_ID,
	CONVERT(VARCHAR(12),C.STATUS_EFFECTIVE,103) AS STATUS_EFFECTIVE,
	ISNULL(C.COMPANY_TYPE,'') AS COMPANY_TYPE,
	ISNULL(C.GENERAL_PHONE,'') AS GENERAL_PHONE,
	ISNULL(C.GENERAL_FAX,'') AS GENERAL_FAX,
	ISNULL(C.GENERAL_EMAIL,'') AS GENERAL_EMAIL,
	ISNULL(C.GENERAL_WEBSITE,'') AS GENERAL_WEBSITE,
	ISNULL(C.RECORD_MODIFIER,22) AS RECORD_MODIFIER,
	CONVERT(VARCHAR(12),ISNULL(C.DATE_MODIFIED,'1/1/04'),103) AS DATE_MODIFIED
FROM
	COMPANIES C,
	COMPANY_ADDRESS CA,
	ADDRESSES A
WHERE
	C.COMPANY_ID = @COMP_ID
AND	CA.COMPANY_ID = C.COMPANY_ID
AND	A.ADDRESS_ID = CA.ADDRESS_ID
AND	CA.ADDRESS_TYPE = 1
ORDER BY
	A.ADDRESS_ID DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_COMPANY_BANK
(
	@COMP_ID INT
) AS

SELECT 
	BD.SORTCODE,
	BD.ACCOUNTNUMBER,
	BD.ACCOUNTNAME,
	A.HOUSENUMBER,
	A.STREETNAME,
	A.ADDRESS4,
	A.CITY,
	A.POSTALCODE,
	A.COUNTY,
	CB.DEBIT_DAY
FROM 
	COMPANY_BANK CB,
	BANK_DETAILS BD,
	ADDRESSES A
WHERE
	CB.COMPANY_ID = @COMP_ID
AND	CB.BANKDETAIL_ID = BD.BANKDETAIL_ID
AND	BD.ADDRESS_ID = A.ADDRESS_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPANY_CONTACTS
(
	@COMP_ID INT
) AS

select 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME, 'No Null') AS CNAME,
	CT.JOB_TITLE AS DESCRIPTION,
	CT.DIRECT_PHONE AS PHONE,
	C.COMPANY_NAME,
	C.COMPANY_ID
from 
	COMPANIES C,
	CONTACTS CT
where 
	C.COMPANY_ID = @COMP_ID
AND	C.COMPANY_ID = CT.COMPANY_ID
AND	CT.CONTACT_ID IN (SELECT CONTACT_ID FROM COMPANY_CONTACT WHERE COMPANY_ID = @COMP_ID GROUP BY CONTACT_ID)
AND	CT.DATE_ENDED IS NULL
ORDER BY 
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME, 'No Null')






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPANY_CONTACTS_COMPLAINTS
(
	@COMP_ID INT
) AS

select 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'') + ' ' + ISNULL(CT.LASTNAME,'') AS CNAME
from 
	COMPANIES C,
	CONTACTS CT,
	CONTACT_TYPES CCT,
	COMPANY_CONTACT CC
where 
	C.COMPANY_ID = @COMP_ID
AND 	C.COMPANY_ID = CC.COMPANY_ID
AND	C.COMPANY_ID = CT.COMPANY_ID
AND	CC.CONTACT_ID = CT.CONTACT_ID
AND	CC.CONTACT_TYPE *= CCT.CONTACT_TYPE
AND	CT.DATE_ENDED IS NULL
ORDER BY 
	CT.LASTNAME, CT.FIRSTNAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_COMPANY_CONTACTS_CORR
(
	@COMP_ID INT
) AS

select 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME, 'No Null') AS CNAME
from 
	COMPANIES C,
	CONTACTS CT
where 
	C.COMPANY_ID = @COMP_ID
AND	C.COMPANY_ID = CT.COMPANY_ID
AND	CT.CONTACT_ID IN (SELECT CONTACT_ID FROM COMPANY_CONTACT WHERE COMPANY_ID = @COMP_ID GROUP BY CONTACT_ID)
AND	CT.DATE_ENDED IS NULL
ORDER BY 
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME, 'No Null')






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPANY_CORR
(
	@COMP_ID INT
) AS


CREATE TABLE #R
(	CORR_ID INT,
	C_DATE SMALLDATETIME,
	TYPE VARCHAR(50),
	TARGET VARCHAR(20),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(200),
	DOCUMENT VARCHAR(200)
)

DECLARE @CORR INT
DECLARE @TP VARCHAR(200)
DECLARE @TGT VARCHAR(50)

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE 'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD,
	DOCUMENT_RECIPIENTS DR,
	CONTACTS CS
WHERE
	C.C_TYPE = CT.TYPE_ID
AND	C.TARGET = RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
AND	DR.RECIPIENT IN (SELECT CONTACT_ID FROM COMPANY_CONTACT WHERE COMPANY_ID = @COMP_ID)
AND	DR.RECIPIENT = CS.CONTACT_ID
AND	C.DIRECTION = 1
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC


INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	ISNULL(DT.DESCRIPTION,''),
	'Camelot',
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE 'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	DOCUMENT_TYPES DT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD,
	DOCUMENT_RECIPIENTS DR,
	EMPLOYEES E
WHERE
	C.COMPANY_ID = @COMP_ID
AND	CD.TYPE_ID *= DT.DOCUMENT_TYPE
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
AND	DR.RECIPIENT = E.EMPLOYEE_ID
AND	C.DIRECTION = 0
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	DT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC


INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CE.SUBJECT
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	EMAIL_CORRESPONDENCE EC,
	EMAIL_DOCUMENTS ED,
	EMAIL_RECIPIENTS ER,
	CORRESPONDENCE_EMAIL CE
WHERE
	C.C_TYPE *= CT.TYPE_ID
AND	C.TARGET *= RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = EC.CORR_ID
AND	EC.EMAIL_ID *= ED.EMAIL_ID
AND	EC.EMAIL_ID = ER.EMAIL_ID
AND	ER.RECIPIENT IN (SELECT CONTACT_ID FROM COMPANY_CONTACT WHERE COMPANY_ID = @COMP_ID)
AND	EC.EMAIL_ID = CE.EMAIL_ID
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CE.SUBJECT
ORDER BY
	C.CORRESPONDENCE_DATE DESC


DECLARE NBS CURSOR FOR
	SELECT 
		CORR_ID,
		TYPE,
		TARGET
	FROM 
		#R
	WHERE
		[BULK] = 'NO'
	AND	DIR = 'Sent'

OPEN NBS

FETCH NEXT FROM NBS INTO @CORR, @TP,@TGT

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @TGT = 'GUARDIAN'
	BEGIN
		IF @TP NOT LIKE '%EMAIL%'
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME,'No Name')
			FROM
				#R,
				DOCUMENT_CORRESPONDENCE DC,
				DOCUMENT_RECIPIENTS DR,
				RESIDENTS R
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
			AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
			AND	DR.RECIPIENT = R.RESIDENT_ID
		END
		ELSE
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME,'No Name')
			FROM
				#R,
				EMAIL_CORRESPONDENCE EC,
				EMAIL_RECIPIENTS ER,
				RESIDENTS R
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = EC.CORR_ID
			AND	EC.EMAIL_ID = ER.EMAIL_ID
			AND	ER.RECIPIENT = R.RESIDENT_ID
		END
	END
	ELSE IF @TGT = 'CONTACT'
	BEGIN
		IF @TP NOT LIKE '%EMAIL%'
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(C.FIRSTNAME,'No Name') + ' ' + ISNULL(C.LASTNAME,'No Name')
			FROM
				#R,
				DOCUMENT_CORRESPONDENCE DC,
				DOCUMENT_RECIPIENTS DR,
				CONTACTS C
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
			AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
			AND	DR.RECIPIENT = C.CONTACT_ID
		END
		ELSE
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(C.FIRSTNAME,'No Name') + ' ' + ISNULL(C.LASTNAME,'No Name')
			FROM
				#R,
				EMAIL_CORRESPONDENCE EC,
				EMAIL_RECIPIENTS ER,
				CONTACTS C
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = EC.CORR_ID
			AND	EC.EMAIL_ID = ER.EMAIL_ID
			AND	ER.RECIPIENT = C.CONTACT_ID
		END		
	END
	ELSE IF @TGT = 'CAMELOT'
	BEGIN
		UPDATE 
			#R
		SET
			[BULK] = ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name')
		FROM
			#R,
			DOCUMENT_CORRESPONDENCE DC,
			DOCUMENT_RECIPIENTS DR,
			EMPLOYEES E
		WHERE
			#R.CORR_ID = @CORR
		AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
		AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
		AND	DR.RECIPIENT = E.EMPLOYEE_ID
	END
	
	FETCH NEXT FROM NBS INTO @CORR, @TP,@TGT


END

CLOSE NBS
DEALLOCATE NBS

DECLARE NBE CURSOR FOR
	SELECT 
		CORR_ID,
		TYPE,
		TARGET
	FROM 
		#R
	WHERE
		[BULK] = 'NO'
	AND	DIR <> 'Sent'

OPEN NBE

FETCH NEXT FROM NBE INTO @CORR, @TP,@TGT

WHILE @@FETCH_STATUS = 0
BEGIN
	UPDATE 
		#R
	SET
		[BULK] = ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name')
	FROM
		#R,
		DOCUMENT_CORRESPONDENCE DC,
		DOCUMENT_RECIPIENTS DR,
		EMPLOYEES E
	WHERE
		#R.CORR_ID = @CORR
	AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
	AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
	AND	DR.RECIPIENT = E.EMPLOYEE_ID
	
	FETCH NEXT FROM NBE INTO @CORR, @TP,@TGT
END

CLOSE NBE
DEALLOCATE NBE



SELECT * FROM #R ORDER BY C_DATE



--SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPANY_NOTE
(
	@NOTE_ID INT
) AS


SELECT
	N.ACTIVITY_ID AS NOTE_ID, 
	CONVERT(VARCHAR(12),N.ACTIVITY_DATE,103)  AS DATE,
	N.REGARDING AS DESCRIPTION,
	N.CONTACT_ID,
	N.SAVED_IN_OUTLOOK,
	N.RECORD_MANAGER,
	N.IN_INSP,
	CONVERT(VARCHAR(12),N.DATE_ENTERED,103) AS DATE_ENTERED
FROM 
	NOTES N 
WHERE 
	N.ACTIVITY_ID = @NOTE_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPANY_NOTES
(
	@COMP_ID INT
) AS


SELECT
	N.ACTIVITY_ID AS NOTE_ID, 
	N.DATE_ENTERED AS DATE,
	SUBSTRING(N.REGARDING,1,200) + ' ...' AS DESCRIPTION,
	C.FIRSTNAME + ' ' + C.LASTNAME AS CONTACT,
	E.FIRSTNAME + ' ' + E.LASTNAME AS ACCOUNT_MANAGER,
	CASE SAVED_IN_OUTLOOK
		WHEN 0 THEN 'No'
		ELSE 'Yes'
	END AS OUTLOOK
FROM 
	NOTES N,
	CONTACTS C,
	EMPLOYEES E 
WHERE 
	N.COMPANY_ID = @COMP_ID
AND	N.CONTACT_ID = C.CONTACT_ID
AND	N.RECORD_MANAGER = E.EMPLOYEE_ID
ORDER BY
	N.ACTIVITY_DATE DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_COMPANY_PROPERTIES
(
	@COMP_ID INT
) AS
	SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.HOUSENAME,'') + ' ' + 	ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE,'')) AS ADDRESS,
		E.FIRSTNAME + ' ' + E.LASTNAME AS PROPERTY_MANAGER,
		OS.STATUS_DESCRIPTION
	FROM 
		OBJECTS O,
		OBJECT_STATUS OS,
		COMPANIES CO,
		COMPANY_OBJECT OP,
		EMPLOYEES E
	WHERE
		O.OBJECT_ID = OP.OBJECT_ID
	AND 	OP.COMPANY_ID = CO.COMPANY_ID
	AND	O.STATUS_ID *= OS.STATUS_ID
	AND	E.EMPLOYEE_ID =* O.PROPERTY_MANAGER
	AND	CO.COMPANY_ID = @COMP_ID
	AND	OP.DATE_FROM < GETDATE()
	AND	(OP.DATE_TO > GETDATE() OR OP.DATE_TO IS NULL)
	ORDER BY
		O.OBJECT_NAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPLAINT_CONTACT
(
	@CONT_ID INT
) AS


SELECT
	C.DIRECT_PHONE AS PHONE,
	C.PHONE AS WKPHONE,
	C.MOBILE_PHONE AS MOBILE,
	C.EMAIL
FROM
	CONTACTS C
WHERE
	CONTACT_ID = @CONT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPLAINT_EMPLOYEE
(
	@EMP_ID INT
) AS


SELECT
	E.EMAIL
FROM
	EMPLOYEES E
WHERE
	EMPLOYEE_ID = @EMP_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPLAINT_GUARDIAN
(
	@GUARD_ID INT
) AS


SELECT
	R.PRIVATE_PHONE AS DIRECT_PHONE,
	R.PHONE AS WKPHONE,
	R.MOBILE AS MOBILE,
	R.EMAIL
FROM
	RESIDENTS R
WHERE
	RESIDENT_ID = @GUARD_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMPLAINT_TYPES AS

SELECT * FROM COMPLAINT_TYPES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMP_CORR_RECIPIENTS
(
	@COMP_ID INT,
	@GCORR INT
) AS


IF @GCORR = 2
BEGIN
	SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
		CS.JOB_TITLE
	FROM
		CONTACTS CS,
		COMPANY_CONTACT CC,
		COMPANIES C
	WHERE
		C.COMPANY_ID = @COMP_ID
	AND	CS.CONTACT_ID = CC.CONTACT_ID
	AND	CC.COMPANY_ID = C.COMPANY_ID
	ORDER BY
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
END
ELSE
BEGIN		
	SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
		CS.JOB_TITLE
	FROM
		CONTACTS CS,
		COMPANY_CONTACT CC,
		COMPANIES C
	WHERE
		C.COMPANY_ID = @COMP_ID
	AND	CS.CONTACT_ID = CC.CONTACT_ID
	AND	CC.COMPANY_ID = C.COMPANY_ID
	AND	CS.DIRECT_EMAIL IS NOT NULL
	ORDER BY
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMP_STATS AS

SELECT * FROM COMPANY_STATUS









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_COMP_TYPES AS

SELECT * FROM COMPANY_TYPES









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO












CREATE PROCEDURE GET_CONTACT
(
	@CONT_ID INT,
	@COMP_ID NUMERIC(18)
) AS

SELECT @COMP_ID = COMPANY_ID FROM CONTACTS WHERE CONTACT_ID = @CONT_ID

SELECT
	C.CONTACT_STATUS_ID AS STATUS_ID,
	CONVERT(VARCHAR(12),C.STAT_EFF,103) AS STAT_EFF,
	ISNULL(C.FIRSTNAME,'') + ' '  + ISNULL(LASTNAME,'') AS CONTACT,
	C.TITLE,
	C.FIRSTNAME,
	C.INITIALS,
	c.prefix,
	C.SALUTATION,
	C.LASTNAME,
	C.DIRECT_PHONE AS WKTEL,
	C.DIRECT_FAX AS FAX,
	C.MOBILE_PHONE AS MOBILE,
	C.DIRECT_EMAIL AS EMAIL,
	C.JOB_TITLE,
	C.RECIEVE_MAIL,
	C.NOTES,
	C.RECORD_MODIFIER,
	CONVERT(VARCHAR(12),C.DATE_MODIFIED,103) AS DATE_MODIFIED,
	C.COMPANY_ID,
	CO.COMPANY_NAME
FROM
	CONTACTS C,
	COMPANIES CO
WHERE
	CONTACT_ID = @CONT_ID
AND	CO.COMPANY_ID = C.COMPANY_ID

SELECT CONTACT_TYPE FROM COMPANY_CONTACT WHERE CONTACT_ID = @CONT_ID AND COMPANY_ID = @COMP_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_CONTACT_CORR
(
	@CONT_ID INT
) AS

CREATE TABLE #R
(	CORR_ID INT,
	C_DATE SMALLDATETIME,
	TYPE VARCHAR(50),
	TARGET VARCHAR(50),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(3),
	DOCUMENT VARCHAR(200)
)

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD,
	DOCUMENT_RECIPIENTS DR
WHERE
	C.C_TYPE = CT.TYPE_ID
AND	C.TARGET = RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
AND	DR.RECIPIENT IN (SELECT @CONT_ID)
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC


INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CE.SUBJECT
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	EMAIL_CORRESPONDENCE EC,
	EMAIL_DOCUMENTS ED,
	EMAIL_RECIPIENTS ER,
	CORRESPONDENCE_EMAIL CE
WHERE
	C.C_TYPE *= CT.TYPE_ID
AND	C.TARGET *= RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = EC.CORR_ID
AND	EC.EMAIL_ID *= ED.EMAIL_ID
AND	EC.EMAIL_ID = ER.EMAIL_ID
AND	ER.RECIPIENT IN (SELECT @CONT_ID)
AND	EC.EMAIL_ID = CE.EMAIL_ID
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CE.SUBJECT
ORDER BY
	C.CORRESPONDENCE_DATE DESC


SELECT * FROM #R ORDER BY C_DATE




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_CONTACT_EMAIL
(
	@CONT_ID INT
) AS

SELECT DIRECT_EMAIL FROM CONTACTS WHERE CONTACT_ID = @CONT_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_CONTTYPES AS

SELECT * FROM CONTACT_TYPES ORDER BY CONTACT_TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_CONT_CORR_RECIPIENTS
(
	@CONT_ID INT,
	@GCORR INT
) AS


IF @GCORR = 2
BEGIN
	SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
		CS.JOB_TITLE
	FROM
		CONTACTS CS
	WHERE
		CS.CONTACT_ID = @CONT_ID
	ORDER BY
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
END
ELSE
BEGIN		
	SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
		CS.JOB_TITLE
	FROM
		CONTACTS CS
	WHERE
		CS.CONTACT_ID = @CONT_ID
	ORDER BY
		ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_CONT_STATS AS

SELECT * FROM CONTACT_STATUS









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_CORR
(
	@CORR_ID INT
) AS

CREATE TABLE #R
(	CORR_ID INT,
	C_DATE VARCHAR(20),
	TYPE VARCHAR(50),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(3),
	DOCUMENT VARCHAR(500),
	DOCO IMAGE,
	FILESIZE INT
)

DECLARE @TARGET  INT

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	CONVERT(VARCHAR(20),C.CORRESPONDENCE_DATE,103),
	CT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CD.FILENAME,
	CD.MERGE_FILE,
	CD.FILESIZE
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD
WHERE
	C.CORRESPONDENCE_ID = @CORR_ID
AND	C.C_TYPE = CT.TYPE_ID
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	C.DIRECTION = 1


INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	CONVERT(VARCHAR(20),C.CORRESPONDENCE_DATE,103),
	DT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CD.FILENAME,
	CD.MERGE_FILE,
	CD.FILESIZE
FROM
	CORRESPONDENCE C,
	DOCUMENT_TYPES DT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD
WHERE
	C.CORRESPONDENCE_ID = @CORR_ID
AND	C.C_TYPE *= DT.DOCUMENT_TYPE
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	C.DIRECTION = 0


SELECT * FROM #R

SELECT @TARGET = TARGET FROM CORRESPONDENCE WHERE CORRESPONDENCE_ID = @CORR_ID

IF @TARGET = 1
BEGIN
	select 
	isnull(r.firstname,'no name') + ' ' + isnull(r.lastname, 'no name') as name 
from 
	document_correspondence dc,
	document_recipients dr,
	residents r
where 
	correspondence_id = @corr_id
and	dr.document_id = dc.document_id
and	dr.recipient = r.resident_id
order by
	r.lastname
END
ELSE IF @TARGET = 2
BEGIN
	select 
		isnull(c.firstname,'no name') + ' ' + isnull(c.lastname, 'no name') as name 
	from 
		document_correspondence dc,
		document_recipients dr,
		contacts c
	where 
		correspondence_id = @CORR_ID
	and	dr.document_id = dc.document_id
	and	dr.recipient = c.contact_id
	order by
		c.lastname
END
ELSE IF @TARGET = 3
BEGIN
	select 
		isnull(e.firstname,'no name') + ' ' + isnull(e.lastname, 'no name') as name 
	from 
		document_correspondence dc,
		document_recipients dr,
		employees e
	where 
		correspondence_id = @CORR_ID
	and	dr.document_id = dc.document_id
	and	Dr.recipient = e.employee_id
	order by
		E.lastname
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_CORR_RECIPIENTS
(
	@TARGET INT = 0,
	@AREA VARCHAR(1000),
	@PSTATUS VARCHAR(1000),
	@PTYPE VARCHAR(1000),
	@CTYPE VARCHAR(1000),
	@GSTAT INT,
	@PROP VARCHAR(1000),
	@ROUTE VARCHAR(1000),
	@POST VARCHAR(2000),
	@TOWN VARCHAR(2000),
	@CORR CHAR(1)
) AS

DECLARE @SQL VARCHAR(4000)
DECLARE @GSQL VARCHAR(1000)
DECLARE @GCORR VARCHAR(1000)

SELECT @GCORR = ''

IF @PSTATUS = '0'
BEGIN
	SELECT @PSTATUS = 'AND O.STATUS_ID IN(SELECT STATUS_ID FROM OBJECT_STATUS)'
END

IF @PTYPE = '0'
BEGIN
	SELECT @PTYPE = 'AND O.OBJECT_TYPE IN(SELECT OBJECT_TYPE_ID FROM OBJECT_TYPES)'
END

IF @CTYPE = '0'
BEGIN
	SELECT @CTYPE = 'AND C.COMPANY_TYPE IN(SELECT COMPANY_TYPE_ID FROM COMPANY_TYPES)'
END

IF @GSTAT = '0'
BEGIN
	SELECT @GSQL = 'AND DATE_TO = ''01/01/1900'''
END
ELSE IF @GSTAT=1
BEGIN
	SELECT @GSQL ='AND DATE_TO > ''01/01/1900'''
END
ELSE
BEGIN
	SELECT @GSQL = ''
END

IF @PROP = '0'
BEGIN
	SELECT @PROP = 'AND O.OBJECT_ID IN(SELECT OBJECT_ID FROM OBJECTS)'
END

IF @ROUTE = '0'
BEGIN
	SELECT @ROUTE = 'AND RT.ROUTE_ID IN(SELECT ROUTE_ID FROM ROUTES)'
END


IF @TARGET = 0
BEGIN
	IF @AREA = '0'
	BEGIN
		SELECT @AREA = 'AND A.AREA_ID IN(SELECT AREA_ID FROM AREA)'
	END

	IF @CORR <> '2'
	BEGIN
		SELECT @GCORR = 'AND DBO.VALIDATE_EMAIL(CS.DIRECT_EMAIL)=1'	
	END

	SELECT @SQL = 'SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'''') + '' '' + ISNULL(CS.LASTNAME,'''') AS NAME,
		C.COMPANY_NAME,
		CS.JOB_TITLE,
		ISNULL(A.HOUSENAME,'''') + '' '' + ISNULL(A.STREETNAME,'''') + '' '' + ISNULL(A.ADDRESS4,'''') + '' ''  + ISNULL(A.ADDRESS5,'''') + '' '' + ISNULL(A.CITY,'''') AS ADDRESS
	FROM
		CONTACTS CS,
		COMPANY_ADDRESS CA,
		ADDRESSES A,
		COMPANY_CONTACT CC,
		COMPANIES C,
		COMPANY_OBJECT CO,
		OBJECTS O
	WHERE
		CS.CONTACT_ID = CC.CONTACT_ID
	AND	CC.COMPANY_ID = C.COMPANY_ID
	AND	C.COMPANY_ID = CA.COMPANY_ID
	AND	CA.ADDRESS_ID = A.ADDRESS_ID
	AND   	C.COMPANY_ID IN (SELECT COMPANY_ID FROM COMPANY_OBJECT GROUP BY COMPANY_ID)
	AND	C.COMPANY_ID = CO.COMPANY_ID
	AND	CO.OBJECT_ID = O.OBJECT_ID
	' + @AREA + @PSTATUS + @PTYPE + @CTYPE + @POST + @TOWN + '
	ORDER BY
		ISNULL(CS.FIRSTNAME,'''') + '' '' + ISNULL(CS.LASTNAME,'''')'
		
END
ELSE IF @TARGET = 1
BEGIN

	IF @AREA = '0'
	BEGIN
		SELECT @AREA = 'AND O.AREA_ID IN(SELECT AREA_ID FROM AREA)'
	END
	
	IF @CORR <> '2'
	BEGIN
		SELECT @GCORR = 'AND DBO.VALIDATE_EMAIL(R.PRIVATE_EMAIL) =1'	
	END

	
	SELECT @SQL = 'select 
		r.resident_id,
		R.PRIVATE_EMAIL AS EMAIL,
		isnull(r.firstname,'''') + '' '' + isnull(r.lastname,'''') as name,
		convert(varchar(20),ro.date_from, 103) as date_from,	
		case convert(varchar(20),ro.date_to,103)
			when ''01/01/1900'' then ''''
			else convert(varchar(20),ro.date_to,103)
		end as date_to,
		o.object_name as property,
		CASE RO.MAIN_RESIDENT
				WHEN 1 THEN ''YES''
				ELSE ''NO''
			END AS HEAD,
		ro.room
	from 
		residents r, resident_object ro, objects o, OBJECT_ROUTE RT
	where 
	 	r.resident_id = ro.resident_id
	and	r.firstname is not null
	and	r.lastname is not null
	and	ro.date_from < getdate()
	and	(ro.date_to = ''01/01/1900'' or (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))
	AND	O.OBJECT_ID = RO.OBJECT_ID
	AND 	O.OBJECT_ID  *= rt.OBJECT_ID '+ @GSQL + @AREA + @ROUTE + @PROP + @POST + @TOWN + @GCORR + ' 
	GROUP BY
		R.RESIDENT_ID,
		R.PRIVATE_EMAIL,
		isnull(r.firstname,'''') + '' '' + isnull(r.lastname,''''),
		ro.date_from,
		ro.date_to,
		o.object_name,
		RO.MAIN_RESIDENT,
		ro.room'
END
ELSE IF @TARGET = 3
BEGIN
	IF @AREA = '0'
	BEGIN
		SELECT @AREA = 'AND A.AREA_ID IN(SELECT AREA_ID FROM AREA)'
	END

	IF @CORR <> '2'
	BEGIN
		SELECT @GCORR = 'AND DBO.VALIDATE_EMAIL(CS.DIRECT_EMAIL)=1'	
	END

	SELECT @SQL = 'SELECT DISTINCT
		CS.CONTACT_ID,
		CS.DIRECT_EMAIL AS EMAIL,
		ISNULL(CS.FIRSTNAME,'''') + '' '' + ISNULL(CS.LASTNAME,'''') AS NAME,
		C.COMPANY_NAME,
		CS.JOB_TITLE,
		ISNULL(A.HOUSENAME,'''') + '' '' + ISNULL(A.STREETNAME,'''') + '' '' + ISNULL(A.ADDRESS4,'''') + '' ''  + ISNULL(A.ADDRESS5,'''') + '' '' + ISNULL(A.CITY,'''') AS ADDRESS
	FROM
		CONTACTS CS,
		COMPANY_ADDRESS CA,
		ADDRESSES A,
		COMPANY_CONTACT CC,
		COMPANIES C
	WHERE
		CS.CONTACT_ID = CC.CONTACT_ID
	AND	CC.COMPANY_ID = C.COMPANY_ID
	AND	C.COMPANY_ID = CA.COMPANY_ID
	AND	CA.ADDRESS_ID = A.ADDRESS_ID
	' + @AREA + @CTYPE + @POST + @TOWN + @GCORR + '
	ORDER BY
		ISNULL(CS.FIRSTNAME,'''') + '' '' + ISNULL(CS.LASTNAME,'''')'
		
END


EXEC(@SQL)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_CURRENT_PROPERTY_RESIDENTS
(
	@PROP_ID INT
) AS

select 
	RO.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'No Name') + '  ' + ISNULL(LASTNAME,'No Name') AS NAME,
	CASE DATE_FROM
		WHEN 01/01/1900 THEN NULL
		ELSE DATE_FROM
	END AS DATE,
	CASE MAIN_RESIDENT
		WHEN 0 THEN 'No'
		ELSE 'Yes'
	END AS HEAD,
	ROOM
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROP_ID
and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME ASC







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_DEFAULT_PRINTER AS



SELECT KEY_VALUE FROM APP_DEFS WHERE KEY_NAME = 'PRINTER'








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_DEF_PHOTOS
(
	@P_ID NUMERIC,
	@TYPE INT
) AS

SELECT 
	P.FILESIZE,
	P.PHOTO,
	P.FILENAME
FROM 
	PHOTOS P 
WHERE 
	P.PARENT = @P_ID 
AND 	P.IS_DEFAULT <> 0
AND	P.PHOTO_TYPE_ID = @TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_DOCUMENTS AS

SELECT
	DOC_ID,
	DOC_LIST_NAME
FROM
	MERGE_DOCUMENTS
ORDER BY
	DOC_LIST_NAME







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_DOCUMENT_TYPES AS

SELECT * FROM DOCUMENT_TYPES
ORDER BY DESCRIPTION







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE GET_ECALLBACK_RECIPIENTS
(
	@CORR_ID INT 
)AS


CREATE TABLE #R
(	A VARCHAR(4000))

DECLARE @DATE SMALLDATETIME
DECLARE @REC_CNT INT
DECLARE @TARGET INT

SELECT @TARGET = TARGET, @DATE = CORRESPONDENCE_DATE FROM CORRESPONDENCE WHERE CORRESPONDENCE_ID = @CORR_ID
	
SELECT @REC_CNT = COUNT(*) FROM DOCUMENT_RECIPIENTS DR, DOCUMENT_CORRESPONDENCE DC WHERE DR.DOCUMENT_ID = DC.DOCUMENT_ID AND DC.CORRESPONDENCE_ID = @CORR_ID

INSERT INTO #R SELECT 'Bulk Correspondence sent on ' + CONVERT(VARCHAR(20), @DATE,103) + ' to ' + CONVERT(VARCHAR(5),@REC_CNT) + ' recipients'

IF @TARGET = 1
BEGIN
	INSERT INTO #R SELECT 'NAME,PROPERTY,EMAIL,DIRECT PHONE, MOBILE'
	
	INSERT INTO #R
	select 
	isnull(r.firstname,'no name') + ' ' + isnull(r.lastname, 'no name') + ',' + isnull(O.OBJECT_NAME,'') + ',' + isnull(R.PHONE,'') + ',' + isnull(R.PRIVATE_MOBILE,'')
from 
	EMAIL_correspondence Ec,
	EMAIL_recipients Er,
	residents r,
	RESIDENT_OBJECT RO,
	OBJECTS O
where 
	corr_id = @corr_id
and	Er.EMAIL_id = Ec.EMAIL_id
and	Er.recipient = r.resident_id
and	r.resident_id = ro.resident_id
AND	ER.TARGET_TYPE = 1
--AND	RO.DATE_FROM < @DATE
--AND	(RO.DATE_TO > @DATE OR RO.DATE_TO IS NULL)
AND	RO.OBJECT_ID = O.OBJECT_ID
order by
	r.lastname
END
ELSE IF @TARGET = 2 OR @TARGET = 3
BEGIN
	INSERT INTO #R SELECT 'NAME,COMPANY,JOB TITLE,EMAIL,DIRECT PHONE, MOBILE'
	
	INSERT INTO #R
	select 
		isnull(c.firstname,'no name') + ' ' + isnull(c.lastname, 'no name')  + ',' + ISNULL(CO.COMPANY_NAME,'') + ',' + ISNULL(C.JOB_TITLE,'') + ',' + ISNULL(DIRECT_EMAIL,'') + ',' + ISNULL(DIRECT_PHONE,'') + ',' + ISNULL(MOBILE_PHONE,'')
	from 
		EMAIL_correspondence Ec,
		EMAIL_recipients Er,
		contacts c,
		COMPANIES CO
	where 
		corr_id = @corr_id
	and	Er.EMAIL_id = Ec.EMAIL_id
	and	Er.recipient = c.contact_id
	AND	(ER.TARGET_TYPE = 1 OR ER.TARGET_TYPE = 3)
	AND	C.COMPANY_ID = CO.COMPANY_ID
	order by
		c.lastname
END
SELECT * FROM #R




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ECORR
(
	@CORR_ID INT
) AS

CREATE TABLE #R
(	CORR_ID INT,
	C_DATE VARCHAR(20),
	TYPE VARCHAR(50),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(3),
	SUBJECT VARCHAR(4000),
	BODY TEXT
)

CREATE TABLE #RR
(	NAME VARCHAR(500)
)

DECLARE @TARGET  INT

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	CONVERT(VARCHAR(20),C.CORRESPONDENCE_DATE,103),
	CT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CE.SUBJECT,
	CE.BODY
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	EMAIL_CORRESPONDENCE EC,
	CORRESPONDENCE_EMAIL CE
WHERE
	C.CORRESPONDENCE_ID = @CORR_ID
AND	C.C_TYPE = CT.TYPE_ID
AND	C.CORRESPONDENCE_ID = EC.CORR_ID
AND	EC.EMAIL_ID = CE.EMAIL_ID


SELECT * FROM #R

SELECT @TARGET = TARGET FROM CORRESPONDENCE WHERE CORRESPONDENCE_ID = @CORR_ID

INSERT INTO #RR
select 
	isnull(r.firstname,'no name') + ' ' + isnull(r.lastname, 'no name') as name 
from 
	EMAIL_correspondence Ec,
	EMAIL_recipients Er,
	residents r
where 
	corr_id = @corr_id
and	Er.EMAIL_id = Ec.EMAIL_id
and	Er.recipient = r.resident_id
AND	ER.TARGET_TYPE = 1
order by
	r.lastname

INSERT INTO #RR
select 
	isnull(c.firstname,'no name') + ' ' + isnull(c.lastname, 'no name') as name 
from 
	EMAIL_correspondence Ec,
	EMAIL_recipients Er,
	contacts c
where 
	corr_id = @CORR_ID
and	Er.EMAIL_id = EC.EMAIL_id
and	Er.recipient = c.contact_id
AND	ER.TARGET_TYPE = 3
order by
	c.lastname

INSERT INTO #RR
select 
	isnull(E.firstname,'no name') + ' ' + isnull(E.lastname, 'no name') as name 
from 
	EMAIL_correspondence Ec,
	EMAIL_recipients Er,
	EMPLOYEES E
where 
	corr_id = @CORR_ID
and	Er.EMAIL_id = EC.EMAIL_id
and	Er.recipient = E.EMPLOYEE_ID
AND	ER.TARGET_TYPE = 4
order by
	E.lastname

SELECT * FROM #RR


SELECT
	RECIPIENT AS NAME
FROM
	EMAIL_RECIPIENTS_NO_CRM ER,
	EMAIL_CORRESPONDENCE EC
WHERE
	ER.EMAIL_ID =  EC.email_id
AND	EC.CORR_ID = @CORR_ID


SELECT
	ED.DOC_ID AS DOC_ID,
	CD.FILENAME AS ATTACHMENT
FROM
	EMAIL_CORRESPONDENCE EC,
	EMAIL_DOCUMENTS ED,
	CORRESPONDENCE_DOCUMENTS CD
WHERE
	EC.CORR_ID = @CORR_ID
AND	EC.EMAIL_ID = ED.EMAIL_ID
AND	ED.DOC_ID = CD.DOCUMENT_ID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_EMAIL_COMPANIES AS


SELECT COMPANY_ID, COMPANY_NAME FROM COMPANIES ORDER BY COMPANY_NAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_EMAIL_CONTACT
(
	@CONT_ID INT
) AS


SELECT
	ISNULL(C.FIRSTNAME,'') + ' '  + ISNULL(LASTNAME,'') AS CONTACT,
	CO.COMPANY_NAME,
	C.COMPANY_ID
FROM
	CONTACTS C,
	COMPANIES CO
WHERE
	CONTACT_ID = @CONT_ID
AND	CO.COMPANY_ID = C.COMPANY_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_EMAIL_GUARD_PROPERTIES
(
	@G_ID VARCHAR(250)
) AS

SELECT
	O.OBJECT_NAME AS PROPERTY,
	O.OBJECT_ID AS PROP_ID
FROM 
	RESIDENTS  R,
	RESIDENT_OBJECT RO,
	OBJECTS O
WHERE 
	R.RESIDENT_ID = @G_ID
AND	R.RESIDENT_ID = RO.RESIDENT_ID
AND	RO.OBJECT_ID = O.OBJECT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_EMAIL_PROPERTIES
(
	@COMP_ID INT
) AS

SELECT
	O.OBJECT_ID AS PROP_ID,
	O.OBJECT_NAME AS PROP_NAME
FROM
	OBJECTS O,
	COMPANY_OBJECT CO
WHERE
	O.OBJECT_ID = CO.OBJECT_ID
AND	CO.COMPANY_ID = @COMP_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_EMAIL_RESIDENTS AS

SELECT
	R.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.LASTNAME,'') AS NAME,
	R.EMAIL
FROM 
	RESIDENTS  R
ORDER BY
	R.LASTNAME, R.FIRSTNAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_EMPLOYEES AS

SELECT 
	EMPLOYEE_ID,
	ISNULL(FIRSTNAME, 'No Name') + ' ' + ISNULL(LASTNAME, 'No Name') AS NAME,
	ISNULL(JOB_TITLE,'') AS JOB_TITLE,
	ACCMAN,
	DIRECT_PHONE,
	WORK_MOBILE,
	PRIVATE_MOBILE,
	EMAIL,
	PERMISSIONS,
	USERID,
	ACTIVE	
FROM EMPLOYEES where userid <> 'admin'
ORDER BY ACTIVE DESC, FIRSTNAME ASC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_FACILITIES
(
	@PROPID INT
) AS

SELECT
	F.FACILITY_ID AS FAC,
	FT.DESCRIPTION AS FACDESC,
	ISNULL(F.DESCRIPTION,'') AS ODESC,
	CASE DATE_LAST_CHECK
		WHEN 01/01/1900 THEN NULL
		ELSE DATE_LAST_CHECK
	END AS FCHECK,
	ISNULL(RTRIM(R.FIRSTNAME),'') + ' ' + ISNULL(RTRIM(R.LASTNAME),'') AS RES
FROM
	FACILITIES F,
	OBJECT_FACILITIES O,
	FACILITY_TYPES FT,
	RESIDENTS R
WHERE
	F.FACILITY_TYPE = FT.FACILITY_TYPE
AND	O.FACILITY_ID = F.FACILITY_ID
AND	F.RESIDENT_ID *= R.RESIDENT_ID
AND	O.OBJECT_ID = @PROPID
ORDER BY
	F.IN_USE DESC,
	F.DESCRIPTION ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_FACILITY
(
	@FAC_ID INT
) AS

SELECT
	FACILITY_TYPE,
	DESCRIPTION,
	LOCATION,
	SERIAL_NUMBER,
	CONVERT(varchar(12),DATE_INSTALLED,103) AS DATE_INSTALLED,
	CONVERT(varchar(12),DATE_REMOVED,103) AS DATE_REMOVED,
	CONVERT(varchar(12),DATE_LAST_CHECK,103) AS DATE_LAST_CHECK,
	CONVERT(varchar(12),DATE_NEXT_CHECK,103) AS DATE_NEXT_CHECK,
	MAINT_ID,
	REMARKS,
	RESIDENT_ID,
	RECORD_MANAGER,
	CONVERT(varchar(12),DATE_MODIFIED,103) AS DATE_MODIFIED,
	PHOTO_ID,
	ISNULL(IN_USE,1) AS IN_USE,
	ISNULL(IN_INSP,0) AS INSP
FROM
	FACILITIES
WHERE
	FACILITY_ID = @FAC_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_FACILITY_TYPES AS

SELECT * FROM FACILITY_TYPES









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_GUARDIAN
(
	@GUARD_ID INT,
	@PROP_ID INT
)AS

SELECT
	ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.LASTNAME,'') AS GUARDIAN,
	R.TITLE,
	R.FIRSTNAME,
	R.INITIALS,
	R.LASTNAME,
	R.SALUTATION,
	R.PREFIX,
	CASE R.BIRTH_DATE
		WHEN 01/01/1900 THEN NULL
		ELSE CONVERT(VARCHAR(12),R.BIRTH_DATE,103)
	END AS DOB,
	R.NATIONALITY,
	R.GENDER,
	R.PRIVATE_PHONE,
	R.PHONE,
	R.PARENT_PHONE,
	R.MOBILE,
	R.PRIVATE_MOBILE,
	R.PARENT_MOBILE,
	R.FAX,
	R.EMAIL,
	R.PRIVATE_EMAIL,
	R.PARENT_EMAIL,
	R.RESIDENT_STATUS_ID,
	CASE R.STAT_EFF
		WHEN 01/01/1900 THEN NULL
		ELSE CONVERT(VARCHAR(12),R.STAT_EFF,103)
	END AS STAT_EFF,
	R.RECORD_MANAGER,
	ISNULL(R.MAIL_VIA_POST,0) AS CPOST,
	ISNULL(R.MAIL_VIA_EMAIL,0) AS CEMAIL,
	ISNULL(R.MAIL_VIA_FAX,0) AS CFAX,
	R.RENT,
	CASE R.RENT_BREAK
		WHEN '1/1/1900' THEN ''
		ELSE CONVERT(VARCHAR(12),R.RENT_BREAK,103) 
		END AS RENT_BREAK,
	R.BREAK_REASON,
	CASE R.FIREPACK
		WHEN '1/1/1900' THEN ''
		ELSE CONVERT(VARCHAR(12),R.FIREPACK,103)
		END AS FIREPACK,
	R.INSURANCE,
	R.RECORD_MODIFIER,
	CONVERT(VARCHAR(12), R.DATE_MODIFIED,103) AS DATE_MODIFIED,
	RO.MAIN_RESIDENT AS MAIN,
	CASE RO.DATE_FROM
		WHEN '1/1/1900' THEN ''
		ELSE CONVERT(VARCHAR(12),RO.DATE_FROM,103)
		END AS DATE_FROM,
	CASE RO.DATE_TO
		WHEN '1/1/1900' THEN ''
		ELSE CONVERT(VARCHAR(12),RO.DATE_TO,103)
		END AS DATE_TO,
	RO.ROOM
FROM
	RESIDENTS R,
	RESIDENT_OBJECT RO
WHERE
	R.RESIDENT_ID = @GUARD_ID
AND	R.RESIDENT_ID = RO.RESIDENT_ID
AND	RO.OBJECT_ID = @PROP_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_GUARDIAN_BANK
(
	@GUARD_ID INT
) AS

SELECT 
	BD.SORTCODE,
	BD.ACCOUNTNUMBER,
	BD.ACCOUNTNAME,
	A.HOUSENUMBER,
	A.STREETNAME,
	A.ADDRESS4,
	A.CITY,
	A.POSTALCODE,
	A.COUNTY,
	RB.DEBIT_DAY
FROM 
	RESIDENT_BANK RB,
	BANK_DETAILS BD,
	ADDRESSES A
WHERE
	RB.RESIDENT_ID = @GUARD_ID
AND	RB.BANKDETAIL_ID = BD.BANKDETAIL_ID
AND	BD.ADDRESS_ID = A.ADDRESS_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_GUARDIAN_CORR
(
	@GUARD_ID INT
) AS

CREATE TABLE #R
(	CORR_ID INT,
	C_DATE SMALLDATETIME,
	TYPE VARCHAR(50),
	TARGET VARCHAR(20),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(3),
	DOCUMENT VARCHAR(200)
)

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD,
	DOCUMENT_RECIPIENTS DR
WHERE
	C.C_TYPE = CT.TYPE_ID
AND	C.TARGET = RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
AND	DR.RECIPIENT IN (SELECT @GUARD_ID)
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CE.SUBJECT
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	EMAIL_CORRESPONDENCE EC,
	EMAIL_DOCUMENTS ED,
	EMAIL_RECIPIENTS ER,
	CORRESPONDENCE_EMAIL CE
WHERE
	C.C_TYPE *= CT.TYPE_ID
AND	C.TARGET *= RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = EC.CORR_ID
AND	EC.EMAIL_ID *= ED.EMAIL_ID
AND	EC.EMAIL_ID = ER.EMAIL_ID
AND	ER.RECIPIENT IN (SELECT @GUARD_ID)
AND	EC.EMAIL_ID = CE.EMAIL_ID
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CE.SUBJECT
ORDER BY
	C.CORRESPONDENCE_DATE DESC


SELECT * FROM #R ORDER BY C_DATE






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_GUARDIAN_RECIPIENTS AS



SELECT
	R.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME,'No Name') as Name,
	O.OBJECT_NAME,
	R.PRIVATE_EMAIL AS EMAIL
FROM
	RESIDENTS R,
	OBJECTS O,
	RESIDENT_OBJECT RO
WHERE
	R.RESIDENT_ID = RO.RESIDENT_ID
AND	RO.OBJECT_ID = O.OBJECT_ID
AND	R.PRIVATE_EMAIL IS NOT NULL
AND	R.PRIVATE_EMAIL <> ''
ORDER BY
	R.FIRSTNAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_GUARDIAN_VET
(
	@GUARD int
) AS


SELECT
	ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS GUARDIAN,
	PHOTO_ID,
	APPLIC_FORM,
	BOOKLET,
	BANK_UTIL,
	STAND,
	REF,
	LICENSE,
	EXEC_DES,
	VNOTES,
	INOUT,
	CONVERT(VARCHAR(20),OUT_DATE,103) AS OUT_DATE
FROM
	RESIDENTS
WHERE
	RESIDENT_ID = @GUARD







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_GUARD_CORR_RECIPIENTS
(
	@GUARD_ID INT,
	@GCORR INT
) AS


IF @GCORR = 2
BEGIN
	select 
		r.resident_id,
		R.PRIVATE_EMAIL AS EMAIL,
		isnull(r.firstname,'') + ' ' + isnull(r.lastname,'') as name,
		convert(varchar(20),ro.date_from, 103) as date_from,	
		case convert(varchar(20),ro.date_to,103)
			when '01/01/1900' then ''
			else convert(varchar(20),ro.date_to,103)
		end as date_to,
		o.object_name as property,
		CASE RO.MAIN_RESIDENT
				WHEN 1 THEN 'YES'
				ELSE 'NO'
			END AS HEAD,
		ro.room
	from 
		residents r, resident_object ro, objects o
	where 
		R.RESIDENT_ID = @GUARD_ID
	AND 	r.resident_id = ro.resident_id
	and	r.firstname is not null
	and	r.lastname is not null
	and	ro.date_from < getdate()
	and	ro.object_id = o.object_id
	and	(ro.date_to = '01/01/1900' or ro.date_to is null 
	and 	 (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))
END
ELSE
BEGIN
	select 
		r.resident_id,
		R.PRIVATE_EMAIL AS EMAIL,
		isnull(r.firstname,'') + ' ' + isnull(r.lastname,'') as name,
		convert(varchar(20),ro.date_from, 103) as date_from,	
		case convert(varchar(20),ro.date_to,103)
			when '01/01/1900' then ''
			else convert(varchar(20),ro.date_to,103)
		end as date_to,
		o.object_name as property,
		CASE RO.MAIN_RESIDENT
				WHEN 1 THEN 'YES'
				ELSE 'NO'
			END AS HEAD,
		ro.room
	from 
		residents r, resident_object ro, objects o
	where 
	 	R.RESIDENT_ID = @GUARD_ID
	AND 	r.resident_id = ro.resident_id
	and	r.firstname is not null
	and	r.lastname is not null
	AND	R.PRIVATE_EMAIL IS NOT NULL
	and	ro.date_from < getdate()
	and	ro.object_id = o.object_id
	and	(ro.date_to = '01/01/1900' or ro.date_to is null 
	and 	 (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))

END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_GUARD_EMAIL
(
	@GUARD INT
) AS

SELECT PRIVATE_EMAIL FROM RESIDENTS WHERE RESIDENT_ID = @GUARD






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_GUARD_STATS AS

SELECT * FROM RESIDENT_STATUS








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INCIDENT
(
	@INC_ID INT
) AS


SELECT
	O.COMPLAINT_ID,
	O.COMPLAINT_DATE,
	ISNULL(OC.OBJECT_ID, '0') AS OBJECT_ID,
	O.COMPANY_ID,
	O.RESOLUTION_DATE,
	O.COMPLAINT_SOURCE,
	O.COMPLAINT_TYPE,
	O.URGENCY,
	O.C_NAME,
	O.NAME_ID,
	O.DIRECT_PHONE,
	O.MOBILE_PHONE,
	O.PHONE,
	O.EMAIL,
	O.DESCRIPTION,
	O.SOLUTION,
	O.RECORD_MANAGER,
	O.SHOW_OWNER
FROM
	COMPLAINTS O,
	OBJECT_COMPLAINTS OC
WHERE
	O.COMPLAINT_ID = @INC_ID
AND	O.COMPLAINT_ID *= OC.COMPLAINT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INCIDENT_ACTIONS
(
	@INC_ID INT
) AS

SELECT
	CH.ACTION_ID,
	CH.DATE_ENTERED,
	CA.DESCRIPTION AS ACTION_UNDERTAKEN,
	CH.DESCRIPTION,
	ISNULL(E2.FIRSTNAME + ' ' + E2.LASTNAME,'') AS RESPONSIBLE,
	CS.DESCRIPTION AS STATUS
FROM
	COMPLAINT_HISTORY CH,
	EMPLOYEES E1,
	EMPLOYEES E2,
	COMPLAINT_STATUS CS,
	COMPLAINT_ACTIONS CA
WHERE
	CH.ACCOUNTABLE *= E1.EMPLOYEE_ID
AND	CH.RESPONSIBLE *= E2.EMPLOYEE_ID
AND	CH.STATUS_CODE *= CS.STATUS_ID
AND	CH.COMPLAINT_ID = @INC_ID
AND	CH.ACTION_UNDERTAKEN *= CA.COMPLAINT_ACTION_ID
ORDER BY
	CH.ACTION_ID DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INCIDENT_TYPES AS

SELECT 
	COMPLAINT_TYPE_ID AS INCIDENT_TYPE,
	DESCRIPTION
FROM
	COMPLAINT_TYPES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INCIDENT_URGENCIES AS

SELECT * FROM COMPLAINT_URGENCY ORDER BY TIME_TO_SOLUTION








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INC_SRCS AS

select * from complaint_sources ORDER BY DESCRIPTION








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INC_STATS AS

SELECT * FROM COMPLAINT_STATUS








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSPECTION
(
	@INSP AS INT
) AS

SELECT
	O.OBJECT_NAME,
	CONVERT(VARCHAR,OI.DATE_CHECK,103) AS DATE_CHECK,
	OI.RECORD_MANAGER AS INSPECTOR,
	ISNULL(OI.REPORT_COMMENTS,'') AS REPORT_COMMENT
FROM
	OBJECTS O,
	OBJECT_CHECKS OI
WHERE
	O.OBJECT_ID = OI.OBJECT_ID
AND	OI.OBJECT_CHECK_ID = @INSP








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSPECTIONS
(
	@PROPID INT
) AS

SELECT
	O.OBJECT_CHECK_ID,
	O.DATE_CHECK,
	ISNULL((SELECT TOP 1 I.TEXT FROM INSPECTION_COMMENTS I, SELECTED_INSP_COMMENTS S WHERE S.INSP_ID = O.OBJECT_CHECK_ID AND S.COMM_ID = I.ID),'') AS REMARKS,
	E.FIRSTNAME + ' ' + E.LASTNAME AS INSPECTOR,
	CASE O.DATE_SENT
		WHEN 01/01/1900 THEN NULL
		ELSE  ISNULL(O.DATE_SENT,'')
	END AS SENT
FROM 
	OBJECT_CHECKS O,
	EMPLOYEES E
WHERE
	OBJECT_ID = @PROPID
AND	DATE_CHECK IS NOT NULL
AND	O.RECORD_MANAGER = E.EMPLOYEE_ID
ORDER BY DATE_CHECK DESC







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSPECTION_COMMENT
(
	@INSP_ID INT
) AS


CREATE TABLE #R
(
	COMMENT VARCHAR(8000)
)


INSERT INTO #R
	SELECT I.TEXT FROM INSPECTION_COMMENTS I, SELECTED_INSP_COMMENTS S WHERE I.ID = S.COMM_ID AND S.INSP_ID = @INSP_ID

INSERT INTO #R
	SELECT REPORT_COMMENTS FROM OBJECT_CHECKS WHERE OBJECT_CHECK_ID = @INSP_ID

SELECT * FROM #R







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSPECTION_COMMENTS
(
	@INSP INT
)
AS


SELECT 
	I.ID,
	I.TEXT 
FROM 
	INSPECTION_COMMENTS I,
	SELECTED_INSP_COMMENTS S
WHERE
	I.ID = S.COMM_ID
AND	S.INSP_ID = @INSP

SELECT 
	I.ID,
	I.TEXT 
FROM 
	INSPECTION_COMMENTS I
WHERE
	I.ID NOT IN (SELECT COMM_ID FROM SELECTED_INSP_COMMENTS WHERE INSP_ID = @INSP)








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_INSPECTION_EMAIL
(
	@PROP_ID INT
) AS


DECLARE @CNT INT

SELECT
	@CNT = COUNT(*)
FROM
	OBJECT_CONTACT_TYPE
WHERE
	OBJECT_ID = @PROP_ID
AND	CONTACT_TYPE = 10


IF @CNT = 0
BEGIN
	SELECT @CNT
END
ELSE
BEGIN
	SELECT 
		@CNT = COUNT(*)
	FROM	
		OBJECT_CONTACT_TYPE OCT,
		CONTACTS C
	WHERE
		OCT.OBJECT_ID = @PROP_ID
	AND	OCT.CONTACT_TYPE = 10
	AND	OCT.CONTACT_ID = C.CONTACT_ID
	AND	C.DIRECT_EMAIL <> ''
	AND	C.DIRECT_EMAIL IS NOT NULL

	IF @CNT = 0
	BEGIN
		SELECT @CNT = 1
	END
	ELSE
	BEGIN
		SELECT @CNT = 2
	END
END

SELECT @CNT

SELECT 
	C.CONTACT_ID,
	C.DIRECT_EMAIL
FROM	
	OBJECT_CONTACT_TYPE OCT,
	CONTACTS C
WHERE
	OCT.OBJECT_ID = @PROP_ID
AND	OCT.CONTACT_TYPE = 10
AND	OCT.CONTACT_ID = C.CONTACT_ID
AND	C.DIRECT_EMAIL <> ''
AND	C.DIRECT_EMAIL IS NOT NULL





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSPECTION_METERS
(
	@INSP INT
) AS

select
	isnull(rd.reading_id,0) as reading_id,
	m.meter_id,
	mr.rate_id,
	mt.description,
	m.serialnumber,
	r.rate_desc,
	isnull(rd.reading,0) as reading
from
	object_meter om,
	meters m,
	meter_rates mr,
	rates r,
	meter_readings rd,
	meter_types mt,
	object_checks oc
where 
	mr.meter_id = m.meter_id
and	r.rate_id = mr.rate_id
and	m.in_use = 1
and	mt.type_id = m.metertype
and	m.meter_id = om.meter_id
and 	om.object_id = oc.object_id
and	m.meter_id *= rd.meter_id
and	rd.object_check_id =* oc.object_check_id
and 	rd.rate_id =* mr.rate_id
and	oc.object_check_id = @INSP
order by om.meter_id, mr.rate_id







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_INSPECTION_REPORT_METERS
(
	@INSP_ID INT
) AS

select
	mt.description as type,
	m.serialnumber AS [SERIAL NUMBER],
	m.location,
	r.rate_desc AS RATE,
	(select top 1 '(' + convert(varchar(20), smr.dated,103) + ')  ' + smr.reading from meter_readings smr where smr.meter_id = m.meter_id and smr.rate_id = r.rate_id and smr.dated < rd.dated order by smr.dated desc) as [Previous Reading],
	isnull(rd.reading,0) as [NEW reading]
from
	object_meter om,
	meters m,
	meter_rates mr,
	rates r,
	meter_readings rd,
	meter_types mt,
	object_checks oc
where 
	mr.meter_id = m.meter_id
and	r.rate_id = mr.rate_id
and	m.in_use = 1
and	mt.type_id = m.metertype
and	m.meter_id = om.meter_id
and 	om.object_id = oc.object_id
and	m.meter_id *= rd.meter_id
and	rd.object_check_id =* oc.object_check_id
and 	rd.rate_id =* mr.rate_id
and	oc.object_check_id = @INSP_ID





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INSP_DETAILS
(
	@P_ID INT
) AS


SELECT
	O.OBJECT_NAME,
	O.PROPERTY_ID,
	O.KEY_NUMBER,
	O.CALAM_LIMIT,
	LTRIM(ISNULL(O.HOUSENAME,'') + ' ' +  ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'')) AS ADDRESS,
	O.POSTALCODE,
	O.CITY,
	C.COMPANY_NAME AS COMPANY,
	(SELECT 
		TOP 1 LTRIM(ISNULL(CO.FIRSTNAME,'') + ' ' + ISNULL(CO.LASTNAME,'') + '...' + ISNULL(CO.PHONE,'')) 
	FROM 
		OBJECT_CONTACT BC, 
		OBJECT_CONTACT_TYPE OT, 
		CONTACT_TYPES CT , 
		CONTACTS CO 
	WHERE 
		CO.CONTACT_ID = BC.CONTACT_ID 
	AND 	BC.OBJECT_ID = O.OBJECT_ID 
	AND 	OT.CONTACT_ID = BC.CONTACT_ID 
	AND 	OT.CONTACT_TYPE = CT.CONTACT_TYPE 
	AND 	CT.CONTACT_TYPE = 14 
	AND	(GETDATE() > BC.DATE_START AND (GETDATE() < BC.DATE_END OR BC.DATE_END IS NULL))) AS CONTACT
FROM
	OBJECTS O,
	COMPANIES C,
	COMPANY_OBJECT OC
WHERE
	O.OBJECT_ID = @P_ID
AND	OC.OBJECT_ID = O.OBJECT_ID
AND	OC.COMPANY_ID = C.COMPANY_ID
AND	OC.DATE_FROM < GETDATE()
AND	(OC.DATE_TO > GETDATE() OR OC.DATE_TO IS NULL)


SELECT CONVERT(VARCHAR(20),MAX(DATE_CHECK), 103) FROM OBJECT_CHECKS WHERE OBJECT_ID = @P_ID

SELECT MAX_NR_RESIDENTS FROM OBJECTS WHERE OBJECT_ID = @P_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_FACILITIES
(
	@PROPID INT
) AS

SELECT
	ISNULL(FT.DESCRIPTION,'&nbsp') AS TYPE,
	ISNULL(F.LOCATION,'&nbsp') AS LOCATION,
	ISNULL(F.SERIAL_NUMBER,'&nbsp') AS SERIAL
FROM
	OBJECT_FACILITIES FO,
	FACILITIES F,
	FACILITY_TYPES FT
WHERE
	FO.OBJECT_ID = @PROPID
AND	FO.FACILITY_ID = F.FACILITY_ID
AND	FT.FACILITY_TYPE = F.FACILITY_TYPE
AND	F.IN_USE = 1








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INSP_GUARDIANS
(
	@PROPID INT
) AS


SELECT MAX_NR_RESIDENTS AS MAXOCC FROM OBJECTS WHERE OBJECT_ID = @PROPID

select 
	CASE ISNULL(RO.ROOM,'')
		WHEN '' THEN '&nbsp'
		ELSE RO.ROOM
	END AS ROOM,
	ISNULL(R.FIRSTNAME + '&nbsp' + R.LASTNAME,'&nbsp') AS NAME,
	CASE ISNULL(R.PHONE,'')
		WHEN '' THEN '&nbsp'
		ELSE R.PHONE
	END AS PHONE,
	CASE ISNULL(R.PRIVATE_MOBILE,'')
		WHEN '' THEN '&nbsp'
		ELSE R.PRIVATE_MOBILE
	END AS MOBILE
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROPID
and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME ASC







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_INCIDENTS
(
	@PROPID INT
) AS


DECLARE @COMM INT

CREATE TABLE #R
(
	COMP_ID VARCHAR(10),
	C_DATE VARCHAR(20),
	DESCRIPTION VARCHAR(4000),
	STATUS VARCHAR(50)
)

DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROPID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.INSP = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #R
	SELECT 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		CS.DESCRIPTION
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		'',
		CONVERT(VARCHAR(20), CH.DATE_ENTERED,103),
		CH.ACTION_UNDERTAKEN,
		CS.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS

SELECT * FROM  #R








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_METERS
(
	@PROPID INT
) AS

SELECT 
	M.METER_ID as met,
	MT.DESCRIPTION,
	ISNULL(M.LOCATION,'') AS LOCATION,
	ISNULL(M.SERIALNUMBER,'') AS SERIAL
FROM
	METERS M,
	OBJECT_METER OM,
	METER_TYPES MT
WHERE
	M.METER_ID = OM.METER_ID
AND	M.METERTYPE = MT.TYPE_ID
AND	OM.OBJECT_ID = @PROPID
AND	M.IN_USE = 1
GROUP BY
	M.METER_ID,
	MT.DESCRIPTION,
	M.LOCATION,
	M.SERIALNUMBER
ORDER BY 
	MT.DESCRIPTION ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_METER_READINGS
(
	@METID INT
) AS

SELECT
	R.RATE_DESC,
	MR.RATE_ID,
	ISNULL(CONVERT(VARCHAR(20),RE.READING) + ' (' + CONVERT(VARCHAR(20), RE.DATED,103) + ')','&nbsp') AS READING
FROM
	RATES R,
	METER_RATES MR,
	METER_READINGS RE
WHERE
	R.RATE_ID = MR.RATE_ID
AND	MR.METER_ID = @METID
AND	RE.METER_ID =* MR.METER_ID
AND	RE.READING_ID IN (SELECT TOP 1 READING_ID FROM METER_READINGS WHERE METER_ID = @METID AND RATE_ID = R.RATE_ID ORDER BY DATED DESC)








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INSP_NOTES
(
	@PROP_ID INT
) AS


SELECT
	N.REGARDING AS DESCRIPTION
FROM 
	NOTES N
WHERE 
	N.OBJECT_ID = @PROP_ID
AND	N.IN_INSP = 1
ORDER BY
	N.ACTIVITY_DATE DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_OPEN_INCIDENTS
(
	@PROPID INT
) AS


DECLARE @COMM INT

CREATE TABLE #R
(
	COMP_ID VARCHAR(10),
	C_DATE VARCHAR(20),
	DESCRIPTION VARCHAR(4000),
	STATUS VARCHAR(50)
)

DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROPID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	CS.INSP = 0
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #R
	SELECT 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		CS.DESCRIPTION
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		'',
		CONVERT(VARCHAR(20), CH.DATE_ENTERED,103),
		CH.ACTION_UNDERTAKEN,
		CS.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CH.SHOW_OWNER = 1
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS

SELECT * FROM  #R








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_INSP_PROP_NL
(
	@PROP_ID INT
) AS

SELECT
	ISNULL(O.OBJECT_NAME,'') + ' ' + ISNULL(O.POSTALCODE,'') + ' ' + ISNULL(O.CITY,'') AS PROP
FROM
	OBJECTS O
WHERE
	O.OBJECT_ID = @PROP_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_INSP_REPORT_GUARDIANS
(
	@PROP_ID INT
) AS



select 
	ISNULL(R.FIRSTNAME + ' ' + R.LASTNAME,'') AS NAME,
	CONVERT(VARCHAR(20), RO.DATE_FROM, 103) AS START
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROP_ID
and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE GET_INSP_REPORT_GUARDIANS_NL
(
	@PROP_ID INT
) AS

SET NOCOUNT ON

DECLARE @COMM INT
DECLARE @CNT INT

CREATE TABLE #R
(
	A INT,
	B VARCHAR(250),
	C VARCHAR(50)
)


SELECT @CNT = COUNT(*)
FROM
	RESIDENTS R,
	RESIDENT_OBJECT RO
WHERE
	R.RESIDENT_ID = RO.RESIDENT_ID
AND	RO.DATE_FROM < GETDATE()
AND	(RO.DATE_TO > GETDATE() OR RO.DATE_TO = 01/01/1900 OR RO.DATE_TO IS NULL)
AND	RO.OBJECT_ID = @PROP_ID


IF @CNT > 0
BEGIN

	SELECT @COMM = ISNULL(MAX_NR_RESIDENTS,0) FROM OBJECTS WHERE OBJECT_ID = @PROP_ID

	INSERT INTO #R
		SELECT
			1,'Bewoner',null

	INSERT INTO #R
		SELECT
			3,'Maximaal aantal bewoner : ' + CONVERT(VARCHAR(5),@COMM),null

	INSERT INTO #R
		SELECT
			2,'Bewoner','Ruimte'

	INSERT INTO #R
	SELECT
		3,
		ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.PREFIX,'') + ' ' + ISNULL(R.LASTNAME,''),
		RO.ROOM
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO
	WHERE
		R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.DATE_FROM < GETDATE()
	AND	(RO.DATE_TO > GETDATE() OR RO.DATE_TO = 01/01/1900 OR RO.DATE_TO IS NULL)
	AND	RO.OBJECT_ID = @PROP_ID
END

SELECT * FROM  #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_INSP_REPORT_INCIDENTS
(
	@PROP_ID INT
) AS

SET NOCOUNT ON

DECLARE @COMM INT
DECLARE @CNT INT

CREATE TABLE #R
(
	A INT,
	B VARCHAR(50),
	C VARCHAR(4000),
	D VARCHAR(4000),
	E VARCHAR(4000),
	F VARCHAR(4000),
	G VARCHAR(4000)
)


SELECT @CNT = COUNT(*)
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	CS.INSP = 0
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION

IF @CNT > 0
BEGIN
	INSERT INTO #R
		SELECT
			1,'Open Incidents',null,null,null,NULL,NULL
END


DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #R
	SELECT
		2,'Incident ID','Date Reported', 'Description', 'Proposed Resolution','Current Status',NULL

	INSERT INTO #R
	SELECT
		0, 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		C.SOLUTION,
		CS.DESCRIPTION,
		NULL
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		4,'Actions Taken',NULL,NULL,NULL,NULL,NULL
	
	INSERT INTO #R
		SELECT
		4,'Date',NULL,NULL,NULL,NULL,'Action'

	INSERT INTO #R
	SELECT
		3,CONVERT(VARCHAR(20),CH.DATE_ENTERED,103),NULL,NULL,NULL,NULL,CH.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CH.SHOW_OWNER = 1
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS


/*
DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	CS.INSP = 1
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #R
	SELECT 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		CS.DESCRIPTION
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		'',
		CONVERT(VARCHAR(20), CH.DATE_ENTERED,103),
		CH.ACTION_UNDERTAKEN,
		CS.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS

*/
SELECT * FROM  #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_INSP_REPORT_INCIDENTS_NL
(
	@PROP_ID INT
) AS

SET NOCOUNT ON

DECLARE @COMM INT
DECLARE @CNT INT

CREATE TABLE #R
(
	A INT,
	B VARCHAR(50),
	C VARCHAR(4000),
	D VARCHAR(4000),
	E VARCHAR(4000),
	F VARCHAR(4000),
	G VARCHAR(4000)
)


SELECT @CNT = COUNT(*)
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	CS.INSP = 0
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION

IF @CNT > 0
BEGIN
	INSERT INTO #R
		SELECT
			1,'Lopende Incidenten',null,null,null,NULL,NULL
END


DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #R
	SELECT
		2,'Incident Nummer','Datum Melding', 'Omschrijving', 'Voorgestelde oplossing','Huidige Status',NULL

	INSERT INTO #R
	SELECT
		0, 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		C.SOLUTION,
		CS.DESCRIPTION,
		NULL
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		1,'Ondernomen Acties',NULL,NULL,NULL,NULL,NULL
	
	INSERT INTO #R
		SELECT
		4,'Datum',NULL,NULL,NULL,NULL,'Actie'

	INSERT INTO #R
	SELECT
		3,CONVERT(VARCHAR(20),CH.DATE_ENTERED,103),NULL,NULL,NULL,NULL,CH.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CH.SHOW_OWNER = 1
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS


/*
DECLARE COMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
AND	CS.INSP = 1
AND	C.SHOW_OWNER = 1
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN COMS

FETCH NEXT FROM COMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #R
	SELECT 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		CS.DESCRIPTION
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #R
		SELECT
		'',
		CONVERT(VARCHAR(20), CH.DATE_ENTERED,103),
		CH.ACTION_UNDERTAKEN,
		CS.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM COMS INTO @COMM
END

CLOSE COMS
DEALLOCATE COMS

*/
SELECT * FROM  #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_INSP_REPORT_RES_INCIDENTS
(
	@PROP_ID INT,
	@INSP_ID INT
) AS


SET NOCOUNT ON

DECLARE @COMM INT
DECLARE @CNT INT

CREATE TABLE #P
(
	A INT,
	B VARCHAR(50),
	C VARCHAR(4000),
	D VARCHAR(4000),
	E VARCHAR(4000),
	F VARCHAR(4000),
	G VARCHAR(4000)
)

SELECT 
	@CNT = COUNT(*)
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS,
	OBJECT_CHECKS OI
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = OI.OBJECT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 1
AND	C.SHOW_OWNER = 1
AND	CH.DATE_ENTERED > (SELECT TOP 1 DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_ID = @PROP_ID AND OBJECT_CHECK_ID <> @INSP_ID ORDER BY DATE_CHECK DESC)
AND	CH.DATE_ENTERED < (SELECT DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_CHECK_ID = @INSP_ID)


IF @CNT > 0
BEGIN
	INSERT INTO #P
		SELECT
			1,'Resolved Incidents',null,null,null,NULL,NULL
END


DECLARE ICOMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS,
	OBJECT_CHECKS OI
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = OI.OBJECT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 1
AND	C.SHOW_OWNER = 1
AND	CH.DATE_ENTERED > (SELECT TOP 1 DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_ID = @PROP_ID AND OBJECT_CHECK_ID <> @INSP_ID ORDER BY DATE_CHECK DESC)
AND	CH.DATE_ENTERED < (SELECT DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_CHECK_ID = @INSP_ID)
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN ICOMS

FETCH NEXT FROM ICOMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #P
	SELECT
		2,'Incident ID','Date Reported', 'Description', 'Proposed Resolution','Current Status',NULL

	INSERT INTO #P
	SELECT
		0, 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		C.SOLUTION,
		CS.DESCRIPTION,
		NULL
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #P
		SELECT
		4,'Actions Taken',NULL,NULL,NULL,NULL,NULL
	
	INSERT INTO #P
		SELECT
		4,'Date',NULL,NULL,NULL,NULL,'Action'

	INSERT INTO #P
	SELECT
		3,CONVERT(VARCHAR(20),CH.DATE_ENTERED,103),NULL,NULL,NULL,NULL,CH.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CH.SHOW_OWNER = 1
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM ICOMS INTO @COMM
END

CLOSE ICOMS
DEALLOCATE ICOMS

SELECT * FROM  #P

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_INSP_REPORT_RES_INCIDENTS_NL
(
	@PROP_ID INT,
	@INSP_ID INT
) AS


SET NOCOUNT ON

DECLARE @COMM INT
DECLARE @CNT INT

CREATE TABLE #P
(
	A INT,
	B VARCHAR(50),
	C VARCHAR(4000),
	D VARCHAR(4000),
	E VARCHAR(4000),
	F VARCHAR(4000),
	G VARCHAR(4000)
)

SELECT 
	@CNT = COUNT(*)
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS,
	OBJECT_CHECKS OI
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = OI.OBJECT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 1
AND	C.SHOW_OWNER = 1
AND	CH.DATE_ENTERED > (SELECT TOP 1 DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_ID = @PROP_ID AND OBJECT_CHECK_ID <> @INSP_ID ORDER BY DATE_CHECK DESC)
AND	CH.DATE_ENTERED < (SELECT DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_CHECK_ID = @INSP_ID)


IF @CNT > 0
BEGIN
	INSERT INTO #P
		SELECT
			1,'Afgehandelde Incidenten',null,null,null,NULL,NULL
END


DECLARE ICOMS CURSOR FOR
SELECT 
	C.COMPLAINT_ID
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS,
	OBJECT_CHECKS OI
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = OI.OBJECT_ID
AND	OC.OBJECT_ID = @PROP_ID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 1
AND	C.SHOW_OWNER = 1
AND	CH.DATE_ENTERED > (SELECT TOP 1 DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_ID = @PROP_ID AND OBJECT_CHECK_ID <> @INSP_ID ORDER BY DATE_CHECK DESC)
AND	CH.DATE_ENTERED < (SELECT DATE_CHECK FROM OBJECT_CHECKS WHERE OBJECT_CHECK_ID = @INSP_ID)
GROUP BY
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY C.COMPLAINT_DATE DESC

OPEN ICOMS

FETCH NEXT FROM ICOMS INTO @COMM

WHILE @@FETCH_STATUS = 0
BEGIN
	
	INSERT INTO #P
	SELECT
		2,'Incident Nummer','Datum Melding', 'Omschrijving', 'Voorgestelde oplossing','Huidige Status',NULL

	INSERT INTO #P
	SELECT
		0, 
		C.COMPLAINT_ID,
		CONVERT(VARCHAR(20),C.COMPLAINT_DATE,103) ,
		C.DESCRIPTION,
		C.SOLUTION,
		CS.DESCRIPTION,
		NULL
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	C.COMPLAINT_ID = @COMM
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID


	INSERT INTO #P
		SELECT
		1,'Ondernomen Acties',NULL,NULL,NULL,NULL,NULL
	
	INSERT INTO #P
		SELECT
		4,'Datum',NULL,NULL,NULL,NULL,'Actie'

	INSERT INTO #P
	SELECT
		3,CONVERT(VARCHAR(20),CH.DATE_ENTERED,103),NULL,NULL,NULL,NULL,CH.DESCRIPTION
	FROM
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS
	WHERE 
		COMPLAINT_ID = @COMM
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CH.SHOW_OWNER = 1
	ORDER BY
	CH.ACTION_ID DESC

	FETCH NEXT FROM ICOMS INTO @COMM
END

CLOSE ICOMS
DEALLOCATE ICOMS

SELECT * FROM  #P

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INSP_SECURITIES
(
	@PROPID INT
) AS

SELECT
	ISNULL(ST.DESCRIPTION,'&nbsp') AS TYPE,
	ISNULL(S.LOCATION,'&nbsp') AS LOCATION
FROM
	OBJECT_SECURITIES OS,
	SECURITIES S,
	SECURITY_TYPES ST
WHERE
	OS.OBJECT_ID = @PROPID
AND	OS.SECURITY_ID = S.SECURITY_ID
AND	ST.SECURITY_TYPE = S.SECURITY_TYPE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INVOICE
(
	@INV_ID INT
) AS

SELECT
	I.INVOICEID,
	I.DESCRIPTION,
	CONVERT(VARCHAR(20),I.DATEOFISSUE,103) AS DATEOFISSUE,
	I.CONTACT_ID,
	I.OVERDUEAFTER_ID,
	I.AMOUNT,
	I.VAT,
	I.RECORD_MANAGER,
	CONVERT(VARCHAR(20),CI.PAID,103) AS PAID
FROM 
	INVOICES I,
	COMPANY_INVOICES CI
WHERE 
	I.INVOICEID = @INV_ID
AND	I.INVOICEID = CI.INVOICEID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INVOICE_ITEMS
(
	@INV_ID INT
) AS



SELECT * FROM INVOICE_ITEMS WHERE INVOICEID = @INV_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_INVOICE_PERIODS AS


SELECT * FROM INVOICE_PERIOD








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_JOBTITLES AS


SELECT * FROM JOB_TITLES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_LAST_INSP
(
	@PROPID INT
) AS


select 
	CONVERT(VARCHAR(20),DATE_CHECK,103) AS DATE,
	ISNULL(DAMAGES,'None') AS DAMAGES,
	ISNULL(REPAIRS,'None') AS REPAIRS,
	ISNULL(CAMELOTACTION,'None') AS CAMELOT,
	ISNULL(CLIENTACTION,'None') AS CLIENT,
	ISNULL(INTERNAL_REMARKS,'None') AS INTERNAL
from 
	object_checks 
WHERE 
	OBJECT_CHECK_ID = (SELECT TOP 1 OBJECT_CHECK_ID FROM OBJECT_CHECKS WHERE OBJECT_ID = @PROPID ORDER BY DATE_CHECK DESC)








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_MAINTAINERS AS

SELECT * FROM MAINTAINERS WHERE USED = 1









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_MERGE_CONTACT
(
	@CONT_ID VARCHAR(20),
	@EMP INT,
	@PROP_ID INT
) AS

CREATE TABLE #R
(	FIRSTNAME VARCHAR(1000),
	LASTNAME VARCHAR(1000),
	TITLE VARCHAR(1000),
	JOB_TITLE VARCHAR(1000),
	OBJECT_NAME VARCHAR(1000),
	COMPANY VARCHAR(1000),
	HOUSENAME VARCHAR(1000),
	HOUSENUMBER VARCHAR(1000),
	STREETNAME VARCHAR(1000),
	CITY VARCHAR(1000),
	POSTALCODE VARCHAR(1000),
	COUNTY VARCHAR(1000),
	SIGNATURE  VARCHAR(1000),
	sigtitle varchar(1000),
	SIGEMAIL VARCHAR(1000),
	SALUTATION VARCHAR(250)
)

DECLARE @FSQL VARCHAR(8000)
DECLARE @WSQL VARCHAR(8000)

SELECT @FSQL = ' INSERT INTO #R select
			C.firstname,
			C.lastname,
			C.TITLE,
			C.JOB_TITLE,
			'''',
			CO.COMPANY_NAME,
			A.housename,
			A.housenumber,
			A.streetname,
			A.city,
			A.postalcode,
			A.county,
			'''',
			'''',
			'''',
			C.SALUTATION
		from
			CONTACTS C,
			COMPANIES CO,
			COMPANY_CONTACT CC,
			COMPANY_ADDRESS CA,
			ADDRESSES A
		where
			C.CONTACT_id in('


SELECT @WSQL = ')
		and	C.CONTACT_id = CC.CONTACT_ID
		and	CC.COMPANY_ID = CO.COMPANY_ID
		AND	C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		AND	CA.ADDRESS_TYPE = 1'

EXEC(@FSQL  + @CONT_ID + @WSQL)

UPDATE #R SET SIGNATURE = E.FIRSTNAME + ' ' + E.LASTNAME, sigtitle = e.job_title, SIGEMAIL = E.EMAIL FROM EMPLOYEES E WHERE E.EMPLOYEE_ID = @EMP
UPDATE #R SET OBJECT_NAME = O.OBJECT_NAME FROM OBJECTS O WHERE O.OBJECT_ID = @PROP_ID
SELECT * FROM #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO













CREATE PROCEDURE GET_MERGE_CONTACTS
(
	@CONTS1 VARCHAR(8000) ,
	@CONTS2 VARCHAR(8000) ,
	@CONTS3 VARCHAR(8000),
	@CONTS4 VARCHAR(8000) ,
	@CONTS5 VARCHAR(8000) ,
	@CONTS6 VARCHAR(8000) ,
	@CONTS7 VARCHAR(8000) ,
	@CONTS8 VARCHAR(8000) ,
	@CONTS9 VARCHAR(8000) ,
	@CONTS10 VARCHAR(8000),
	@CONTS11 VARCHAR(8000) ,
	@CONTS12 VARCHAR(8000) ,
	@EMP INT,
	@PROP_ID INT
) AS

CREATE TABLE #R
(	FIRSTNAME VARCHAR(1000),
	LASTNAME VARCHAR(1000),
	TITLE VARCHAR(1000),
	JOB_TITLE VARCHAR(1000),
	OBJECT_NAME VARCHAR(1000),
	COMPANY VARCHAR(1000),
	HOUSENAME VARCHAR(1000),
	HOUSENUMBER VARCHAR(1000),
	STREETNAME VARCHAR(1000),
	CITY VARCHAR(1000),
	POSTALCODE VARCHAR(1000),
	COUNTY VARCHAR(1000),
	SIGNATURE  VARCHAR(1000),
	sigtitle varchar(1000),
	SIGEMAIL VARCHAR(1000),
	SALUTATION VARCHAR(250)
)

DECLARE @FSQL VARCHAR(8000)
DECLARE @WSQL VARCHAR(8000)

SELECT @FSQL = ' INSERT INTO #R select
			C.firstname,
			C.lastname,
			C.TITLE,
			C.JOB_TITLE,
			'''',
			CO.COMPANY_NAME,
			A.housename,
			A.housenumber,
			A.streetname,
			A.city,
			A.postalcode,
			A.county,
			'''',
			'''',
			'''',
			C.SALUTATION
		from
			CONTACTS C,
			COMPANIES CO,
			COMPANY_CONTACT CC,
			COMPANY_ADDRESS CA,
			ADDRESSES A
		where
			C.CONTACT_id in('


SELECT @WSQL = ')
		and	C.CONTACT_id = CC.CONTACT_ID
		and	CC.COMPANY_ID = CO.COMPANY_ID
		AND	C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		AND	CA.ADDRESS_TYPE = 1'
DECLARE @T VARCHAR(8000)
SELECT @T = CONVERT(VARCHAR(8000), @CONTS1)
EXEC(@FSQL  + @T + @CONTS2 + @CONTS3 + @CONTS4 + @CONTS5 + @CONTS6 + @CONTS7 + @CONTS8 + @CONTS9 + @CONTS10 + @CONTS11 + @CONTS12 + @WSQL)

UPDATE #R SET SIGNATURE = E.FIRSTNAME + ' ' + E.LASTNAME, sigtitle = e.job_title, SIGEMAIL = E.EMAIL FROM EMPLOYEES E WHERE E.EMPLOYEE_ID = @EMP
UPDATE #R SET OBJECT_NAME = O.OBJECT_NAME FROM OBJECTS O WHERE O.OBJECT_ID = @PROP_ID
SELECT * FROM #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_MERGE_DOC
(
	@DOC_ID INT
) AS


SELECT
	DOC_NAME,
	DOCUMENT,
	FILESIZE
FROM
	MERGE_DOCUMENTS
WHERE
	DOC_ID = @DOC_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_MERGE_DOCUMENT
(
	@DOC_ID INT
) AS

SELECT
	DOC_LIST_NAME,
	DOC_NAME,
	DOC_TYPE,
	DESCRIPTION,
	RECORD_MANAGER,
	CONVERT(VARCHAR(20),DATE_ENTERED,103) AS DATE_ENTERED
FROM
	MERGE_DOCUMENTS
WHERE
	DOC_ID = @DOC_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_MERGE_DOCUMENTS AS

SELECT 
	D.DOC_ID,
	D.DOC_LIST_NAME,
	D.DOC_NAME,
	D.DESCRIPTION,
	DT.DESCRIPTION AS DOC_TYPE,
	D.DATE_ENTERED,
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,'') AS RECORD_MANAGER
FROM 
	MERGE_DOCUMENTS D,
	DOCUMENT_TYPES DT,
	EMPLOYEES E
WHERE
	D.DOC_TYPE = DT.DOCUMENT_TYPE
AND	D.RECORD_MANAGER	 *= E.EMPLOYEE_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE GET_MERGE_FIELDS AS


SELECT * FROM MERGE_FIELDS ORDER BY ORD







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_MERGE_GUARD
(
	@GUARD VARCHAR(20),
	@EMP INT
) AS

CREATE TABLE #R
(	FIRSTNAME VARCHAR(200),
	LASTNAME VARCHAR(200),
	OBJECT_NAME VARCHAR(200),
	HOUSENAME VARCHAR(200),
	HOUSENUMBER VARCHAR(200),
	STREETNAME VARCHAR(200),
	CITY VARCHAR(200),
	POSTALCODE VARCHAR(200),
	COUNTY VARCHAR(200),
	SIGNATURE  VARCHAR(200),
	sigtitle varchar(200),
	SIGEMAIL VARCHAR(200)
)

DECLARE @FSQL VARCHAR(8000)
DECLARE @WSQL VARCHAR(8000)
SELECT @FSQL = ' INSERT INTO #R select
			r.firstname,
			r.lastname,
			o.object_name,
			o.housename,
			o.housenumber,
			o.streetname,
			o.city,
			o.postalcode,
			o.county,
			'''',
			'''',
			''''
		from
			residents r,
			objects o,
			resident_object ro
		where
			r.resident_id in('

SELECT @WSQL = ')
		and	r.resident_id = ro.resident_id
		and	ro.object_id = o.object_id
		and	ro.date_from < getdate()
		and	(ro.date_to = ''01/01/1900'' or (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))'

EXEC(@FSQL  + @GUARD + @WSQL)

UPDATE #R SET SIGNATURE = E.FIRSTNAME + ' ' + E.LASTNAME, sigtitle = e.job_title, SIGEMAIL = E.EMAIL FROM EMPLOYEES E WHERE E.EMPLOYEE_ID = @EMP

SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_MERGE_GUARDS
(
	@CONTS1 VARCHAR(8000) ,
	@CONTS2 VARCHAR(8000) ,
	@CONTS3 VARCHAR(8000),
	@CONTS4 VARCHAR(8000) ,
	@CONTS5 VARCHAR(8000) ,
	@CONTS6 VARCHAR(8000) ,
	@CONTS7 VARCHAR(8000) ,
	@CONTS8 VARCHAR(8000) ,
	@CONTS9 VARCHAR(8000) ,
	@CONTS10 VARCHAR(8000),
	@CONTS11 VARCHAR(8000) ,
	@CONTS12 VARCHAR(8000) ,
	@EMP INT
) AS

CREATE TABLE #R
(	FIRSTNAME VARCHAR(200),
	LASTNAME VARCHAR(200),
	OBJECT_NAME VARCHAR(200),
	HOUSENAME VARCHAR(200),
	HOUSENUMBER VARCHAR(200),
	STREETNAME VARCHAR(200),
	CITY VARCHAR(200),
	POSTALCODE VARCHAR(200),
	COUNTY VARCHAR(200),
	SIGNATURE  VARCHAR(200),
	sigtitle varchar(200),
	SIGEMAIL VARCHAR(200)
)

DECLARE @FSQL VARCHAR(8000)
DECLARE @WSQL VARCHAR(8000)
SELECT @FSQL = ' INSERT INTO #R select
			r.firstname,
			r.lastname,
			o.object_name,
			o.housename,
			o.housenumber,
			o.streetname,
			o.city,
			o.postalcode,
			o.county,
			'''',
			'''',
			''''
		from
			residents r,
			objects o,
			resident_object ro
		where
			r.resident_id in('

SELECT @WSQL = ')
		and	r.resident_id = ro.resident_id
		and	ro.object_id = o.object_id
		and	ro.date_from < getdate()
		and	(ro.date_to = ''01/01/1900'' or (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))'

EXEC(@FSQL  + @CONTS1 + @CONTS2 + @CONTS3 + @CONTS4 + @CONTS5 + @CONTS6 + @CONTS7 + @CONTS8 + @CONTS9 + @CONTS10 + @CONTS11 + @CONTS12 + @WSQL)

UPDATE #R SET SIGNATURE = E.FIRSTNAME + ' ' + E.LASTNAME, sigtitle = e.job_title, SIGEMAIL = E.EMAIL FROM EMPLOYEES E WHERE E.EMPLOYEE_ID = @EMP

SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_METER
(
	@MET_ID INT
) AS

SELECT 
	MT.TYPE_ID,
	ISNULL(M.LOCATION,'') AS LOCATION,
	ISNULL(M.SERIALNUMBER,'') AS SERIALNUMBER,
	M.SUPP_ID,
	ISNULL(M.NOTES,'') AS NOTES,
	ISNULL(M.PHOTO_ID,'') AS PHOTO_ID,
	M.IN_USE,
	ISNULL(M.MODIFIED_BY,'') AS MODIFIED_BY,
	CONVERT(varchar(12),DATE_MODIFIED,103) AS DATE_MODIFIED,
	ISNULL(CONVERT(VARCHAR(20),MAX(M.START_DATE),103),'') AS START_DATE,
	ISNULL(CONVERT(VARCHAR(20),MAX(M.END_DATE),103),'') AS FINISH_DATE
FROM
	METERS M,
	METER_TYPES MT
WHERE
	M.METERTYPE = MT.TYPE_ID
AND	M.METER_ID = @MET_ID
GROUP BY
	MT.TYPE_ID,
	M.LOCATION,
	M.SUPP_ID,
	M.NOTES,
	M.PHOTO_ID,
	M.IN_USE,
	M.MODIFIED_BY,
	M.DATE_MODIFIED,
	M.SERIALNUMBER








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_METERS
(
	@PROPID INT
) AS

SELECT 
	M.METER_ID as met,
	MT.DESCRIPTION,
	ISNULL(M.LOCATION,'') AS LOCATION,
	M.SERIALNUMBER AS SERIAL,
	CASE MAX(MR.DATED)
		WHEN 01/01/1900 THEN NULL
		ELSE MAX(MR.DATED)
	END AS READING_DATE,
	ISNULL(MAX(MR.READING),'') AS READING,
	M.IN_USE
FROM
	METERS M,
	OBJECT_METER OM,
	METER_TYPES MT,
	METER_READINGS MR
WHERE
	M.METER_ID = OM.METER_ID
AND	M.METERTYPE = MT.TYPE_ID
AND	OM.OBJECT_ID = @PROPID 
AND	M.METER_ID *= MR.METER_ID
GROUP BY
	M.METER_ID,
	MT.DESCRIPTION,
	M.LOCATION,
	M.SERIALNUMBER,
	M.IN_USE
ORDER BY 
	M.IN_USE DESC,
	MT.DESCRIPTION ASC,
	MR.READING_DATE DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_METER_RATES
(
	@MET_ID INTEGER
) AS

select 
	R.RATE_DESC,
	R.RATE_ID
from 
	RATES R,
	meter_rates MR
where 
	MR.meter_id =@met_id
AND	MR.RATE_ID = R.RATE_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_METER_TYPES AS

SELECT * FROM METER_TYPES









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_NEW_INSPECTION_METERS
(
	@PROP INT
) AS

select
	isnull(rd.reading_id,0) as reading_id,
	om.meter_id,
	mr.rate_id,
	mt.description,
	m.serialnumber,
	r.rate_desc,
	ISNULL(' (' + convert(varchar(20),rd.dated,103)  + ') ' + convert(varchar(20),rd.reading),0)  as reading
from 
	object_meter om,
	meters m,
	meter_rates mr,
	rates r,
	meter_readings rd,
	meter_types mt
where 
	om.meter_id = m.meter_id
and	object_id = @PROP
and	mr.meter_id = m.meter_id
and	r.rate_id = mr.rate_id
and	m.in_use = 1
and 	rd.reading_id =* (select top 1 reading_id from meter_readings where meter_id = m.meter_id and rate_id = r.rate_id order by dated desc)
and	mt.type_id = m.metertype
order by om.meter_id, mr.rate_id







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_NON_METER_RATES
(
	@MET_ID INT
) AS


select 
	r.rate_id,
	r.rate_desc
from 
	rates r,
	meters m
where
	m.meter_id = @MET_ID
and	m.metertype = r.meter_type
and	r.rate_id not in (select rate_id from meter_rates where meter_id = @MET_ID)
order by
	r.rate_desc

select 
	r.rate_id,
	r.rate_desc
from 
	rates r,
	meters m
where
	m.meter_id = @MET_ID
and	m.metertype = r.meter_type
and	r.rate_id in (select rate_id from meter_rates where meter_id = @MET_ID)
order by
	r.rate_desc








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_OBJECT_STATS AS

SELECT * FROM OBJECT_STATUS









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_OBJECT_TYPES AS


SELECT * FROM OBJECT_TYPES ORDER BY DESCRIPTION








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_OLD_PICTURES AS



SELECT o.object_id, 'd:\data\nl camelot\company data\' + substring(o.picture_path, 4, datalength(o.picture_path) - 3) as picture_path, isnull(e.employee_id,22) as record_manager, o.date_entered FROM camelot.dbo.OBJECT_PICTURES o, employees e
where
	o.record_manager *= e.userid
and	o.picture_path not like 'G:\Camelot crm\foto''s p%'

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_OPEN_INCIDENTS
(
	@PROPID INT
) AS

SELECT 
	C.RESOLUTION_DATE,
	C.COMPLAINT_ID AS INC,
	U.DESCRIPTION AS URGENCY,
	C.COMPLAINT_DATE AS INC_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION AS STATUS
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROPID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 0
GROUP BY
	C.COMPLAINT_ID,
	U.DESCRIPTION,
	C.COMPLAINT_DATE,
	C.RESOLUTION_DATE,
	C.DESCRIPTION,
	CS.DESCRIPTION
ORDER BY RESOLUTION_DATE DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_OTHER_ADDRESS 
(
	@GUARD INT
)AS


SELECT
	A.HOUSENAME,
	A.STREETNAME,
	A.ADDRESS4,
	A.ADDRESS5,
	A.CITY,
	A.POSTALCODE,
	A.COUNTRY,
	A.COUNTY,
	A.AREA_ID,
	ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name') AS NAME,
	CONVERT(VARCHAR(20),DATE_ENTERED,103) AS ENTERED
FROM
	ADDRESSES A,
	RESIDENT_ADDRESS RA,
	EMPLOYEES E
WHERE
	RA.RESIDENT_ID = @GUARD
AND	RA.ADDRESS_TYPE = 4
AND	RA.ADDRESS_ID = A.ADDRESS_ID
AND	A.RECORD_MANAGER *= E.EMPLOYEE_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_OUT_COMPANY_INVOICES
(
	@COMP_ID NUMERIC(18)
)
AS

SELECT
	I.INVOICEID,
	I.DATEOFISSUE,
	CONVERT(DECIMAL(10,2),ISNULL(I.AMOUNT,'0')) + CONVERT(DECIMAL(10,2),ISNULL(I.VAT,'0')) AS AMOUNT,
	I.DESCRIPTION,
	I.DOCUMENT,
	I.DOCUMENT_SIZE,
	I.DOCUMENT_NAME,
	I.RECORD_MANAGER
FROM 
	INVOICES I,
	COMPANY_INVOICES CI
WHERE
	CI.INVOICEID = I.INVOICEID
AND	CI.COMPANYID = @COMP_ID
AND	CI.PAID = '1900-01-01'
ORDER BY I.INVOICEID ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_PAID_COMPANY_INVOICES
(
	@COMP_ID NUMERIC(18)
)
AS

SELECT
	I.INVOICEID,
	I.DATEOFISSUE,
	CONVERT(DECIMAL(10,2),I.AMOUNT) + CONVERT(DECIMAL(10,2),I.VAT) AS AMOUNT,
	I.DESCRIPTION,
	I.DOCUMENT,
	I.DOCUMENT_SIZE,
	I.DOCUMENT_NAME,
	I.RECORD_MANAGER
FROM 
	INVOICES I,
	COMPANY_INVOICES CI
WHERE
	CI.INVOICEID = I.INVOICEID
AND	CI.COMPANYID = @COMP_ID
AND	CI.PAID <> '1900-01-01'
ORDER BY I.INVOICEID DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PCONTACT
(
	@CONT_ID INT,
	@PROP_ID INT
) AS


DECLARE @COMP_ID INT
SELECT @COMP_ID = COMPANY_ID FROM CONTACTS WHERE CONTACT_ID = @CONT_ID

SELECT
	ISNULL(C.TITLE,'') + ' ' + ISNULL(C.FIRSTNAME,'') + ' '  + ISNULL(LASTNAME,'') AS NAME,
	C.DIRECT_PHONE AS WKTEL,
	C.DIRECT_FAX AS FAX,
	C.MOBILE_PHONE AS MOBILE,
	C.DIRECT_EMAIL AS EMAIL,
	C.JOB_TITLE AS JT,
	C.NOTES,
	CO.COMPANY_NAME AS COMP
FROM
	CONTACTS C,
	COMPANIES CO
WHERE
	CONTACT_ID = @CONT_ID
AND	CO.COMPANY_ID = C.COMPANY_ID

SELECT CONTACT_TYPE FROM object_contact_type WHERE CONTACT_ID = @CONT_ID AND OBJECT_ID = @PROP_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PENDING_PROPERTY_RESIDENTS
(
	@PROP_ID INT
) AS

select 
	RO.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'No Name') + '  ' + ISNULL(LASTNAME,'No Name') AS NAME,
	CASE DATE_FROM
		WHEN 01/01/1900 THEN NULL
		ELSE DATE_FROM
	END AS DATE,
	CASE MAIN_RESIDENT
		WHEN 0 THEN 'No'
		ELSE 'Yes'
	END AS HEAD,
	ROOM
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROP_ID
and	getdate() < RO.date_FROM
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_PHOTO
(
	@P_ID INT
) AS

SELECT 
	P.FILESIZE,
	P.PHOTO,
	P.FILENAME
FROM 
	PHOTOS P 
WHERE 
	PHOTO_ID = @P_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_PHOTOS
(
	@P_ID NUMERIC,
	@TYPE INT
) AS

SELECT
	PHOTO_ID,
	THUMBNAIL,
	THUMBSIZE,
	FILENAME,
	DESCRIPTION,
	PARENT,
	RECORD_MODIFIER,
	IS_DEFAULT,	
	DATE_ENTERED
 FROM PHOTOS WHERE PARENT = @P_ID AND PHOTO_TYPE_ID = @TYPE
ORDER BY IS_DEFAULT DESC, DATE_ENTERED DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_PLACEMENT_PROPS AS


SELECT 
	O.OBJECT_ID,
	O.OBJECT_NAME
FROM
	OBJECTS O,
	OBJECT_STATUS_HISTORY OH,
	OBJECT_STATUS OS
WHERE
	O.OBJECT_ID = OH.OBJECT_ID
AND	OH.STATUS_ID = OS.STATUS_ID
AND	OS.MANAGED = 1
AND	((GETDATE() BETWEEN OH.DATE_FROM AND OH.DATE_TO) OR (GETDATE() > OH.DATE_FROM AND (OH.DATE_TO = '01/01/1900' OR OH.DATE_TO IS NULL)))
AND 	O.OBJECT_ID <> 0
AND	O.OBJECT_NAME <> ''
ORDER BY OBJECT_NAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PREVIOUS_PROPERTY_RESIDENTS
(
	@PROP_ID INT
) AS

select 
	RO.RESIDENT_ID,
	R.FIRSTNAME + ' ' + R.LASTNAME AS NAME,
	DATE_FROM AS DATE,
	DATE_TO AS DATETO,
	CASE MAIN_RESIDENT
		WHEN 0 THEN 'No'
		ELSE 'Yes'
	END AS HEAD
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROP_ID
and	getdate() > RO.date_to
and	RO.DATE_TO <> 01/01/1900
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE GET_PROPERTIES
(
	@SEARCH varchar(50),
	@crit varchar(50)
) AS

SET NOCOUNT ON

DECLARE @SQL VARCHAR(4000)
DECLARE @SQL1 VARCHAR(4000)

IF @SEARCH = 'POSTALCODE' OR @SEARCH = 'HOUSENAME'  OR @SEARCH = 'HOUSENUMBER' OR @SEARCH = 'OBJECT_NAME'  OR @SEARCH = 'STREETNAME' OR @SEARCH = 'CITY' OR @SEARCH = 'COUNTY' OR @SEARCH = 'DATE_ENTERED' OR @SEARCH = 'RETURNED_DATE_TO_OWNER'  OR @SEARCH = 'PROPERTY_ID' 
BEGIN
	SELECT @SQL = 'SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')) AS ADDRESS,
		CO.COMPANY_NAME AS OWNER,
		CO.COMPANY_ID
	FROM 
		OBJECTS O,
		COMPANIES CO,
		COMPANY_OBJECT OP
	WHERE
		O.OBJECT_ID = OP.OBJECT_ID
	AND	OP.COMPANY_ID = CO.COMPANY_ID
	AND	GETDATE() > OP.DATE_FROM
	AND 	(OP.DATE_TO IS NULL OR OP.DATE_TO > GETDATE())
	AND	' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
	GROUP BY
		O.OBJECT_ID,
		O.OBJECT_NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')),
		CO.COMPANY_NAME,
		CO.COMPANY_ID'
END
ELSE IF @SEARCH = 'CONTACT_NAME'
BEGIN
	SELECT @SQL = 'SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')) AS ADDRESS,
		CO.COMPANY_NAME AS OWNER,
		CO.COMPANY_ID
	FROM 
		OBJECTS O,
		OBJECT_CONTACT OC,	
		CONTACTS C,
		COMPANIES CO,
		COMPANY_OBJECT OP
	WHERE
		O.OBJECT_ID = OC.OBJECT_ID
	AND	OC.CONTACT_ID = C.CONTACT_ID
	AND	C.COMPANY_ID = CO.COMPANY_ID
	AND	O.OBJECT_ID = OP.OBJECT_ID
	AND	GETDATE() > OP.DATE_FROM
	AND 	(OP.DATE_TO IS NULL OR OP.DATE_TO > GETDATE())
	AND	C.COMPANY_ID = OP.COMPANY_ID
	AND	C.FIRSTNAME + '' '' + C.LASTNAME LIKE ''%' + @CRIT + '%''
	GROUP BY
		O.OBJECT_ID,
		O.OBJECT_NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')),
		CO.COMPANY_NAME,
		CO.COMPANY_ID'
END
ELSE IF @SEARCH = 'OWNER_NAME'
BEGIN
	SELECT @SQL = 'SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')) AS ADDRESS,
		CO.COMPANY_NAME AS OWNER,
		CO.COMPANY_ID
	FROM 
		OBJECTS O,
		COMPANIES CO,
		COMPANY_OBJECT OP
	WHERE
		O.OBJECT_ID = OP.OBJECT_ID
	AND	((GETDATE() BETWEEN OP.DATE_FROM AND ISNULL(DATE_TO, GETDATE())) OR (GETDATE() > OP.DATE_FROM AND ISNULL(DATE_TO,01/01/1900) = 01/01/1900))
	AND	CO.COMPANY_ID = OP.COMPANY_ID
	AND	CO.COMPANY_NAME LIKE ''%' + @CRIT + '%''
	GROUP BY
		O.OBJECT_ID,
		O.OBJECT_NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')),
		CO.COMPANY_NAME,
		CO.COMPANY_ID'
END
ELSE IF @SEARCH = 'STATUS_DESCRIPTION'
BEGIN
	SELECT @SQL = 'SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')) AS ADDRESS,
		CO.COMPANY_NAME AS OWNER,
		CO.COMPANY_ID
	FROM 
		OBJECTS O,
		OBJECT_CONTACT OC,	
		CONTACTS C,
		COMPANIES CO,
		OBJECT_STATUS ST,
		COMPANY_OBJECT OP
	WHERE
		O.OBJECT_ID = OC.OBJECT_ID
	AND	OC.CONTACT_ID = C.CONTACT_ID
	AND	C.COMPANY_ID = CO.COMPANY_ID
	AND	ST.STATUS_ID = O.STATUS_ID
	AND	O.OBJECT_ID = OP.OBJECT_ID
	AND	((GETDATE() BETWEEN OP.DATE_FROM AND ISNULL(DATE_TO, GETDATE())) OR (GETDATE() > OP.DATE_FROM AND ISNULL(DATE_TO,01/01/1900) = 01/01/1900))
	AND	C.COMPANY_ID = OP.COMPANY_ID
	AND	ST.STATUS_DESCRIPTION = ''' + @CRIT + '''
	GROUP BY
		O.OBJECT_ID,
		O.OBJECT_NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')),
		CO.COMPANY_NAME,
		CO.COMPANY_ID'
END
ELSE IF @SEARCH = 'DESCRIPTION'
BEGIN
	SELECT @SQL = 'SELECT DISTINCT
		O.OBJECT_ID AS PROP,
		O.OBJECT_NAME AS NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')) AS ADDRESS,
		CO.COMPANY_NAME AS OWNER,
		CO.COMPANY_ID
	FROM 
		OBJECTS O,
		OBJECT_CONTACT OC,	
		CONTACTS C,
		COMPANIES CO,
		AREA A,
		COMPANY_OBJECT OP
	WHERE
		O.OBJECT_ID = OC.OBJECT_ID
	AND	OC.CONTACT_ID = C.CONTACT_ID
	AND	C.COMPANY_ID = CO.COMPANY_ID
	AND	A.AREA_ID = O.AREA_ID
	AND	O.OBJECT_ID = OP.OBJECT_ID
	AND	GETDATE() > OP.DATE_FROM
	AND 	(OP.DATE_TO IS NULL OR OP.DATE_TO > GETDATE())
	AND	C.COMPANY_ID = OP.COMPANY_ID
	AND	A.DESCRIPTION = ''' + @CRIT + '''
	GROUP BY
		O.OBJECT_ID,
		O.OBJECT_NAME,
		LTRIM(ISNULL(O.HOUSENUMBER,'''') + '' '' + ISNULL(O.HOUSENAME,'''') + '' '' + 	ISNULL(O.STREETNAME,'''') + '' '' + ISNULL(O.CITY,'''') + '' '' + ISNULL(O.POSTALCODE,'''')),
		CO.COMPANY_NAME,
		CO.COMPANY_ID'
END

EXEC(@SQL)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROPERTY
(
	@PROP_ID INT
) AS

DECLARE @ACT_NR AS INT

select 
		@ACT_NR = count(*)
		from 
			RESIDENTS R,
			RESIDENT_OBJECT RO
		where 
			RO.object_id = @prop_id
		and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
		AND 	RO.RESIDENT_ID = R.RESIDENT_ID

SELECT
	O.OBJECT_NAME,
	O.PROPERTY_ID,
	O.KEY_NUMBER,
	O.HOUSENAME,
	O.STREETNAME,
	O.ADDRESS4,
	O.CITY,
	O.COUNTY,
	O.POSTALCODE,
	O.COUNTRY,
	O.AREA_ID,
	O.REGION_MANAGER,
	O.MAX_NR_RESIDENTS,
	@ACT_NR AS ACT_NR,
	CASE O.MAX_NR_RESIDENTS
		WHEN 0 THEN 0
		ELSE CONVERT(INT,(100/CONVERT(NUMERIC(18,2),O.MAX_NR_RESIDENTS))*@ACT_NR)
	END AS PERC_OCC,
	O.STATUS_ID,
	O.OBJECT_TYPE,
	CONVERT(VARCHAR(12),O.STAT_EFF,103) AS STAT_EFF,
	O.ACCOUNT_MANAGER,
	O.PROPERTY_MANAGER,
	O.PROPERTY_INSPECTOR,
	O.GUARDIAN_MANAGER,
	O.RECORD_MODIFIER,
	CONVERT(VARCHAR(12),O.DATE_MODIFIED,103) AS DATE_MODIFIED,
	CONVERT(VARCHAR(12),O.DATE_STARTED,103) AS DATE_STARTED,
	CONVERT(VARCHAR(12),O.DATE_STOPPED,103) AS DATE_STOPPED,
	O.MONTHLY_FEE,
	O.LIC_FEE,
	O.CALAM_LIMIT
FROM
	OBJECTS O
WHERE
	OBJECT_ID = @PROP_ID


SELECT
	C.COMPANY_ID,	
	C.COMPANY_NAME
FROM
	COMPANIES C,
	COMPANY_OBJECT CO
WHERE
	CO.OBJECT_ID = @PROP_ID
AND	CO.DATE_FROM < GETDATE()
AND	(CO.DATE_TO > GETDATE() OR CO.DATE_TO IS NULL)
AND	CO.COMPANY_ID = C.COMPANY_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE 	GET_PROPERTY_COMPANY
(
	@PROP_ID INT
) AS


SELECT 
	CO.COMPANY_ID
FROM 
	OBJECTS O,
	COMPANIES CO,
	COMPANY_OBJECT OP
WHERE
	O.OBJECT_ID = OP.OBJECT_ID
AND	OP.COMPANY_ID = CO.COMPANY_ID
AND	((GETDATE() BETWEEN OP.DATE_FROM AND ISNULL(DATE_TO, GETDATE())) OR (GETDATE() > OP.DATE_FROM AND ISNULL(DATE_TO,01/01/1900) = 01/01/1900))
AND	O.OBJECT_ID = @PROP_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROPERTY_COMPANY_CONTACTS
(
	@COMP_ID INT,
	@PROP_ID INT
) AS

select 
	ct.contact_id,
	CT.FIRSTNAME + ' ' + CT.LASTNAME AS CNAME,
	CCT.DESCRIPTION,
	CT.PHONE,
	C.COMPANY_NAME
from 
	COMPANIES C,
	CONTACTS CT,
	CONTACT_TYPES CCT,
	COMPANY_CONTACT CC
where 
	C.COMPANY_ID = @COMP_ID
AND 	C.COMPANY_ID = CC.COMPANY_ID
AND	C.COMPANY_ID = CT.COMPANY_ID
AND	CC.CONTACT_ID = CT.CONTACT_ID
AND	CC.CONTACT_TYPE *= CCT.CONTACT_TYPE
AND	CT.DATE_ENDED IS NULL
AND 	CT.CONTACT_ID NOT IN (select 
					ct.contact_id
				from 
					contacts ct,
					object_contact oc
				where 
					oc.contact_id = ct.contact_id
				and	getdate() > oc.date_start 
				and 	(getdate() < oc.date_end or oc.date_end is null)
				and	oc.object_id = @PROP_ID)
ORDER BY 
	CT.LASTNAME, CT.FIRSTNAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROPERTY_CONTACTS
(
	@PROP_ID INT
) AS

CREATE TABLE #R
	(CONTACT_ID INT,
	CNAME VARCHAR(2000),
	CONTACT_TYPE VARCHAR(2000),
	PHONE VARCHAR(200),
	COMPANY_NAME VARCHAR(2000))

INSERT INTO #R
select 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME,'No Name') AS CNAME,
	ISNULL(oct.contact_type,''),
	CT.DIRECT_PHONE,
	C.COMPANY_NAME
from 
	companies c,
	contacts ct,
	object_contact oc,
	object_contact_type oct
where 
	oc.contact_id = ct.contact_id
and	oc.object_id = @PROP_ID
and 	c.company_id = ct.company_id
and	ct.contact_id *= oct.contact_id
and	oc.object_id *= oct.object_id
group by 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME,'No Name'),
	ISNULL(oct.contact_type,''),
	CT.DIRECT_PHONE,
	C.COMPANY_NAME

UPDATE 
	#R
SET 
	CONTACT_TYPE = CTS.DESCRIPTION
FROM
	#R R,
	CONTACT_TYPES CTS
WHERE
	R.CONTACT_TYPE = CTS.CONTACT_TYPE





SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE GET_PROPERTY_CONTACTS_corr
(
	@PROP_ID INT
) AS

CREATE TABLE #R
	(CONTACT_ID INT,
	CNAME VARCHAR(2000))

INSERT INTO #R
select 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME,'No Name')
from 
	contacts ct,
	object_contact oc
where 
	oc.contact_id = ct.contact_id
and	oc.object_id = @PROP_ID
group by 
	ct.contact_id,
	ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME,'No Name')


INSERT INTO #R
SELECT
	R.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME, 'No Name')
FROM
	RESIDENTS R,
	RESIDENT_OBJECT RO
WHERE
	RO.OBJECT_ID = @PROP_ID
AND	RO.RESIDENT_ID = R.RESIDENT_ID
AND	RO.DATE_FROM < GETDATE()
AND	(RO.DATE_TO > GETDATE() OR RO.DATE_TO = 01/01/1900)


SELECT * FROM #R ORDER BY CNAME






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE GET_PROPERTY_CORR
(
	@PROP_ID INT
) AS



DECLARE @TGT VARCHAR(20)
DECLARE @TP VARCHAR(50)
DECLARE @CORR INT


CREATE TABLE #R
(	CORR_ID INT,
	C_DATE SMALLDATETIME,
	TYPE VARCHAR(50),
	TARGET VARCHAR(50),
	DIR VARCHAR(20),
	SENT_BY VARCHAR(50),
	[BULK] VARCHAR(200),
	DOCUMENT VARCHAR(200)
)

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD
WHERE
	C.OBJECT_ID = @PROP_ID
AND	C.C_TYPE = CT.TYPE_ID
AND	C.TARGET = RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC


INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	ISNULL(DT.DESCRIPTION,''),
	'Camelot',
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE 'NO' END AS [BULK],
	CD.FILENAME
FROM
	CORRESPONDENCE C,
	DOCUMENT_TYPES DT,
	DOCUMENT_CORRESPONDENCE DC,
	CORRESPONDENCE_DOCUMENTS CD,
	DOCUMENT_RECIPIENTS DR,
	EMPLOYEES E
WHERE
	C.OBJECT_ID = @PROP_ID
AND	CD.TYPE_ID *= DT.DOCUMENT_TYPE
AND	C.CORRESPONDENCE_ID = DC.CORRESPONDENCE_ID
AND	DC.DOCUMENT_ID = CD.DOCUMENT_ID
AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
AND	DR.RECIPIENT = E.EMPLOYEE_ID
AND	C.DIRECTION = 0
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	DT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CD.FILENAME
ORDER BY
	C.CORRESPONDENCE_DATE DESC

INSERT INTO #R
SELECT
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	CASE C.DIRECTION WHEN 1 THEN 'Sent' ELSE  'Recieved' END AS [DIR],
	C.SENDER,
	CASE C.[BULK] WHEN 1 THEN 'YES' ELSE  'NO' END AS [BULK],
	CE.SUBJECT
FROM
	CORRESPONDENCE C,
	CORRESPONDENCE_TYPES CT,
	RECIPIENT_TYPES RT,
	EMAIL_CORRESPONDENCE EC,
	CORRESPONDENCE_EMAIL CE
WHERE
	C.OBJECT_ID = @PROP_ID
AND	C.C_TYPE *= CT.TYPE_ID
AND	C.TARGET *= RT.TYPE_ID
AND	C.CORRESPONDENCE_ID = EC.CORR_ID
AND	EC.EMAIL_ID = CE.EMAIL_ID
GROUP BY
	C.CORRESPONDENCE_ID,
	C.CORRESPONDENCE_DATE,
	CT.DESCRIPTION,
	RT.DESCRIPTION,
	C.DIRECTION,
	C.SENDER,
	C.[BULK],
	CE.SUBJECT
ORDER BY
	C.CORRESPONDENCE_DATE DESC


DECLARE NBS CURSOR FOR
	SELECT 
		CORR_ID,
		TYPE,
		TARGET
	FROM 
		#R
	WHERE
		[BULK] = 'NO'
	AND	DIR = 'Sent'

OPEN NBS

FETCH NEXT FROM NBS INTO @CORR, @TP,@TGT

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @TGT = 'GUARDIAN'
	BEGIN
		IF @TP NOT LIKE '%EMAIL%'
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME,'No Name')
			FROM
				#R,
				DOCUMENT_CORRESPONDENCE DC,
				DOCUMENT_RECIPIENTS DR,
				RESIDENTS R
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
			AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
			AND	DR.RECIPIENT = R.RESIDENT_ID
		END
		ELSE
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(R.FIRSTNAME,'No Name') + ' ' + ISNULL(R.LASTNAME,'No Name')
			FROM
				#R,
				EMAIL_CORRESPONDENCE EC,
				EMAIL_RECIPIENTS ER,
				RESIDENTS R
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = EC.CORR_ID
			AND	EC.EMAIL_ID = ER.EMAIL_ID
			AND	ER.RECIPIENT = R.RESIDENT_ID
		END
	END
	ELSE IF @TGT = 'CONTACT'
	BEGIN
		IF @TP NOT LIKE '%EMAIL%'
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(C.FIRSTNAME,'No Name') + ' ' + ISNULL(C.LASTNAME,'No Name')
			FROM
				#R,
				DOCUMENT_CORRESPONDENCE DC,
				DOCUMENT_RECIPIENTS DR,
				CONTACTS C
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
			AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
			AND	DR.RECIPIENT = C.CONTACT_ID
		END
		ELSE
		BEGIN
			UPDATE 
				#R
			SET
				[BULK] = ISNULL(C.FIRSTNAME,'No Name') + ' ' + ISNULL(C.LASTNAME,'No Name')
			FROM
				#R,
				EMAIL_CORRESPONDENCE EC,
				EMAIL_RECIPIENTS ER,
				CONTACTS C
			WHERE
				#R.CORR_ID = @CORR
			AND	#R.CORR_ID = EC.CORR_ID
			AND	EC.EMAIL_ID = ER.EMAIL_ID
			AND	ER.RECIPIENT = C.CONTACT_ID
		END		
	END
	ELSE IF @TGT = 'CAMELOT'
	BEGIN
		UPDATE 
			#R
		SET
			[BULK] = ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name')
		FROM
			#R,
			DOCUMENT_CORRESPONDENCE DC,
			DOCUMENT_RECIPIENTS DR,
			EMPLOYEES E
		WHERE
			#R.CORR_ID = @CORR
		AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
		AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
		AND	DR.RECIPIENT = E.EMPLOYEE_ID
	END
	
	FETCH NEXT FROM NBS INTO @CORR, @TP,@TGT


END

CLOSE NBS
DEALLOCATE NBS

DECLARE NBE CURSOR FOR
	SELECT 
		CORR_ID,
		TYPE,
		TARGET
	FROM 
		#R
	WHERE
		[BULK] = 'NO'
	AND	DIR <> 'Sent'

OPEN NBE

FETCH NEXT FROM NBE INTO @CORR, @TP,@TGT

WHILE @@FETCH_STATUS = 0
BEGIN
	UPDATE 
		#R
	SET
		[BULK] = ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name')
	FROM
		#R,
		DOCUMENT_CORRESPONDENCE DC,
		DOCUMENT_RECIPIENTS DR,
		EMPLOYEES E
	WHERE
		#R.CORR_ID = @CORR
	AND	#R.CORR_ID = DC.CORRESPONDENCE_ID
	AND	DC.DOCUMENT_ID = DR.DOCUMENT_ID
	AND	DR.RECIPIENT = E.EMPLOYEE_ID
	
	FETCH NEXT FROM NBE INTO @CORR, @TP,@TGT
END

CLOSE NBE
DEALLOCATE NBE




SELECT * FROM #R ORDER BY C_DATE



--SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROPERTY_GUARDIANS_COMPLAINTS
(
	@PROP_ID INT,
	@NAME_ID INT
) AS


CREATE TABLE #R (RESIDENT_ID INT, GNAME VARCHAR(2000))

DECLARE @CNT INT


SELECT
	@CNT =  COUNT(*)
	from 
		RESIDENTS R,
		RESIDENT_OBJECT RO
	where 
		RO.object_id = @PROP_ID
	and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
	AND 	RO.RESIDENT_ID = R.RESIDENT_ID
	AND	R.RESIDENT_ID = @NAME_ID

IF @CNT = 0
BEGIN
	INSERT INTO 
		#R
	SELECT
		RESIDENT_ID,
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') 
	FROM
		RESIDENTS
	WHERE
		RESIDENT_ID = @NAME_ID
END

INSERT INTO #R
select 
	RO.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.LASTNAME,'') AS GNAME
from 
	RESIDENTS R,
	RESIDENT_OBJECT RO
where 
	RO.object_id = @PROP_ID
and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
AND 	RO.RESIDENT_ID = R.RESIDENT_ID
ORDER BY
	R.LASTNAME ASC

SELECT * FROM #R ORDER BY GNAME







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROPERTY_NOTES
(
	@PROP_ID INT
) AS


SELECT
	N.ACTIVITY_ID AS NOTE_ID, 
	N.DATE_ENTERED AS DATE,
	SUBSTRING(N.REGARDING,1,200) + ' ...' AS DESCRIPTION,
	E.FIRSTNAME + ' ' + E.LASTNAME AS ACCOUNT_MANAGER	
FROM 
	NOTES N,
	CONTACTS C,
	EMPLOYEES E 
WHERE 
	N.OBJECT_ID = @PROP_ID
AND	N.CONTACT_ID *= C.CONTACT_ID
AND	N.RECORD_MANAGER = E.EMPLOYEE_ID
ORDER BY
	N.ACTIVITY_DATE DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_PROP_CORR_RECIPIENTS
(
	@PROP_ID INT,
	@TARGET INT,
	@GCORR INT
) AS


IF @GCORR = 2
BEGIN
	IF @TARGET = 2
	BEGIN
		SELECT DISTINCT
			CS.CONTACT_ID,
			CS.DIRECT_EMAIL AS EMAIL,
			ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
			C.COMPANY_NAME,
			CS.JOB_TITLE,
			ISNULL(A.HOUSENAME,'') + ' ' + ISNULL(A.STREETNAME,'') + ' ' + ISNULL(A.ADDRESS4,'') + ' '  + ISNULL(A.ADDRESS5,'') + ' ' + ISNULL(A.CITY,'') AS ADDRESS
		FROM
			CONTACTS CS,
			COMPANY_ADDRESS CA,
			ADDRESSES A,
			COMPANY_CONTACT CC,
			COMPANIES C,
			OBJECT_CONTACT OC
		WHERE
			CS.CONTACT_ID = CC.CONTACT_ID
		AND	CC.COMPANY_ID = C.COMPANY_ID
		AND	C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		AND 	OC.OBJECT_ID = @PROP_ID
		AND	CS.CONTACT_ID = OC.CONTACT_ID
		AND	(OC.DATE_END > GETDATE() OR OC.DATE_END IS NULL)
		AND	DBO.VALIDATE_EMAIL(CS.DIRECT_EMAIL)=1
		ORDER BY
			ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
			
	END
	ELSE IF @TARGET = 1
	BEGIN		
		select 
			r.resident_id,
			R.PRIVATE_EMAIL AS EMAIL,
			isnull(r.firstname,'') + ' ' + isnull(r.lastname,'') as name,
			convert(varchar(20),ro.date_from, 103) as date_from,	
			case convert(varchar(20),ro.date_to,103)
				when '01/01/1900' then ''
				else convert(varchar(20),ro.date_to,103)
			end as date_to,
			o.object_name as property,
			CASE RO.MAIN_RESIDENT
					WHEN 1 THEN 'YES'
					ELSE 'NO'
				END AS HEAD,
			ro.room
		from 
			residents r, resident_object ro, objects o
		where 
		 	r.resident_id = ro.resident_id
		and	r.firstname is not null
		and	r.lastname is not null
		and	ro.date_from < getdate()
		and	ro.object_id = o.object_id
		AND	O.OBJECT_ID = @PROP_ID
		and	(ro.date_to = '01/01/1900' or ro.date_to is null 
		and 	 (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))
	END
END
ELSE
BEGIN
	IF @TARGET = 2
	BEGIN
		
		SELECT DISTINCT
			CS.CONTACT_ID,
			CS.DIRECT_EMAIL AS EMAIL,
			ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'') AS NAME,
			C.COMPANY_NAME,
			CS.JOB_TITLE,
			ISNULL(A.HOUSENAME,'') + ' ' + ISNULL(A.STREETNAME,'') + ' ' + ISNULL(A.ADDRESS4,'') + ' '  + ISNULL(A.ADDRESS5,'') + ' ' + ISNULL(A.CITY,'') AS ADDRESS
		FROM
			CONTACTS CS,
			COMPANY_ADDRESS CA,
			ADDRESSES A,
			COMPANY_CONTACT CC,
			COMPANIES C,
			OBJECT_CONTACT OC
		WHERE
			CS.CONTACT_ID = CC.CONTACT_ID
		AND	CC.COMPANY_ID = C.COMPANY_ID
		AND	C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		AND 	OC.OBJECT_ID = @PROP_ID
		AND	CS.CONTACT_ID = OC.CONTACT_ID
		AND	(OC.DATE_END > GETDATE() OR OC.DATE_END IS NULL)
		AND	CS.DIRECT_EMAIL IS NOT NULL
		AND	DBO.VALIDATE_EMAIL(CS.DIRECT_EMAIL)=1
		ORDER BY
			ISNULL(CS.FIRSTNAME,'') + ' ' + ISNULL(CS.LASTNAME,'')
			
	END
	ELSE IF @TARGET = 1
	BEGIN		
		select 
			r.resident_id,
			R.PRIVATE_EMAIL AS EMAIL,
			isnull(r.firstname,'') + ' ' + isnull(r.lastname,'') as name,
			convert(varchar(20),ro.date_from, 103) as date_from,	
			case convert(varchar(20),ro.date_to,103)
				when '01/01/1900' then ''
				else convert(varchar(20),ro.date_to,103)
			end as date_to,
			o.object_name as property,
			CASE RO.MAIN_RESIDENT
					WHEN 1 THEN 'YES'
					ELSE 'NO'
				END AS HEAD,
			ro.room
		from 
			residents r, resident_object ro, objects o
		where 
		 	r.resident_id = ro.resident_id
		and	r.firstname is not null
		and	r.lastname is not null
		AND	R.PRIVATE_EMAIL IS NOT NULL
		and	R.PRIVATE_EMAIL <> ''
		AND	O.OBJECT_ID = @PROP_ID
		and	ro.date_from < getdate()
		and	ro.object_id = o.object_id
		and	(ro.date_to = '01/01/1900' or ro.date_to is null 
		and 	 (ro.date_from = (select max(date_from) from resident_object where resident_id = r.resident_id)))
	END
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_PROP_RESIDENTS
(
	@PROP_ID INT
)  AS

SELECT
	R.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'No Name') + '  ' + ISNULL(LASTNAME,'No Name') AS NAME
FROM
	RESIDENTS R,
	RESIDENT_OBJECT O
WHERE
	O.RESIDENT_ID = R.RESIDENT_ID
AND	O.OBJECT_ID = @PROP_ID
AND	((GETDATE() BETWEEN O.DATE_FROM AND ISNULL(O.DATE_TO, DATEADD(D,1,GETDATE()))) OR O.DATE_TO = 01/01/1900)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_READING
(
	@READ_ID INTEGER
) AS


SELECT
	M.LOCATION,
	CONVERT(VARCHAR(12), MR.DATED,103) AS DATED,
	MR.READING,
	MR.OPERATOR
FROM
	METER_READINGS MR,
	METERS M
WHERE
	MR.READING_ID = @READ_ID
AND	M.METER_ID = MR.METER_ID









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_READINGS
(
	@MET_ID INTEGER
) AS


select 
	R.RATE_DESC,
	R.RATE_ID
from 
	RATES R,
	meter_rates MR
where 
	MR.meter_id =@met_id
AND	MR.RATE_ID = R.RATE_ID
ORDER BY MR.RATE_ID

DECLARE @RCNT INT

SELECT
	@RCNT = COUNT(*)
from 
	RATES R,
	meter_rates MR
where 
	MR.meter_id =@met_id
AND	MR.RATE_ID = R.RATE_ID

IF @RCNT > 0
BEGIN
	DECLARE @IRATE VARCHAR(4)
	DECLARE @RATE_ID VARCHAR(4)
	DECLARE @CNT INT
	
	DECLARE @SSQL VARCHAR(4000)
	DECLARE @FSQL VARCHAR(4000)
	DECLARE @WSQL VARCHAR(4000)
	
	DECLARE RATES CURSOR FOR
	select 
		R.RATE_ID
	from 
		RATES R,
		meter_rates MR
	where 
		MR.meter_id =@met_id
	AND	MR.RATE_ID = R.RATE_ID
	ORDER BY MR.RATE_ID
	
	SELECT @CNT = 0
	SELECT @SSQL = 'SELECT '
	SELECT @FSQL = ' FROM '
	SELECT @WSQL= ' WHERE '
	
	OPEN RATES
	
	FETCH NEXT FROM RATES INTO @RATE_ID
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @CNT = 0
		BEGIN
			SELECT @IRATE = @RATE_ID
			SELECT @SSQL = @SSQL + 'CONVERT(VARCHAR(20),MR' + @RATE_ID + '.DATED,103) AS DATED, MR' + @RATE_ID + '.READING'
			SELECT @FSQL = @FSQL + ' METER_READINGS MR' + @RATE_ID
			SELECT @WSQL = @WSQL + 'MR'+ @RATE_ID + '.METER_ID = ' +CONVERT(VARCHAR(5),@MET_ID) + ' AND MR' + @RATE_ID + '.RATE_ID = ' + @RATE_ID	
		END
		ELSE
		BEGIN
			SELECT @SSQL =@SSQL + ' , MR' + @RATE_ID + '.READING'
			SELECT @FSQL = @FSQL + ', METER_READINGS MR' + @RATE_ID
			SELECT @WSQL = @WSQL + ' AND MR' + @IRATE + '.DATED *= MR' + @RATE_ID + '.DATED AND MR'+ @IRATE + '.METER_ID *= MR' + @RATE_ID + '.METER_ID AND MR' + @RATE_ID + '.RATE_ID = ' + @RATE_ID
		END
		SELECT @CNT = @CNT + 1
		FETCH NEXT FROM RATES INTO @RATE_ID
	END
	
	CLOSE RATES
	
	DEALLOCATE RATES
	
	SELECT @WSQL = @WSQL + ' ORDER BY CONVERT(SMALLDATETIME,MR' + @IRATE + '.DATED,103) DESC'
	
--	SELECT @SSQL
--	SELECT @FSQL
--	SELECT @WSQL

	EXEC(@SSQL+@FSQL+@WSQL)
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_REPORTS AS

SELECT * FROM REPORTS
ORDER BY REPORT_NAME








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_RESOLVED_INCIDENTS
(
	@PROPID INT
) AS

SELECT 
	CH.DATE_ENTERED,
	C.COMPLAINT_ID AS INC,
	C.COMPLAINT_DATE AS INC_DATE,
	C.DESCRIPTION,
	CH.ACTION_UNDERTAKEN,
	CS.DESCRIPTION AS STATUS
FROM
	COMPLAINTS C,
	OBJECT_COMPLAINTS OC,
	COMPLAINT_URGENCY U,
	COMPLAINT_HISTORY CH,
	COMPLAINT_STATUS CS
WHERE
	C.COMPLAINT_ID = OC.COMPLAINT_ID
AND	OC.OBJECT_ID = @PROPID
AND	U.URGENCY_ID = C.URGENCY
AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
AND	CH.ACTION_ID = (SELECT MAX(ACTION_ID) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
AND	CH.STATUS_CODE = CS.STATUS_ID
AND	CS.RESOLVED = 1
GROUP BY
	CH.DATE_ENTERED,
	C.COMPLAINT_ID,
	C.COMPLAINT_DATE,
	C.DESCRIPTION,
	CH.ACTION_UNDERTAKEN,
	CS.DESCRIPTION
ORDER BY CH.DATE_ENTERED DESC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ROUTES_ACTIVE AS

SELECT 
	R.ROUTEID AS ROUTE_ID,
	R.NAME,
	(SELECT O.OBJECT_NAME FROM OBJECTS O, OBJECT_ROUTE OB WHERE O.OBJECT_ID = OB.OBJECT_ID AND ROUTE_ID = R.ROUTEID AND ORDER_NO = (SELECT MIN(ORDER_NO) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID)) AS FIRSTPROP,
	(SELECT O.OBJECT_NAME FROM OBJECTS O, OBJECT_ROUTE OB WHERE O.OBJECT_ID = OB.OBJECT_ID AND ROUTE_ID = R.ROUTEID AND ORDER_NO = (SELECT MAX(ORDER_NO) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID)) AS LASTPROP,
	(SELECT COUNT(*) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID GROUP BY R.ROUTEID) AS NUM_PROP,
	(SELECT MAX(INSP_DATE) FROM ROUTE_INSPECTIONS WHERE ROUTE_ID = R.ROUTEID) AS LASTINSP
FROM 
	ROUTES R
WHERE
	R.ACTIVE = 1
ORDER BY
	R.NAME

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ROUTES_OLD AS

SELECT 
	R.ROUTEID AS ROUTE_ID,
	R.NAME,
	(SELECT O.OBJECT_NAME FROM OBJECTS O, OBJECT_ROUTE OB WHERE O.OBJECT_ID = OB.OBJECT_ID AND ROUTE_ID = R.ROUTEID AND ORDER_NO = (SELECT MIN(ORDER_NO) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID)) AS FIRSTPROP,
	(SELECT O.OBJECT_NAME FROM OBJECTS O, OBJECT_ROUTE OB WHERE O.OBJECT_ID = OB.OBJECT_ID AND ROUTE_ID = R.ROUTEID AND ORDER_NO = (SELECT MAX(ORDER_NO) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID)) AS LASTPROP,
	(SELECT COUNT(*) FROM OBJECT_ROUTE WHERE ROUTE_ID = R.ROUTEID GROUP BY R.ROUTEID) AS NUM_PROP,
	(SELECT MAX(INSP_DATE) FROM ROUTE_INSPECTIONS WHERE ROUTE_ID = R.ROUTEID) AS LASTINSP
FROM 
	ROUTES R
WHERE
	R.ACTIVE = 0
ORDER BY
	R.ROUTEID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ROUTE_DETAILS
(
	@ROUTE_ID INT
) AS

SELECT
	NAME,
	ACTIVE,
	(SELECT ISNULL(CONVERT(VARCHAR(20),MAX(INSP_DATE),103),'') FROM ROUTE_INSPECTIONS WHERE ROUTE_ID = ROUTEID) AS LASTINSP
FROM
	ROUTES
WHERE
	ROUTEID = @ROUTE_ID

SELECT
	O.OBJECT_ID AS PROP_ID,
	O.OBJECT_NAME AS PROP_NAME
FROM
	OBJECTS O,
	OBJECT_ROUTE R
WHERE
	R.ROUTE_ID = @ROUTE_ID
AND	R.OBJECT_ID = O.OBJECT_ID
ORDER BY
	R.ORDER_NO

SELECT
	O.OBJECT_ID AS PROP_ID,
	O.OBJECT_NAME AS PROP_NAME
FROM
	OBJECTS O,
	OBJECT_STATUS OS
WHERE
	O.STATUS_ID = OS.STATUS_ID
AND	OS.MANAGED = 1
AND	O.OBJECT_NAME <> ''
AND	O.OBJECT_ID NOT IN (SELECT OBJECT_ID FROM OBJECT_ROUTE WHERE ROUTE_ID = @ROUTE_ID)
ORDER BY
	O.OBJECT_NAME ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_ROUTE_PROPERTIES
(
	@ROUTE_ID INT
) AS

SELECT
	OBJECT_ID AS PROP_ID
FROM
	OBJECT_ROUTE
WHERE
	ROUTE_ID = @ROUTE_ID
ORDER BY
	ORDER_NO ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_RPT_PROPERTIES AS


CREATE TABLE #R  
([OBJECT_ID] INT, [OBJECT_NAME] VARCHAR(500))

INSERT INTO #R SELECT 0, 'All'

INSERT INTO #R
SELECT OBJECT_ID, OBJECT_NAME FROM OBJECTS ORDER BY OBJECT_NAME


SELECT * FROM #R







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO












CREATE PROCEDURE GET_SCONTACTS
(
	@SEARCH varchar(50),
	@crit varchar(50)
) AS

SET NOCOUNT ON

DECLARE @SQL VARCHAR(4000)


	SELECT @SQL = 'select 
				ct.contact_id,
				ISNULL(CT.FIRSTNAME,''No Name'') +'' '' + ISNULL(CT.LASTNAME, ''No Null'') AS CNAME,
				CT.JOB_TITLE AS DESCRIPTION,
				CT.DIRECT_PHONE AS PHONE,
				C.COMPANY_NAME,
				C.COMPANY_ID
			from 
				COMPANIES C,
				CONTACTS CT
			where 
				C.COMPANY_ID = CT.COMPANY_ID
			AND	CT.CONTACT_ID IN (SELECT CONTACT_ID FROM COMPANY_CONTACT WHERE COMPANY_ID = c.company_id GROUP BY CONTACT_ID)
			AND	CT.DATE_ENDED IS NULL
			AND	' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			ORDER BY 
				ISNULL(CT.FIRSTNAME,''No Name'') + '' '' + ISNULL(CT.LASTNAME, ''No Null'')'

EXEC(@SQL)






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SEARCH_GUARDIANS
(
	@SEARCH varchar(50),
	@crit varchar(50)
) AS

SET NOCOUNT ON

DECLARE @SQL VARCHAR(4000)


	SELECT @SQL = 'SELECT
				ISNULL(R.FIRSTNAME,''No Name'') + ''  '' + ISNULL(R.LASTNAME,''No Name'') AS NAME,
				R.RESIDENT_ID,
				O.OBJECT_ID,
				OC.COMPANY_ID,
				C.COMPANY_NAME,
				O.OBJECT_NAME,
				PR.DATE_FROM AS DATE,
				CASE PR.MAIN_RESIDENT
					WHEN 0 THEN ''No''
					ELSE ''Yes''
				END AS HEAD
			FROM
				RESIDENTS R,
				RESIDENT_OBJECT PR,
				OBJECTS O,
				COMPANY_OBJECT OC,
				COMPANIES C
			WHERE
				R.RESIDENT_ID = PR.RESIDENT_ID
			AND	GETDATE() > PR.DATE_FROM 
			AND 	(PR.DATE_TO IS NULL OR PR.DATE_TO = 01/01/1900)
			AND	PR.OBJECT_ID = O.OBJECT_ID
			AND	' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			AND	O.OBJECT_ID = OC.OBJECT_ID
			AND	GETDATE() > OC.DATE_FROM AND OC.DATE_TO IS NULL
			AND	OC.COMPANY_ID = C.COMPANY_ID
			ORDER BY
				R.LASTNAME, R.FIRSTNAME'

EXEC(@SQL)






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SEARCH_OLD_GUARDIANS
(
	@SEARCH varchar(50),
	@crit varchar(50)
) AS

SET NOCOUNT ON

DECLARE @SQL VARCHAR(4000)


	SELECT @SQL = 'SELECT
				ISNULL(R.FIRSTNAME,''No Name'') + ''  '' + ISNULL(R.LASTNAME,''No Name'') AS NAME,
				R.RESIDENT_ID,
				O.OBJECT_ID,
				OC.COMPANY_ID,
				C.COMPANY_NAME,
				O.OBJECT_NAME,
				PR.DATE_FROM AS DATE,
				PR.DATE_TO AS DATETO,
				CASE PR.MAIN_RESIDENT
					WHEN 0 THEN ''No''
					ELSE ''Yes''
				END AS HEAD
			FROM
				RESIDENTS R,
				RESIDENT_OBJECT PR,
				OBJECTS O,
				COMPANY_OBJECT OC,
				COMPANIES C
			WHERE
				R.RESIDENT_ID = PR.RESIDENT_ID
			AND	GETDATE() > ISNULL(PR.DATE_TO,GETDATE())
			AND	PR.OBJECT_ID = O.OBJECT_ID
			AND	' + @SEARCH + ' LIKE ''%' + @CRIT + '%''
			AND	O.OBJECT_ID = OC.OBJECT_ID
			AND	GETDATE() > OC.DATE_FROM AND OC.DATE_TO IS NULL
			AND	OC.COMPANY_ID = C.COMPANY_ID
			ORDER BY
				R.LASTNAME, R.FIRSTNAME'

EXEC(@SQL)






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SECURITIES
(
	@PROPID INT
) AS

SELECT
	S.SECURITY_ID AS SEC,
	ST.DESCRIPTION AS SECDESC,
	ISNULL(S.DESCRIPTION,'') AS ODESC,
	ISNULL(S.CODE,'') AS CODE,
	ISNULL(S.EM_CONT,'') AS EM_CONT,
	ISNULL(S.CONT_NO,'') AS CONT_NO	
FROM
	SECURITIES S,
	OBJECT_SECURITIES O,
	SECURITY_TYPES ST
WHERE
	S.SECURITY_TYPE = ST.SECURITY_TYPE
AND	O.SECURITY_ID = S.SECURITY_ID
AND	O.OBJECT_ID = @PROPID
ORDER BY
	S.IN_USE DESC,
	S.DESCRIPTION ASC








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SECURITY
(
	@SEC_ID INT
) AS

SELECT
	SECURITY_TYPE,
	DESCRIPTION,
	LOCATION,
	SERIAL_NUMBER,
	CONVERT(varchar(12),DATE_INSTALLED,103) AS DATE_INSTALLED,
	CONVERT(varchar(12),DATE_REMOVED,103) AS DATE_REMOVED,
	CONVERT(varchar(12),DATE_LAST_CHECK,103) AS DATE_LAST_CHECK,
	CONVERT(varchar(12),DATE_NEXT_CHECK,103) AS DATE_NEXT_CHECK,
	MAINT_ID,
	REMARKS,
	RESIDENT_ID,
	RECORD_MANAGER,
	CONVERT(varchar(12),DATE_MODIFIED,103) AS DATE_MODIFIED,
	PHOTO_ID,
	ISNULL(IN_USE,1) AS IN_USE,
	CODE,
	EM_CONT,
	CONT_NO
FROM
	SECURITIES
WHERE
	SECURITY_ID = @SEC_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SECURITY_TYPES AS

SELECT * FROM SECURITY_TYPES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_STATUS_HIST
(
	@PROPID INT
) AS

select 
	o.status_id,
	s.status_description as status,
	CASE o.date_from
		WHEN 1/1/1900 THEN NULL
		ELSE O.DATE_FROM END as date 
from 
	object_status_history o,
	object_status s
where
	o.status_id = s.status_id
and	object_id = @PROPID
order by date_from asc








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_STATUS_HIST_CONT
(
	@CONTID INT
) AS

select 
	o.status_id,
	s.description as status,
	CASE o.date_from
		WHEN 1/1/1900 THEN NULL
		ELSE O.DATE_FROM END as date 
from 
	CONTACT_status_history o,
	CONTACT_status s
where
	o.status_id = s.CONTACT_status_id
and	CONTACT_ID = @CONTID
order by date_from asc








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE GET_SUPPLIERS AS

SELECT * FROM UTILITY_SUPPLIERS









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_TITLES AS

CREATE TABLE #R (TID INT, TITLE VARCHAR(50))


INSERT INTO #R SELECT 0, ''

INSERT INTO #R
SELECT 
	TITLE_ID, TITLE FROM TITLES ORDER BY TITLE ASC


SELECT * FROM #R

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE PROCEDURE GET_UNSENT_INSPECTIONS AS

SELECT 
	OC.OBJECT_CHECK_ID as INSP_ID,
	O.OBJECT_NAME,
	
	(SELECT 
		COUNT(*) 
	FROM 
		CONTACTS C,
		OBJECT_CONTACT_TYPE OCT 
	WHERE 
		OCT.OBJECT_ID = O.OBJECT_ID 
	AND 	OCT.CONTACT_TYPE = 10
	AND	OCT.CONTACT_ID = C.CONTACT_ID
	AND	(RTRIM(C.DIRECT_EMAIL) = '' OR C.DIRECT_EMAIL IS NULL)) as PAPER,
	(SELECT 
		COUNT(*) 
	FROM 
		CONTACTS C,
		OBJECT_CONTACT_TYPE OCT 
	WHERE 
		OCT.OBJECT_ID = O.OBJECT_ID 
	AND 	OCT.CONTACT_TYPE = 10
	AND	OCT.CONTACT_ID = C.CONTACT_ID
	AND	RTRIM(C.DIRECT_EMAIL) <>''
	AND	C.DIRECT_EMAIL IS NOT NULL) as EMAIL,
	CONVERT(VARCHAR(20),OC.DATE_ENTERED,103)  AS INSP_DATE
FROM
	OBJECTS O,
	OBJECT_CHECKS OC
WHERE
	OC.OBJECT_ID = O.OBJECT_ID
AND	OC.REPORT_SENT = 0
ORDER BY
	OC.DATE_ENTERED ASC




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE GET_USER
(
	@UID INT
) AS

select 
	e.employee_id as id,
	e.firstname + ' ' + e.lastname as name,
	e.userid as uname,
	convert(varchar(1),e.permissions) as permission,
	E.JOB_TITLE,
	ut.menu,
	E.ACCMAN,
	e.email,
	E.DIRECT_PHONE,
	E.WORK_MOBILE,
	E.PRIVATE_MOBILE
from
	EMPLOYEES e,
	user_types ut
where
	e.EMPLOYEE_ID = @UID
and	e.user_type = ut.user_type_id
and	e.active = 1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_VET_SCAN
(
	@SCAN_ID INT
) AS


SELECT
	SCAN_SIZE,
	SCAN_NAME,
	SCAN
FROM
	VET_SCANS
WHERE
	VS_ID = @SCAN_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE GET_VET_SCANS
(
	@RES_ID INT
)AS


SELECT
	VS_ID,
	DESCRIPTION,
	DATE_ENTERED
FROM
	VET_SCANS
WHERE
	RESIDENT_ID = @RES_ID
ORDER BY
	DATE_ENTERED DESC







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GET_VISIT_ADDRESS 
(
	@COMP INT
)AS


SELECT
	A.HOUSENAME,
	A.STREETNAME,
	A.ADDRESS4,
	A.ADDRESS5,
	A.CITY,
	A.POSTALCODE,
	A.COUNTRY,
	A.COUNTY,
	A.AREA_ID,
	ISNULL(E.FIRSTNAME,'No Name') + ' ' + ISNULL(E.LASTNAME,'No Name') AS NAME,
	CONVERT(VARCHAR(20),DATE_ENTERED,103) AS ENTERED
FROM
	ADDRESSES A,
	COMPANY_ADDRESS CA,
	EMPLOYEES E
WHERE
	CA.COMPANY_ID = @COMP
AND	CA.ADDRESS_TYPE = 2
AND	CA.ADDRESS_ID = A.ADDRESS_ID
AND	A.RECORD_MANAGER *= E.EMPLOYEE_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_CORRESPONDENCE
(
	@C_TYPE INT,
	@TARGET INT,
	@BULK INT,
	@SENDER VARCHAR(50),
	@DIR INT,
	@PROP_ID INT,
	@COMP_ID INT
) AS

IF(@TARGET = 0 OR @TARGET=3)
BEGIN
	SELECT @TARGET = 2
END

INSERT INTO CORRESPONDENCE
SELECT
	@C_TYPE,
	GETDATE(),
	@SENDER,
	@DIR,
	@TARGET,
	@BULK,
	@PROP_ID,
	@COMP_ID

SELECT @@IDENTITY




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_CORRESPONDENCE_DOCUMENT
(
	@CORR INT,
	@DOC_ID INT
)
AS

INSERT INTO DOCUMENT_CORRESPONDENCE SELECT @DOC_ID, @CORR








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_CORRESPONDENCE_EMAIL
(
	@CORR INT,
	@EMAIL_ID INT
)
AS

INSERT INTO EMAIL_CORRESPONDENCE SELECT @EMAIL_ID, @CORR






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_CORR_DOC
(
	@MERGE_FILE IMAGE,
	@FILESIZE INT,
	@FILENAME VARCHAR(500)
) AS

INSERT INTO CORRESPONDENCE_DOCUMENTS SELECT @MERGE_FILE, @FILESIZE, @FILENAME,0

SELECT @@IDENTITY






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_CORR_EMAIL
(
	@SUBJECT VARCHAR(4000),
	@BODY TEXT
) AS

INSERT INTO CORRESPONDENCE_EMAIL SELECT @SUBJECT, @BODY

SELECT @@IDENTITY






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_DOCUMENT_RECIPIENT
(
	@DOC_ID INT,
	@RECIP INT
) AS

INSERT INTO DOCUMENT_RECIPIENTS
SELECT 
	@DOC_ID,
	@RECIP








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO






CREATE PROCEDURE INSERT_EMAIL_DOCUMENT
(
	@EMAIL_ID INT,
	@DOC_ID INT
) AS

INSERT INTO
	EMAIL_DOCUMENTS
SELECT
	@EMAIL_ID,
	@DOC_ID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_EMAIL_PROPERTY
(
	@CORR_ID INT,
	@PROP INT
) AS

INSERT INTO
	EMAIL_PROPERTY
SELECT
	@CORR_ID,
	@PROP








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE INSERT_EMAIL_RECIPIENT
(
	@EMAIL_ID INT,
	@EMAIL VARCHAR(250),
	@TO_TYPE INT
) AS

DECLARE @CNT INT

SELECT @CNT = COUNT(*) FROM EMPLOYEES WHERE EMAIL = @EMAIL

IF @CNT > 0
BEGIN
	INSERT INTO
		EMAIL_RECIPIENTS
	SELECT
		@EMAIL_ID,
		EMPLOYEE_ID,
		4,
		@TO_TYPE
	FROM
		EMPLOYEES
	WHERE
		EMAIL = @EMAIL
END
ELSE
BEGIN
	SELECT @CNT = COUNT(*) FROM RESIDENTS WHERE PRIVATE_EMAIL = @EMAIL
	IF @CNT > 0
	BEGIN
		INSERT INTO
			EMAIL_RECIPIENTS
		SELECT
			@EMAIL_ID,
			RESIDENT_ID,
			1,
			@TO_TYPE
		FROM
			RESIDENTS
		WHERE
			PRIVATE_EMAIL = @EMAIL
	END
	ELSE
	BEGIN
		SELECT @CNT = COUNT(*) FROM CONTACTS WHERE DIRECT_EMAIL = @EMAIL
		IF @CNT > 0
		BEGIN
			INSERT INTO
				EMAIL_RECIPIENTS
			SELECT
				@EMAIL_ID,
				CONTACT_ID,
				3,
				@TO_TYPE
			FROM
				CONTACTS
			WHERE
				DIRECT_EMAIL = @EMAIL
		END
		ELSE
		BEGIN
			INSERT INTO
				EMAIL_RECIPIENTS_NO_CRM
			SELECT
				@EMAIL_ID,
				@EMAIL,
				@TO_TYPE		
		END

	END
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_INSP_COMMENT
(
	@INSP INT,
	@COMM_ID INT
) AS

INSERT INTO SELECTED_INSP_COMMENTS
	SELECT 
		@INSP,
		@COMM_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_INVOICE_ITEM
(
	@INVOICE_ID INT,
	@DESCRIPTION VARCHAR(50),
	@AMOUNT VARCHAR(10),
	@VAT VARCHAR(10)
) AS

INSERT INTO
	INVOICE_ITEMS
SELECT
	@INVOICE_ID,
	@DESCRIPTION,
	@AMOUNT,
	@VAT








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_METER_RATE
(
	@RATE_ID INT,
	@MET_ID INT
) AS

INSERT INTO METER_RATES
SELECT @MET_ID, @RATE_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE INSERT_METER_READINGS
(	
	@MET_ID INT,
	@DATE SMALLDATETIME,
	@READ VARCHAR(50),
	@RATE INT,
	@INSP_ID INT
)AS

INSERT INTO METER_READINGS (METER_ID, DATED, OPERATOR, READING,RATE_ID)
	SELECT @MET_ID, @DATE,@INSP_ID, @READ,@RATE








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_NEW_EMAIL_CONTACT
(
	@COMP INT,
	@FNAME VARCHAR(250),
	@LNAME VARCHAR(250),
	@EMAIL VARCHAR(250)
) AS

DECLARE @ID INT
DECLARE @SEFF SMALLDATETIME

SELECT @SEFF = GETDATE()

INSERT INTO CONTACTS (CONTACT_STATUS_ID, STAT_EFF, COMPANY_ID, LASTNAME, FIRSTNAME, EMAIL)
SELECT 
	1,
	@SEFF,
	@COMP,
	@LNAME,
	@FNAME,
	@EMAIL

SELECT @ID = @@IDENTITY

INSERT INTO
	CONTACT_STATUS_HISTORY
SELECT
	@ID,
	1,
	@SEFF,
	NULL

INSERT INTO 
	COMPANY_CONTACT
SELECT
	@COMP,
	@ID,
	0

SELECT @ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_RECEIVED_CORRESPONDENCE
(
	@C_TYPE INT,
	@TARGET INT,
	@RDATE SMALLDATETIME,
	@BULK INT,
	@SENDER VARCHAR(50),
	@DIR INT,
	@PROP_ID INT,
	@COMP_ID INT
) AS

INSERT INTO CORRESPONDENCE
SELECT
	@C_TYPE,
	@RDATE,
	@SENDER,
	@DIR,
	@TARGET,
	@BULK,
	@PROP_ID,
	@COMP_ID

SELECT @@IDENTITY






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_RECEIVED_CORR_DOC
(
	@MERGE_FILE IMAGE,
	@FILESIZE INT,
	@FILENAME VARCHAR(500),
	@DOC_TYPE INT
) AS

INSERT INTO CORRESPONDENCE_DOCUMENTS SELECT @MERGE_FILE, @FILESIZE, @FILENAME,@DOC_TYPE

SELECT @@IDENTITY






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE INSERT_ROUTE
(
	@NAME VARCHAR(50),
	@ACTIVE INT
)
AS

INSERT INTO ROUTES
SELECT
	@NAME,
	@ACTIVE


SELECT @@IDENTITY







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSERT_ROUTE_PROPERTY
(
	@ROUTE_ID INT,
	@PROP_ID INT,
	@ORDER INT
) AS

INSERT INTO OBJECT_ROUTE
	SELECT 
		@ROUTE_ID,
		@PROP_ID,
		@ORDER








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE INSP_REP
(
	@INSP_ID INT
) AS

SET NOCOUNT ON

SELECT
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,'') AS INSPECTOR,
	O.OBJECT_NAME,
	O.OBJECT_ID,
	ISNULL(O.OBJECT_NAME,'') + ' ' + ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE, '') AS PROPERTY,
	CONVERT(VARCHAR(20), OK.DATE_CHECK, 103) AS INSP_DATE,
	ISNULL(C.COMPANY_NAME,'') AS COMPANY_NAME,
	ISNULL(A.HOUSENAME,'')  + ' ' + ISNULL(A.HOUSENUMBER,'') + ' ' + ISNULL(A.STREETNAME,'')  + ' ' + 	ISNULL(A.ADDRESS4,'') + ' '+  ISNULL(A.ADDRESS5,'') + ' ' +  ISNULL(A.CITY,'')  + ' ' + ISNULL(A.POSTALCODE,'') AS CADDRESS
FROM
	COMPANIES C,
	ADDRESSES A,
	COMPANY_ADDRESS CA,
	CONTACTS CO,
	COMPANY_OBJECT CM,
	OBJECT_CONTACT OC,
	OBJECT_CONTACT_TYPE OCT,
	OBJECT_CHECKS OK,
	EMPLOYEES E,
	OBJECTS O
WHERE
	OK.OBJECT_CHECK_ID = @INSP_ID
AND	CM.OBJECT_ID = OK.OBJECT_ID
AND 	OK.OBJECT_ID = O.OBJECT_ID
AND	CM.COMPANY_ID = C.COMPANY_ID
AND	C.COMPANY_ID = CA.COMPANY_ID
AND	CA.ADDRESS_ID = A.ADDRESS_ID
AND	OC.OBJECT_ID = CM.OBJECT_ID
AND	OC.CONTACT_ID = CO.CONTACT_ID
AND	CO.CONTACT_ID = OCT.CONTACT_ID
AND	OCT.CONTACT_TYPE = 10
AND	OK.RECORD_MANAGER = E.EMPLOYEE_ID
AND	OK.DATE_CHECK > CM.DATE_FROM 
AND 	(OK.DATE_CHECK < CM.DATE_TO OR CM.DATE_TO IS NULL)
GROUP BY
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,''),
	ISNULL(O.OBJECT_NAME,'') + ' ' + ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE, ''),
	CONVERT(VARCHAR(20), OK.DATE_CHECK, 103),
	ISNULL(C.COMPANY_NAME,''),
	ISNULL(A.HOUSENAME,'')  + ' ' + ISNULL(A.HOUSENUMBER,'') + ' ' + ISNULL(A.STREETNAME,'')  + ' ' + 	ISNULL(A.ADDRESS4,'') + ' '+  ISNULL(A.ADDRESS5,'') + ' ' +  ISNULL(A.CITY,'')  + ' ' + ISNULL(A.POSTALCODE,''),
	O.OBJECT_NAME,
	O.OBJECT_ID


SELECT
	CO.FIRSTNAME,
	CO.LASTNAME
FROM
	COMPANIES C,
	ADDRESSES A,
	COMPANY_ADDRESS CA,
	CONTACTS CO,
	COMPANY_OBJECT CM,
	OBJECT_CONTACT OC,
	OBJECT_CONTACT_TYPE OCT,
	OBJECT_CHECKS OK,
	EMPLOYEES E,
	OBJECTS O
WHERE
	OK.OBJECT_CHECK_ID = @INSP_ID
AND	CM.OBJECT_ID = OK.OBJECT_ID
AND 	OK.OBJECT_ID = O.OBJECT_ID
AND	CM.COMPANY_ID = C.COMPANY_ID
AND	C.COMPANY_ID = CA.COMPANY_ID
AND	CA.ADDRESS_ID = A.ADDRESS_ID
AND	OC.OBJECT_ID = CM.OBJECT_ID
AND	OC.CONTACT_ID = CO.CONTACT_ID
AND	CO.CONTACT_ID = OCT.CONTACT_ID
AND	OCT.CONTACT_TYPE = 10
AND	OK.RECORD_MANAGER = E.EMPLOYEE_ID
AND	OK.DATE_CHECK > CM.DATE_FROM 
AND 	(OK.DATE_CHECK < CM.DATE_TO OR CM.DATE_TO IS NULL)
GROUP BY
	CO.FIRSTNAME,
	CO.LASTNAME




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE INSP_REP_EMAIL
(
	@INSP_ID INT
) AS


SELECT
	ISNULL(CO.FIRSTNAME,'') AS FIRSTNAME,
	ISNULL(CO.LASTNAME,'') AS LASTNAME,
	ISNULL(CO.EMAIL,'') AS EMAIL
FROM
	COMPANIES C,
	CONTACTS CO,
	COMPANY_OBJECT CM,
	OBJECT_CONTACT OC,
	OBJECT_CONTACT_TYPE OCT,
	OBJECT_CHECKS OK,
	OBJECTS O
WHERE
	OK.OBJECT_CHECK_ID = @INSP_ID
AND	CM.OBJECT_ID = OK.OBJECT_ID
AND 	OK.OBJECT_ID = O.OBJECT_ID
AND	CM.COMPANY_ID = C.COMPANY_ID
AND	OC.OBJECT_ID = CM.OBJECT_ID
AND	OC.CONTACT_ID = CO.CONTACT_ID
AND	CO.CONTACT_ID = OCT.CONTACT_ID
AND	OCT.CONTACT_TYPE = 10







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE INSP_REP_NL
(
	@INSP_ID INT
) AS

SET NOCOUNT ON

SELECT
	O.OBJECT_NAME,
	O.OBJECT_ID,
	O.CITY,
	O.POSTALCODE,
	CONVERT(VARCHAR(20), OK.DATE_CHECK, 103) AS INSP_DATE,
	ISNULL(C.COMPANY_NAME,'') AS COMPANY_NAME,
	ISNULL(A.HOUSENAME,'')  AS ADDR1,
	ISNULL(A.POSTALCODE,'') + ' ' + ISNULL(A.CITY,'') AS ADDR2,
	CO.FIRSTNAME,
	CO.PREFIX,
	CO.LASTNAME,
	CO.SALUTATION,
	CO.TITLE,
	CO.INITIALS,
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME, ' ') AS INSP
FROM
	COMPANIES C,
	ADDRESSES A,
	COMPANY_ADDRESS CA,
	CONTACTS CO,
	COMPANY_OBJECT CM,
	OBJECT_CONTACT OC,
	OBJECT_CONTACT_TYPE OCT,
	OBJECT_CHECKS OK,
	EMPLOYEES E,
	OBJECTS O
WHERE
	OK.OBJECT_CHECK_ID = @INSP_ID
AND	CM.OBJECT_ID = OK.OBJECT_ID
AND 	OK.OBJECT_ID = O.OBJECT_ID
AND	CM.COMPANY_ID = C.COMPANY_ID
AND	C.COMPANY_ID = CA.COMPANY_ID
AND	CA.ADDRESS_ID = A.ADDRESS_ID
AND	OC.OBJECT_ID = CM.OBJECT_ID
AND	OC.CONTACT_ID = CO.CONTACT_ID
AND	CO.CONTACT_ID = OCT.CONTACT_ID
AND	OCT.CONTACT_TYPE = 10
AND	OK.RECORD_MANAGER = E.EMPLOYEE_ID
AND	OK.DATE_CHECK > CM.DATE_FROM 
AND 	(OK.DATE_CHECK < CM.DATE_TO OR CM.DATE_TO IS NULL)
AND	CA.ADDRESS_TYPE = 1
GROUP BY
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME, ' ') ,
	CONVERT(VARCHAR(20), OK.DATE_CHECK, 103),
	ISNULL(C.COMPANY_NAME,''),
	ISNULL(A.HOUSENAME,'')  + ' ' + ISNULL(A.HOUSENUMBER,'') + ' ' + ISNULL(A.STREETNAME,'')  + ' ' + 	ISNULL(A.ADDRESS4,'') + ' '+  ISNULL(A.ADDRESS5,'') + ' ' +  ISNULL(A.CITY,'')  + ' ' + ISNULL(A.POSTALCODE,''),
	O.OBJECT_NAME,
	O.OBJECT_ID,
	CO.FIRSTNAME,
	CO.LASTNAME,
	CO.PREFIX,
	CO.INITIALS,
	O.CITY,
	A.POSTALCODE,
	A.HOUSENAME,
	A.CITY,
	CO.SALUTATION,
	CO.TITLE,
	O.POSTALCODE

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE REM_OBJCONT
(
	@CONT_ID INT,
	@PROP_ID INT
) AS

DELETE FROM OBJECT_CONTACT_TYPE WHERE CONTACT_ID = @CONT_ID AND OBJECT_ID = @PROP_ID

DELETE FROM OBJECT_CONTACT WHERE CONTACT_ID = @CONT_ID AND OBJECT_ID = @PROP_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_ALL_OPEN_INCIDENTS
(
	@ACC VARCHAR(4),
	@PROP VARCHAR(4)
)AS

DECLARE @ACC_STRING VARCHAR(4000)
DECLARE @PROP_STRING VARCHAR(4000)
DECLARE @SQL VARCHAR(4000)

IF @ACC = 0
BEGIN
	SELECT @ACC_STRING = ''
END
ELSE
BEGIN
	SELECT @ACC_STRING = 'AND O.ACCOUNT_MANAGER = ' + @ACC
END

IF @PROP = 0
BEGIN
	SELECT @PROP_STRING = ''
END
ELSE
BEGIN
	SELECT @PROP_STRING = 'AND O.OBJECT_ID = ' + @PROP
END


SELECT @SQL='SELECT 
		C.COMPLAINT_ID AS INC_ID,
		O.PROPERTY_ID,
		O.OBJECT_NAME,
		C.COMPLAINT_DATE AS IND_DATE,
		U.DESCRIPTION AS URGENCY,	
		C.DESCRIPTION AS CDESC,
		C.SOLUTION AS SOLUTION,
		C.RESOLUTION_DATE AS RESDATE
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		OBJECTS O
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	OC.OBJECT_ID = O.OBJECT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID ' + @ACC_STRING + ' ' + @PROP_STRING + '
	GROUP BY
		C.COMPLAINT_ID,
		O.PROPERTY_ID,
		O.OBJECT_NAME,
		C.COMPLAINT_DATE ,
		U.DESCRIPTION ,	
		C.DESCRIPTION ,
		C.SOLUTION,
		C.RESOLUTION_DATE
	ORDER BY OBJECT_NAME, CONVERT(SMALLDATETIME,C.COMPLAINT_DATE,113) DESC'

EXEC(@SQL)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_ALL_OPEN_INCIDENTS_DETAILS
(
	@ACC VARCHAR(4),
	@PROP VARCHAR(4)
)AS

DECLARE @ACC_STRING VARCHAR(4000)
DECLARE @PROP_STRING VARCHAR(4000)
DECLARE @SQL VARCHAR(4000)

IF @ACC = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACC
END


IF @PROP = 0
BEGIN
	SELECT 'All Properties' as PROPERTY
END
ELSE
BEGIN
	SELECT
		OBJECT_NAME
	FROM
		OBJECTS
	WHERE
		OBJECT_ID = @PROP
END

IF @ACC = 0
BEGIN
	SELECT @ACC_STRING = ''
END
ELSE
BEGIN
	SELECT @ACC_STRING = 'AND O.ACCOUNT_MANAGER = ' + @ACC
END

IF @PROP = 0
BEGIN
	SELECT @PROP_STRING = ''
END
ELSE
BEGIN
	SELECT @PROP_STRING = 'AND O.OBJECT_ID = ' + @PROP
END


SELECT @SQL='SELECT 
			COUNT(*)
	FROM
		COMPLAINTS C,
		OBJECT_COMPLAINTS OC,
		COMPLAINT_URGENCY U,
		COMPLAINT_HISTORY CH,
		COMPLAINT_STATUS CS,
		COMPLAINT_TYPES CT,
		OBJECTS O
	WHERE
		C.COMPLAINT_ID = OC.COMPLAINT_ID
	AND	OC.OBJECT_ID = O.OBJECT_ID
	AND	U.URGENCY_ID = C.URGENCY
	AND	CH.COMPLAINT_ID = C.COMPLAINT_ID
	AND	CH.DATE_ENTERED = (SELECT MAX(DATE_ENTERED) FROM COMPLAINT_HISTORY WHERE COMPLAINT_ID = C.COMPLAINT_ID)
	AND	CH.STATUS_CODE = CS.STATUS_ID
	AND	CS.RESOLVED = 0
	AND	C.COMPLAINT_TYPE = CT.COMPLAINT_TYPE_ID ' + @ACC_STRING + ' ' + @PROP_STRING

EXEC(@SQL)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_ALL_VETTING
(
	@ACC INT
) AS



IF @ACC = 0
BEGIN
	SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END
ELSE
	BEGIN
		SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	O.ACCOUNT_MANAGER = @ACC
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_ALL_VETTING_DETAILS
(
	@ACC INT
) AS

IF @ACC = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACC
END

IF @ACC = 0
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
END
ELSE
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	O.ACCOUNT_MANAGER = @ACC
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_CALAMITY AS


DECLARE @PROP_ID INT
DECLARE @OBJECT_NAME VARCHAR(500)
DECLARE @PROPERTY_ID INT
DECLARE @PADDRESS VARCHAR(4000)
DECLARE @CALAMITY NUMERIC(18,2)
DECLARE @INSPECTOR VARCHAR(500)
DECLARE @COMPANY_ID INT
DECLARE @COMPANY_NAME VARCHAR(200)
DECLARE @CADDRESS VARCHAR(4000)

CREATE TABLE #CALAMITY
	(A  VARCHAR(1000),
	B  VARCHAR(1000),
	C  VARCHAR(1000),
	D  VARCHAR(1000),
	E  VARCHAR(1000),
	F  VARCHAR(1000))

DECLARE PROPS CURSOR FOR
	SELECT
		O.OBJECT_ID,
		O.OBJECT_NAME,
		O.PROPERTY_ID,
		LTRIM(ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(HOUSENUMBER,'') + ' ' + ISNULL(STREETNAME,'') + ' ' + ISNULL(ADDRESS4,'') + ' ' + ISNULL(CITY,'') + ' ' + ISNULL(POSTALCODE,'')) AS ADDRESS,
		O.CALAM_LIMIT,
		E.FIRSTNAME + ' ' +  E.LASTNAME AS INSPECTOR
	FROM
		OBJECTS O,
		OBJECT_STATUS OS,
		EMPLOYEES E
	WHERE
		O.STATUS_ID = OS.STATUS_ID
	AND	OS.MANAGED = 1
	AND	O.PROPERTY_INSPECTOR = E.EMPLOYEE_ID
	ORDER BY
		OBJECT_NAME

OPEN PROPS

FETCH NEXT FROM PROPS INTO @PROP_ID, @OBJECT_NAME, @PROPERTY_ID, @PADDRESS, @CALAMITY, @INSPECTOR

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #CALAMITY
		SELECT 1,'Property','Property Number', 'Address','Calamity Limit','Inspector'

	INSERT INTO #CALAMITY
		SELECT 1, @OBJECT_NAME, @PROPERTY_ID, @PADDRESS, @CALAMITY, @INSPECTOR

	DECLARE COMPS CURSOR FOR
		SELECT TOP 1
			C.COMPANY_ID,
			C.COMPANY_NAME,
			LTRIM(ISNULL(A.HOUSENAME,'') + ' ' + ISNULL(HOUSENUMBER,'') + ' ' + ISNULL(STREETNAME,'') + ' ' + ISNULL(ADDRESS4,'') + ' ' + ISNULL(POSTALCODE,'') + ' ' + ISNULL(CITY,'')) AS ADDRESS
		FROM
			COMPANIES C,
			COMPANY_ADDRESS CA,
			ADDRESSES A,
			COMPANY_OBJECT CO
		WHERE
			C.COMPANY_ID = CA.COMPANY_ID
		AND	CA.ADDRESS_ID = A.ADDRESS_ID
		AND	C.COMPANY_ID = CO.COMPANY_ID
		AND	CO.DATE_FROM < GETDATE() AND (CO.DATE_TO IS NULL OR CO.DATE_TO > GETDATE())
		AND	CO.OBJECT_ID = @PROP_ID
		ORDER BY
			A.ADDRESS_ID DESC
	
	OPEN COMPS

	FETCH NEXT FROM COMPS INTO @COMPANY_ID, @COMPANY_NAME, @CADDRESS

	WHILE @@FETCH_STATUS = 0
	BEGIN

		INSERT INTO #CALAMITY
		SELECT  0,NULL, NULL, NULL, NULL,  NULL

		INSERT INTO #CALAMITY
		SELECT  0,@COMPANY_NAME, @CADDRESS, NULL, NULL,  NULL

		INSERT INTO #CALAMITY
		SELECT  2,'Contact Name', 'Contact Type', 'Phone', 'Mobile', NULL

		INSERT INTO #CALAMITY
		SELECT
			0,
			ISNULL(C.FIRSTNAME,'') + ' ' + ISNULL(C.LASTNAME,'') AS CONTACT_NAME,
			CT.DESCRIPTION, 
			C.DIRECT_PHONE,
			C.MOBILE_PHONE,
			NULL
		FROM
			CONTACTS C,
			CONTACT_TYPES CT,
			OBJECT_CONTACT OC,
			OBJECT_CONTACT_TYPE OCT
		WHERE
			OC.OBJECT_ID =@PROP_ID
		AND	OC.CONTACT_ID = C.CONTACT_ID
		AND	OC.CONTACT_ID = OCT.CONTACT_ID
		AND	OC.OBJECT_ID = OCT.OBJECT_ID
		AND	OCT.CONTACT_TYPE = CT.CONTACT_TYPE
		AND	OCT.CONTACT_TYPE IN (3,11)
		AND	(OC.DATE_START < GETDATE() OR OC.DATE_START IS NULL) AND (OC.DATE_END IS NULL OR OC.DATE_END > GETDATE())

		FETCH NEXT FROM COMPS INTO @COMPANY_ID, @COMPANY_NAME, @CADDRESS
	END
	
	CLOSE COMPS
	DEALLOCATE COMPS

	INSERT INTO #CALAMITY
	SELECT  0,NULL, NULL, NULL, NULL,  NULL

	INSERT INTO #CALAMITY
	SELECT  2,'Type', 'Location', 'Code', 'Contact',  'Contact No'

	INSERT INTO #CALAMITY
	SELECT
		0,
		ST.DESCRIPTION,
		S.LOCATION,
		S.CODE,
		S.EM_CONT,
		S.CONT_NO
	FROM
		SECURITIES S,
		SECURITY_TYPES ST,
		OBJECT_SECURITIES OS
	WHERE
		OS.OBJECT_ID = @PROP_ID
	AND	OS.SECURITY_ID = S.SECURITY_ID
	AND	S.SECURITY_TYPE = ST.SECURITY_TYPE

	INSERT INTO #CALAMITY
	SELECT  0,NULL, NULL, NULL, NULL,  NULL

	INSERT INTO #CALAMITY
	SELECT  2,'Guardian', 'Room', 'Phone', 'Mobile',  'Wk Phone'


	INSERT INTO #CALAMITY
	SELECT
		0,
		ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.LASTNAME,'') AS RESIDENT,
		RO.ROOM,
		R.PHONE,
		R.PRIVATE_MOBILE,
		R.PRIVATE_PHONE
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO
	WHERE
		RO.OBJECT_ID = @PROP_ID
	AND	RO.RESIDENT_ID = R.RESIDENT_ID
	AND	RO.DATE_FROM < GETDATE() AND (RO.DATE_TO = 01/01/1900 OR RO.DATE_TO > GETDATE())
	ORDER BY
		R.LASTNAME


	FETCH NEXT FROM PROPS INTO @PROP_ID, @OBJECT_NAME, @PROPERTY_ID, @PADDRESS, @CALAMITY, @INSPECTOR
END

CLOSE PROPS
DEALLOCATE PROPS	

SELECT * FROM #CALAMITY






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_COLS
(
	@REP INT
) AS

SELECT * FROM FMT_COL WHERE RPT_ID = @REP








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE RPT_EMPTY_SPACES
(
	@ACCMAN INT
) AS


CREATE TABLE #SPACES
(
	A VARCHAR(250),
	B VARCHAR(250),
	C VARCHAR(250),
	D VARCHAR(250),
	E VARCHAR(250),
	F VARCHAR(250),
	G VARCHAR(250)
)
IF @ACCMAN = 0
BEGIN
	INSERT INTO #SPACES
	SELECT
	0,
	O.OBJECT_NAME,
	O.PROPERTY_ID,
	O.MAX_NR_RESIDENTS,
	(SELECT count(*)
		from 
			RESIDENTS R,
			RESIDENT_OBJECT RO
		where 
			RO.object_id = O.OBJECT_ID
		and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
		AND 	RO.RESIDENT_ID = R.RESIDENT_ID) AS ACTUAL_OCCUP,
	O.MAX_NR_RESIDENTS - (SELECT count(*)
					from 
						RESIDENTS R,
						RESIDENT_OBJECT RO
					where 
						RO.object_id = O.OBJECT_ID
						and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
						AND 	RO.RESIDENT_ID = R.RESIDENT_ID) AS SHORTFALL,
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,'') AS ACCMAN
	FROM
		OBJECTS O,
		OBJECT_STATUS OS,
		EMPLOYEES E
	WHERE
		OS.STATUS_ID = O.STATUS_ID
	AND	(OS.MANAGED = 1 OR OS.STATUS_ID  = 3)
	AND	(SELECT count(*)
		from 
			RESIDENTS R,
			RESIDENT_OBJECT RO
		where 
			RO.object_id = O.OBJECT_ID
		and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
		AND 	RO.RESIDENT_ID = R.RESIDENT_ID) < MAX_NR_RESIDENTS
		AND	O.ACCOUNT_MANAGER *= E.EMPLOYEE_ID
	ORDER BY 
		OBJECT_NAME	
END
ELSE
BEGIN	
	INSERT INTO #SPACES
	SELECT
	0,
	O.OBJECT_NAME,
	O.PROPERTY_ID,
	O.MAX_NR_RESIDENTS,
	(SELECT count(*)
		from 
			RESIDENTS R,
			RESIDENT_OBJECT RO
		where 
			RO.object_id = O.OBJECT_ID
		and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
		AND 	RO.RESIDENT_ID = R.RESIDENT_ID) AS ACTUAL_OCCUP,
	O.MAX_NR_RESIDENTS - (SELECT count(*)
					from 
						RESIDENTS R,
						RESIDENT_OBJECT RO
					where 
						RO.object_id = O.OBJECT_ID
						and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
						AND 	RO.RESIDENT_ID = R.RESIDENT_ID) AS SHORTFALL,
	ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,'') AS ACCMAN
	FROM
		OBJECTS O,
		OBJECT_STATUS OS,
		EMPLOYEES E
	WHERE
		OS.STATUS_ID = O.STATUS_ID
	AND	(OS.MANAGED = 1 OR OS.STATUS_ID  = 3)
	AND	(SELECT count(*)
		from 
			RESIDENTS R,
			RESIDENT_OBJECT RO
		where 
			RO.object_id = O.OBJECT_ID
		and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
		AND 	RO.RESIDENT_ID = R.RESIDENT_ID) < MAX_NR_RESIDENTS
		AND	O.ACCOUNT_MANAGER *= E.EMPLOYEE_ID
		AND	O.ACCOUNT_MANAGER = @ACCMAN
		ORDER BY 
			OBJECT_NAME	
END

INSERT INTO 
	#SPACES
SELECT
	1,
	'No Propperties : ' + CONVERT(VARCHAR(20),count(*)),
	NULL,
	SUM(CONVERT(INT,D)),
	SUM(CONVERT(INT,E)),
	SUM(CONVERT(INT,F)),
	NULL
FROM
	#SPACES
	
SELECT * FROM #SPACES






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_EMPTY_SPACES_DETAILS
(
	@ACCMAN INT
) AS

IF @ACCMAN = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACCMAN
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_FACILITIES
(
	@REP INT,
	@FROM VARCHAR(250),
	@TO VARCHAR(250)
)AS

DECLARE @ReportName varchar(100)
DECLARE @Hash char (1)
DECLARE @HdrCellRefCol varchar (2)
DECLARE @HdrCellRefRow varchar (2)
DECLARE @HdrText varchar (255)
DECLARE @HdrWeight tinyint
DECLARE @HdrBorder tinyint
DECLARE @CurrentRow varchar (2)
DECLARE @CNT INT
DECLARE @PROP INT
DECLARE @PROP_NAME VARCHAR(250)
DECLARE @DFROM SMALLDATETIME
DECLARE @DTO SMALLDATETIME

SELECT @DFROM = CONVERT(SMALLDATETIME, @FROM,103)
SELECT @DTO = CONVERT(SMALLDATETIME, @TO,103)

declare @recordcount int
DECLARE @SQL VARCHAR(255)
SET NOCOUNT ON
SELECT @Hash = '#'
SELECT @ReportName = 'Property Facilities'


CREATE TABLE #RESULT (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500),
	E VARCHAR(500)
)

CREATE TABLE #RESULT2 (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500),
	E VARCHAR(500)
)

DECLARE PROPS CURSOR FOR
SELECT
	O.OBJECT_ID,
	O.OBJECT_NAME
FROM 
	OBJECTS O,
	OBJECT_FACILITIES OBF,
	FACILITIES F
WHERE
	O.OBJECT_ID = OBF.OBJECT_ID
AND	OBF.FACILITY_ID = F.FACILITY_ID
AND	(((F.DATE_INSTALLED < @DFROM OR F.DATE_INSTALLED = 01/01/1900) AND	(F.DATE_REMOVED > @DTO OR F.DATE_REMOVED = 01/01/1900))
	OR	(F.DATE_INSTALLED BETWEEN @DFROM AND @DTO)
	OR	(F.DATE_REMOVED BETWEEN @DFROM AND @DTO))
GROUP BY 
	O.OBJECT_ID, O.OBJECT_NAME
ORDER BY
	O.OBJECT_NAME


OPEN PROPS

FETCH NEXT FROM PROPS INTO @PROP, @PROP_NAME

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #RESULT
	SELECT
		0,1,0,@PROP_NAME,@HASH,@HASH,@HASH, @HASH

	INSERT INTO #RESULT
	SELECT
		0,0,0,@HASH,
		FT.DESCRIPTION,
		F.DESCRIPTION,
		F.LOCATION,
		CASE F.DATE_INSTALLED
			WHEN 01/01/1900 THEN NULL
			ELSE CONVERT(VARCHAR(20),F.DATE_INSTALLED,103)
		END
	FROM 
		OBJECTS O,
		OBJECT_FACILITIES OBF,
		FACILITIES F,
		FACILITY_TYPES FT
	WHERE
		O.OBJECT_ID = @PROP
	AND	O.OBJECT_ID = OBF.OBJECT_ID
	AND	OBF.FACILITY_ID = F.FACILITY_ID
	AND	F.FACILITY_TYPE = FT.FACILITY_TYPE
	AND	(((F.DATE_INSTALLED < @DFROM OR F.DATE_INSTALLED = 01/01/1900) AND	(F.DATE_REMOVED > @DTO OR F.DATE_REMOVED = 01/01/1900))
		OR	(F.DATE_INSTALLED BETWEEN @DFROM AND @DTO)
		OR	(F.DATE_REMOVED BETWEEN @DFROM AND @DTO))


	FETCH NEXT FROM PROPS INTO @PROP, @PROP_NAME
END

CLOSE PROPS
DEALLOCATE PROPS

SELECT @CNT = COUNT(*) FROM #RESULT


IF @CNT > 0
BEGIN
		
	INSERT INTO #RESULT2
	      VALUES ( 
	    	0, 
	   	0,
	    	0,
		@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash)
	
	
	DECLARE Fmt_Hdr CURSOR FOR
	   SELECT  HDR_CELL_REF_COL,
	    HDR_CELL_REF_ROW,
	    isnull(HDR_TEXT,datepart(year,getdate())),
	    HDR_WEIGHT,
	    HDR_BORDER
	   FROM     Fmt_Hdr
	   WHERE    RPT_ID = @Rep
	   ORDER BY   HDR_CELL_REF_ROW,
	       HDR_CELL_REF_COL
	  OPEN   Fmt_Hdr
	-- FETCH THE FIRST ROW
	  FETCH NEXT FROM Fmt_Hdr INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  SELECT @CurrentRow = ''
	-- LOOP THROUGH RESULTS SET AND WRITE THE HEADER LINES
	  WHILE (@@FETCH_STATUS = 0)
	  BEGIN
	   SELECT @HdrBorder = 0
	   IF @HdrCellRefRow <> @CurrentRow
	   BEGIN
	     SELECT @CurrentRow = @HdrCellRefRow
	-- INSERT END DATE
	    IF @HdrText = 'ReportNAME'
	        BEGIN
	           INSERT INTO #RESULT2
	           VALUES   (
	         0, 
	         @HdrWeight,
	         @HdrBorder,  
	         @REPORTNAME,
	         @hash,
	     @Hash,
	     @Hash,
	     @Hash)
	
	INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	 
	        END
	-- INSERT SELECTION CRITERIA
	     ELSE IF @HdrText = 'Between'
	     BEGIN
	      INSERT INTO #RESULT2
	      VALUES (  
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @HdrText + ': ' + RTRIM(convert(VARCHAR(50),@FROM,103)) + ' and ' + RTRIM(convert(VARCHAR(50),@TO,103)),
	         @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	   
	   INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)  
	 
	     END
	    
	-- INSERT ALL OTHER TITLES
	     ELSE
	     BEGIN
	       INSERT INTO #RESULT2
	       VALUES (
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	  
	   SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	   EXEC(@SQL)
	     END 
	   END 
	 ELSE
	 BEGIN
	  SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	  EXEC(@SQL)
	 -- EXEC ("UPDATE #RESULT SET " + @HdrCellRefCol + " = '"+ @Hdrtext + "' WHERE INCREMENT = " + @CurrentRow)
	 END
	  
	    
	-- FETCH THE NXT ROW IN THE RESULTS SET     --
	   
	    FETCH NEXT FROM fmt_hdr 
	    INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  END
	-- KILL HEADERS CURSOR       --
	  DEALLOCATE fmt_hdr
	
	INSERT INTO #RESULT2
	SELECT
		INDENT,
		WEIGHT,
		BORDER,
		A,
		B,
		C,
		D,
		ISNULL(E, @HASH)
	FROM
		#RESULT
	
END


SELECT * FROM #RESULT2








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_GUARDIANS
(
	@REP INT,
	@FROM VARCHAR(250),
	@TO VARCHAR(250)
)AS

DECLARE @ReportName varchar(100)
DECLARE @Hash char (1)
DECLARE @HdrCellRefCol varchar (2)
DECLARE @HdrCellRefRow varchar (2)
DECLARE @HdrText varchar (255)
DECLARE @HdrWeight tinyint
DECLARE @HdrBorder tinyint
DECLARE @CurrentRow varchar (2)
DECLARE @CNT INT
DECLARE @PROP INT
DECLARE @PROP_NAME VARCHAR(250)
DECLARE @DFROM SMALLDATETIME
DECLARE @DTO SMALLDATETIME

SELECT @DFROM = CONVERT(SMALLDATETIME, @FROM,103)
SELECT @DTO = CONVERT(SMALLDATETIME, @TO,103)

declare @recordcount int
DECLARE @SQL VARCHAR(255)
SET NOCOUNT ON
SELECT @Hash = '#'
SELECT @ReportName = 'Guardians'


CREATE TABLE #RESULT (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500),
	E VARCHAR(500),
	F VARCHAR(500),
	G VARCHAR(500)
)

CREATE TABLE #RESULT2 (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500),
	E VARCHAR(500),
	F VARCHAR(500),
	G VARCHAR(500)
)

DECLARE PROPS CURSOR FOR
SELECT
	O.OBJECT_ID,
	O.OBJECT_NAME
FROM 
	OBJECTS O,
	RESIDENT_OBJECT OG
WHERE
	O.OBJECT_ID = OG.OBJECT_ID
AND	(((OG.DATE_FROM < @DFROM OR OG.DATE_FROM = 01/01/1900) AND (OG.DATE_TO > @DTO OR OG.DATE_TO = 01/01/1900))
		OR	(OG.DATE_FROM BETWEEN @DFROM AND @DTO)
		OR	(OG.DATE_TO BETWEEN @DFROM AND @DTO))
GROUP BY 
	O.OBJECT_ID, O.OBJECT_NAME
ORDER BY
	O.OBJECT_NAME


OPEN PROPS

FETCH NEXT FROM PROPS INTO @PROP, @PROP_NAME

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #RESULT
	SELECT
		0,1,0,@PROP_NAME,@HASH,@HASH,@HASH, @HASH,@HASH, @HASH

	INSERT INTO #RESULT (INDENT, WEIGHT, BORDER,A,B,C,D,E,F,G)
	SELECT
		0,0,0,@HASH,
		G.FIRSTNAME + ' ' + G.LASTNAME,
		ISNULL(G.PHONE,@HASH),
		ISNULL(G.MOBILE,@HASH),
		ISNULL(G.EMAIL,@HASH),
		CONVERT(VARCHAR(20),OG.DATE_FROM,103),
		@HASH		
	FROM 
		OBJECTS O,
		RESIDENTS G,
		RESIDENT_OBJECT OG		
	WHERE
		O.OBJECT_ID = @PROP
	AND	O.OBJECT_ID = OG.OBJECT_ID
	AND	G.RESIDENT_ID = OG.RESIDENT_ID
	AND	(((OG.DATE_FROM < @DFROM OR OG.DATE_FROM = 01/01/1900) AND (OG.DATE_TO > @DTO OR OG.DATE_TO = 01/01/1900))
		OR	(OG.DATE_FROM BETWEEN @DFROM AND @DTO)
		OR	(OG.DATE_TO BETWEEN @DFROM AND @DTO))
	AND	OG.DATE_TO = 01/01/1900
	ORDER BY
		G.LASTNAME, G.FIRSTNAME

	INSERT INTO #RESULT (INDENT, WEIGHT, BORDER,A,B,C,D,E,F,G)
	SELECT
		0,0,0,@HASH,
		G.FIRSTNAME + ' ' + G.LASTNAME,
		ISNULL(G.PHONE,@HASH),
		ISNULL(G.MOBILE,@HASH),
		ISNULL(G.EMAIL,@HASH),
		CONVERT(VARCHAR(20),OG.DATE_FROM,103),
		CONVERT(VARCHAR(20),OG.DATE_TO,103)	
	FROM 
		OBJECTS O,
		RESIDENTS G,
		RESIDENT_OBJECT OG		
	WHERE
		O.OBJECT_ID = @PROP
	AND	O.OBJECT_ID = OG.OBJECT_ID
	AND	G.RESIDENT_ID = OG.RESIDENT_ID
	AND	(((OG.DATE_FROM < @DFROM OR OG.DATE_FROM = 01/01/1900) AND (OG.DATE_TO > @DTO OR OG.DATE_TO = 01/01/1900))
		OR	(OG.DATE_FROM BETWEEN @DFROM AND @DTO)
		OR	(OG.DATE_TO BETWEEN @DFROM AND @DTO))
	AND	OG.DATE_TO <> 01/01/1900
	ORDER BY
		G.LASTNAME, G.FIRSTNAME

	FETCH NEXT FROM PROPS INTO @PROP, @PROP_NAME
END

CLOSE PROPS
DEALLOCATE PROPS

SELECT @CNT = COUNT(*) FROM #RESULT


IF @CNT > 0
BEGIN
		
	INSERT INTO #RESULT2
	      VALUES ( 
	    	0, 
	   	0,
	    	0,
		@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash)
	
	
	DECLARE Fmt_Hdr CURSOR FOR
	   SELECT  HDR_CELL_REF_COL,
	    HDR_CELL_REF_ROW,
	    isnull(HDR_TEXT,datepart(year,getdate())),
	    HDR_WEIGHT,
	    HDR_BORDER
	   FROM     Fmt_Hdr
	   WHERE    RPT_ID = @Rep
	   ORDER BY   HDR_CELL_REF_ROW,
	       HDR_CELL_REF_COL
	  OPEN   Fmt_Hdr
	-- FETCH THE FIRST ROW
	  FETCH NEXT FROM Fmt_Hdr INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  SELECT @CurrentRow = ''
	-- LOOP THROUGH RESULTS SET AND WRITE THE HEADER LINES
	  WHILE (@@FETCH_STATUS = 0)
	  BEGIN
	   SELECT @HdrBorder = 0
	   IF @HdrCellRefRow <> @CurrentRow
	   BEGIN
	     SELECT @CurrentRow = @HdrCellRefRow
	-- INSERT END DATE
	    IF @HdrText = 'ReportNAME'
	        BEGIN
	           INSERT INTO #RESULT2
	           VALUES   (
	         0, 
	         @HdrWeight,
	         @HdrBorder,  
	         @REPORTNAME,
	         @hash,
	     @Hash,
	     @Hash,
	     @Hash,
	    	@Hash,
	    	@Hash)
	
	INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	    	@Hash,
	    	@Hash)
	 
	        END
	-- INSERT SELECTION CRITERIA
	     ELSE IF @HdrText = 'Between'
	     BEGIN
	      INSERT INTO #RESULT2
	      VALUES (  
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @HdrText + ': ' + RTRIM(convert(VARCHAR(50),@FROM,103)) + ' and ' + RTRIM(convert(VARCHAR(50),@TO,103)),
	         @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	    	@Hash,
	    	@Hash)
	   
	   INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	    	@Hash,
	    	@Hash)  
	 
	     END
	    
	-- INSERT ALL OTHER TITLES
	     ELSE
	     BEGIN
	       INSERT INTO #RESULT2
	       VALUES (
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash,
	    	@Hash,
	    	@Hash)
	  
	   SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	   EXEC(@SQL)
	     END 
	   END 
	 ELSE
	 BEGIN
	  SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	  EXEC(@SQL)
	 -- EXEC ("UPDATE #RESULT SET " + @HdrCellRefCol + " = '"+ @Hdrtext + "' WHERE INCREMENT = " + @CurrentRow)
	 END
	  
	    
	-- FETCH THE NXT ROW IN THE RESULTS SET     --
	   
	    FETCH NEXT FROM fmt_hdr 
	    INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  END
	-- KILL HEADERS CURSOR       --
	  DEALLOCATE fmt_hdr
	
	INSERT INTO #RESULT2
	SELECT
		INDENT,
		WEIGHT,
		BORDER,
		A,
		B,
		C,
		D,
		E,
		F,
		G
	FROM
		#RESULT
	
END


SELECT * FROM #RESULT2








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_HDRS
(
	@REP INT
) AS
SELECT
 RTRIM(HDR_CELL_REF_COL) + RTRIM(CONVERT(CHAR(2),HDR_CELL_REF_ROW)) AS CELL,
   HDR_TEXT AS TEXT, 
   HDR_BORDER AS BORDER, 
   HDR_FONT AS FONT, 
   HDR_WEIGHT AS WEIGHT, 
   HDR_VER AS VerticalJustification, 
   HDR_HOR AS HorizontalJustification,
   HDR_WRAP AS WRAP, 
   RTRIM(HDR_MERGE_COL) + RTRIM(CONVERT(CHAR(2),HDR_MERGE_ROW)) AS MERGE
FROM  
 FMT_HDR 
WHERE  
 RPT_ID = @rep
ORDER BY 
 HDR_CELL_REF_ROW, 
 HDR_CELL_REF_COL








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_NO_VETTING
(
	@ACC INT
) AS


IF @ACC = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACC
END

IF @ACC = 0
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
END
ELSE
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND	O.ACCOUNT_MANAGER = @ACC
END



IF @ACC = 0
BEGIN
	SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 AND R.APPLIC_FORM=0 AND R.BANK_UTIL=0 AND R.REF=0 AND R.STAND=0)
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END
ELSE
BEGIN
	SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 AND R.APPLIC_FORM=0 AND R.BANK_UTIL=0 AND R.REF=0 AND R.STAND=0)
	AND	O.ACCOUNT_MANAGER = @ACC
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_NO_VETTING_DETAILS
(
	@ACC INT
) AS

IF @ACC = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACC
END

IF @ACC = 0
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
END
ELSE
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND	O.ACCOUNT_MANAGER = @ACC
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_OWNERS_PROPERTIES
(
	@REP INT,
	@FROM VARCHAR(250),
	@TO VARCHAR(250)
)AS

DECLARE @ReportName varchar(100)
DECLARE @Hash char (1)
DECLARE @HdrCellRefCol varchar (2)
DECLARE @HdrCellRefRow varchar (2)
DECLARE @HdrText varchar (255)
DECLARE @HdrWeight tinyint
DECLARE @HdrBorder tinyint
DECLARE @CurrentRow varchar (2)
DECLARE @CNT INT
DECLARE @COMP INT
DECLARE @COMP_NAME VARCHAR(250)
DECLARE @DFROM SMALLDATETIME
DECLARE @DTO SMALLDATETIME

SELECT @DFROM = CONVERT(SMALLDATETIME, @FROM,103)
SELECT @DTO = CONVERT(SMALLDATETIME, @TO,103)


declare @recordcount int
DECLARE @SQL VARCHAR(255)
SET NOCOUNT ON
SELECT @Hash = '#'
SELECT @ReportName = 'Owners and Properties'


CREATE TABLE #RESULT (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500)
)

CREATE TABLE #RESULT2 (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500)
)

DECLARE COMPS CURSOR FOR
SELECT
	C.COMPANY_ID,
	C.COMPANY_NAME
FROM 
	COMPANIES C,
	COMPANY_OBJECT OC
WHERE
	C.COMPANY_ID = OC.COMPANY_ID
AND	(((OC.DATE_FROM < @DFROM OR OC.DATE_FROM = 01/01/1900) AND (OC.DATE_TO > @DTO OR OC.DATE_TO = 01/01/1900))
		OR	(OC.DATE_FROM BETWEEN @DFROM AND @DTO)
		OR	(OC.DATE_TO BETWEEN @DFROM AND @DTO))
GROUP BY 
	C.COMPANY_ID, C.COMPANY_NAME
ORDER BY
	C.COMPANY_NAME

OPEN COMPS

FETCH NEXT FROM COMPS INTO @COMP, @COMP_NAME

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #RESULT
	SELECT
		0,1,0,@COMP_NAME,@HASH,@HASH,@HASH

	INSERT INTO #RESULT (INDENT, WEIGHT, BORDER,A,B,C,D)
	SELECT
		0,0,0,@HASH,
		O.OBJECT_NAME,
		S.STATUS_id,
		LTRIM(ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE,''))		
	FROM 
		OBJECTS O,
		COMPANY_OBJECT OC,
		OBJECT_STATUS_HISTORY S
	WHERE
		OC.COMPANY_ID = @COMP
	AND	O.OBJECT_ID = OC.OBJECT_ID
	AND	O.OBJECT_ID = S.OBJECT_ID
	AND	((S.DATE_FROM < @DFROM AND	(S.DATE_TO > @DTO OR S.DATE_TO = 01/01/1900))
	OR	(S.DATE_FROM BETWEEN @DFROM AND @DTO)
	OR	(S.DATE_TO BETWEEN @DFROM AND @DTO))

	ORDER BY
		O.OBJECT_NAME

	FETCH NEXT FROM COMPS INTO @COMP, @COMP_NAME
END

CLOSE COMPS
DEALLOCATE COMPS

SELECT @CNT = COUNT(*) FROM #RESULT


IF @CNT > 0
BEGIN
	
	UPDATE #RESULT SET C = STATUS_DESCRIPTION
	FROM #RESULT R, OBJECT_STATUS O
	WHERE R.C = O.STATUS_ID
	AND C <> '#'

	INSERT INTO #RESULT2
	      VALUES ( 
	    	0, 
	   	0,
	    	0,
		@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash)
	
	
	DECLARE Fmt_Hdr CURSOR FOR
	   SELECT  HDR_CELL_REF_COL,
	    HDR_CELL_REF_ROW,
	    isnull(HDR_TEXT,datepart(year,getdate())),
	    HDR_WEIGHT,
	    HDR_BORDER
	   FROM     Fmt_Hdr
	   WHERE    RPT_ID = @Rep
	   ORDER BY   HDR_CELL_REF_ROW,
	       HDR_CELL_REF_COL
	  OPEN   Fmt_Hdr
	-- FETCH THE FIRST ROW
	  FETCH NEXT FROM Fmt_Hdr INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  SELECT @CurrentRow = ''
	-- LOOP THROUGH RESULTS SET AND WRITE THE HEADER LINES
	  WHILE (@@FETCH_STATUS = 0)
	  BEGIN
	   SELECT @HdrBorder = 0
	   IF @HdrCellRefRow <> @CurrentRow
	   BEGIN
	     SELECT @CurrentRow = @HdrCellRefRow
	-- INSERT END DATE
	    IF @HdrText = 'ReportNAME'
	        BEGIN
	           INSERT INTO #RESULT2
	           VALUES   (
	         0, 
	         @HdrWeight,
	         @HdrBorder,  
	         @REPORTNAME,
	         @hash,
	     @Hash,
	     @Hash)
	
	INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	 
	        END
	-- INSERT SELECTION CRITERIA
	     ELSE IF @HdrText = 'Between'
	     BEGIN
	      INSERT INTO #RESULT2
	      VALUES (  
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @HdrText + ': ' + RTRIM(convert(VARCHAR(50),@FROM,103)) + ' and ' + RTRIM(convert(VARCHAR(50),@TO,103)),
	         @Hash,
	     @Hash,
	     @Hash)
	   
	   INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)  
	 
	     END
	    
	-- INSERT ALL OTHER TITLES
	     ELSE
	     BEGIN
	       INSERT INTO #RESULT2
	       VALUES (
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	  
	   SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	   EXEC(@SQL)
	     END 
	   END 
	 ELSE
	 BEGIN
	  SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	  EXEC(@SQL)
	 -- EXEC ("UPDATE #RESULT SET " + @HdrCellRefCol + " = '"+ @Hdrtext + "' WHERE INCREMENT = " + @CurrentRow)
	 END
	  
	    
	-- FETCH THE NXT ROW IN THE RESULTS SET     --
	   
	    FETCH NEXT FROM fmt_hdr 
	    INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  END
	-- KILL HEADERS CURSOR       --
	  DEALLOCATE fmt_hdr
	
	INSERT INTO #RESULT2
	SELECT
		INDENT,
		WEIGHT,
		BORDER,
		A,
		B,
		C,
		D
	FROM
		#RESULT
	
END


SELECT * FROM #RESULT2








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_PROPERTIES
(
	@REP INT,
	@FROM VARCHAR(250),
	@TO VARCHAR(250)
)AS

DECLARE @ReportName varchar(100)
DECLARE @Hash char (1)
DECLARE @HdrCellRefCol varchar (2)
DECLARE @HdrCellRefRow varchar (2)
DECLARE @HdrText varchar (255)
DECLARE @HdrWeight tinyint
DECLARE @HdrBorder tinyint
DECLARE @CurrentRow varchar (2)
DECLARE @CNT INT
DECLARE @COMP INT
DECLARE @COMP_NAME VARCHAR(250)

DECLARE @DFROM SMALLDATETIME
DECLARE @DTO SMALLDATETIME

SELECT @DFROM = CONVERT(SMALLDATETIME, @FROM,103)
SELECT @DTO = CONVERT(SMALLDATETIME, @TO,103)

declare @recordcount int
DECLARE @SQL VARCHAR(255)
SET NOCOUNT ON
SELECT @Hash = '#'
SELECT @ReportName = 'Properties'


CREATE TABLE #RESULT (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500)
)

CREATE TABLE #RESULT2 (
 INCREMENT int NOT NULL IDENTITY(1,1),
	INDENT INT,
	WEIGHT INT,
	BORDER INT,
	A VARCHAR(500),
	B VARCHAR(500),
	C VARCHAR(500),
	D VARCHAR(500)
)



	INSERT INTO #RESULT (INDENT, WEIGHT, BORDER,A,B,C,D)
	SELECT
		0,0,0,
		O.OBJECT_NAME,
		MAX(S.STATUS_id),
		CONVERT(VARCHAR(20),MAX(S.DATE_FROM),103),
		LTRIM(ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE,''))		
	FROM 
		OBJECTS O,
		COMPANY_OBJECT OC,
		OBJECT_STATUS_HISTORY S
	WHERE
		O.OBJECT_ID = OC.OBJECT_ID
	AND	O.OBJECT_ID = S.OBJECT_ID
	AND	((S.DATE_FROM < @DFROM AND	(S.DATE_TO > @DTO OR S.DATE_TO = 01/01/1900))
	OR	(S.DATE_FROM BETWEEN @DFROM AND @DTO)
	OR	(S.DATE_TO BETWEEN @DFROM AND @DTO))
	GROUP BY
		O.OBJECT_NAME, LTRIM(ISNULL(O.HOUSENAME,'') + ' ' + ISNULL(O.HOUSENUMBER,'') + ' ' + ISNULL(O.STREETNAME,'') + ' ' + ISNULL(O.ADDRESS4,'') + ' ' + ISNULL(O.CITY,'') + ' ' + ISNULL(O.POSTALCODE,''))		
	ORDER BY
		O.OBJECT_NAME

SELECT @CNT = COUNT(*) FROM #RESULT


IF @CNT > 0
BEGIN
	
	UPDATE #RESULT SET B = STATUS_DESCRIPTION
	FROM #RESULT R, OBJECT_STATUS O
	WHERE R.B = O.STATUS_ID
	AND B <> '#'

	INSERT INTO #RESULT2
	      VALUES ( 
	    	0, 
	   	0,
	    	0,
		@Hash,
	    	@Hash,
	    	@Hash,
	    	@Hash)
	
	
	DECLARE Fmt_Hdr CURSOR FOR
	   SELECT  HDR_CELL_REF_COL,
	    HDR_CELL_REF_ROW,
	    isnull(HDR_TEXT,datepart(year,getdate())),
	    HDR_WEIGHT,
	    HDR_BORDER
	   FROM     Fmt_Hdr
	   WHERE    RPT_ID = @Rep
	   ORDER BY   HDR_CELL_REF_ROW,
	       HDR_CELL_REF_COL
	  OPEN   Fmt_Hdr
	-- FETCH THE FIRST ROW
	  FETCH NEXT FROM Fmt_Hdr INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  SELECT @CurrentRow = ''
	-- LOOP THROUGH RESULTS SET AND WRITE THE HEADER LINES
	  WHILE (@@FETCH_STATUS = 0)
	  BEGIN
	   SELECT @HdrBorder = 0
	   IF @HdrCellRefRow <> @CurrentRow
	   BEGIN
	     SELECT @CurrentRow = @HdrCellRefRow
	-- INSERT END DATE
	    IF @HdrText = 'ReportNAME'
	        BEGIN
	           INSERT INTO #RESULT2
	           VALUES   (
	         0, 
	         @HdrWeight,
	         @HdrBorder,  
	         @REPORTNAME,
	         @hash,
	     @Hash,
	     @Hash)
	
	INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	 
	        END
	-- INSERT SELECTION CRITERIA
	     ELSE IF @HdrText = 'Between'
	     BEGIN
	      INSERT INTO #RESULT2
	      VALUES (  
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @HdrText + ': ' + RTRIM(convert(VARCHAR(50),@FROM,103)) + ' and ' + RTRIM(convert(VARCHAR(50),@TO,103)),
	         @Hash,
	     @Hash,
	     @Hash)
	   
	   INSERT INTO #RESULT2
	       VALUES ( 
	     0, 
	     0, 
	     0,
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)  
	 
	     END
	    
	-- INSERT ALL OTHER TITLES
	     ELSE
	     BEGIN
	       INSERT INTO #RESULT2
	       VALUES (
	     0,  
	         @HdrWeight,
	         @HdrBorder,  
	     @Hash,
	     @Hash,
	     @Hash,
	     @Hash)
	  
	   SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	   EXEC(@SQL)
	     END 
	   END 
	 ELSE
	 BEGIN
	  SELECT @SQL = 'UPDATE #RESULT2 SET ' + @HdrCellRefCol + ' = ''' + @Hdrtext + ''' WHERE INCREMENT = ' + @CurrentRow
	  EXEC(@SQL)
	 -- EXEC ("UPDATE #RESULT SET " + @HdrCellRefCol + " = '"+ @Hdrtext + "' WHERE INCREMENT = " + @CurrentRow)
	 END
	  
	    
	-- FETCH THE NXT ROW IN THE RESULTS SET     --
	   
	    FETCH NEXT FROM fmt_hdr 
	    INTO @HdrCellRefCol, @HdrCellRefRow, @HdrText, @HdrWeight, @HdrBorder
	  END
	-- KILL HEADERS CURSOR       --
	  DEALLOCATE fmt_hdr
	
	INSERT INTO #RESULT2
	SELECT
		INDENT,
		WEIGHT,
		BORDER,
		A,
		B,
		C,
		D
	FROM
		#RESULT
	
END


SELECT * FROM #RESULT2








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_PROPS_BY_STATUS
(
	@ACCMAN INT
)
 AS

IF @ACCMAN = 0
BEGIN
	select
		o.object_name,
		o.housename,
		o.housenumber,
		o.streetname,
		o.address4,
		o.city,
		o.postalcode,
		isnull(e.firstname + ' ' + e.lastname,'') as acman,
		o.max_nr_residents,
		c.company_name,
		os.status_description,
		(select 
			 count(*)
			from 
				RESIDENTS R,
				RESIDENT_OBJECT RO
			where 
				RO.object_id = o.object_id
			and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
			AND 	RO.RESIDENT_ID = R.RESIDENT_ID) as occup
	from 
		objects o,
		companies c,
		company_object oc,
		object_status os,
		employees e
	where
		o.object_id = oc.object_id
	and	oc.company_id = c.company_id
	and	o.status_id = os.status_id
	and	o.status_id in (1,2,3,4,6)
	and	o.account_manager *= e.employee_id
	AND	OC.DATE_TO IS NULL
	order by 
		o.status_id,e.lastname, O.OBJECT_NAME
END
ELSE
BEGIN
	select
		o.object_name,
		o.housename,
		o.housenumber,
		o.streetname,
		o.address4,
		o.city,
		o.postalcode,
		isnull(e.firstname + ' ' + e.lastname,'') as acman,
		o.max_nr_residents,
		c.company_name,
		os.status_description,
		(select 
			 count(*)
			from 
				RESIDENTS R,
				RESIDENT_OBJECT RO
			where 
				RO.object_id = o.object_id
			and	((getdate() between RO.date_from and ISNULL(RO.date_to, DATEADD(D,1,GETDATE()))) OR (GETDATE() > RO.DATE_FROM AND RO.DATE_TO = 01/01/1900))
			AND 	RO.RESIDENT_ID = R.RESIDENT_ID) as occup
	from 
		objects o,
		companies c,
		company_object oc,
		object_status os,
		employees e
	where
		o.object_id = oc.object_id
	and	oc.company_id = c.company_id
	and	o.status_id = os.status_id
	and	o.status_id in (1,2,3,4,6)
	and	o.account_manager *= e.employee_id
	AND	OC.DATE_TO IS NULL
	AND	O.ACCOUNT_MANAGER = @ACCMAN
	order by 
		o.status_id,e.lastname, O.OBJECT_NAME
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE RPT_PROPS_BY_STATUS_DETAILS
(
	@ACCMAN INT
) AS


IF @ACCMAN = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACCMAN
END

IF @ACCMAN = 0
BEGIN
	select 
		count(*)
	from 
		objects o,
		companies c,
		company_object oc,
		object_status os,
		employees e
	where
		o.object_id = oc.object_id
	and	oc.company_id = c.company_id
	and	o.status_id = os.status_id
	and	o.status_id in (1,2,3,4,6)
	and	o.account_manager *= e.employee_id
	AND	OC.DATE_TO IS NULL
END
ELSE
BEGIN
	select 
		count(*)
	from 
		objects o,
		companies c,
		company_object oc,
		object_status os,
		employees e
	where
		o.object_id = oc.object_id
	and	oc.company_id = c.company_id
	and	o.status_id = os.status_id
	and	o.status_id in (1,2,3,4,6)
	and	o.account_manager *= e.employee_id
	AND	OC.DATE_TO IS NULL
	AND	O.ACCOUNT_MANAGER = @ACCMAN
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE RPT_PROSPECT_STATUS 
(
	@ACCMAN INT
)AS

CREATE TABLE #R
(	A VARCHAR(1),
	B VARCHAR(4000),
	C VARCHAR(4000),
	D VARCHAR(4000),	
	E VARCHAR(4000),	
	F VARCHAR(4000),	
	G VARCHAR(4000),
	H VARCHAR(4000)
)

DECLARE @PROP_ID INT


IF @ACCMAN = 0
BEGIN
	DECLARE PROPS CURSOR FOR
		SELECT
			O.OBJECT_ID
		FROM
			OBJECTS O,
			OBJECT_STATUS_HISTORY OS
		WHERE
			O.OBJECT_ID = OS.OBJECT_ID
		AND	GETDATE() > OS.DATE_FROM
		AND	(GETDATE() < OS.DATE_TO OR OS.DATE_TO IS NULL OR OS.DATE_TO = 01/01/1900)
		AND	OS.STATUS_ID = 1
		ORDER BY
			O.DATE_ENTERED,
			O.OBJECT_NAME
END
ELSE
BEGIN
	DECLARE PROPS CURSOR FOR
		SELECT
			O.OBJECT_ID
		FROM
			OBJECTS O,
			OBJECT_STATUS_HISTORY OS
		WHERE
			O.OBJECT_ID = OS.OBJECT_ID
		AND	GETDATE() > OS.DATE_FROM
		AND	(GETDATE() < OS.DATE_TO OR OS.DATE_TO IS NULL OR OS.DATE_TO = 01/01/1900)
		AND	OS.STATUS_ID = 1
		AND	O.ACCOUNT_MANAGER = @ACCMAN
		ORDER BY
			O.DATE_ENTERED,
			O.OBJECT_NAME

END

OPEN PROPS

FETCH NEXT FROM PROPS INTO @PROP_ID

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO #R SELECT 0,'Property','Address','Type','Date Entered','Account Manager','Office',' '
	
	INSERT INTO #R
	SELECT
		2,
		O.OBJECT_NAME,
		ISNULL(O.HOUSENAME,'') + ',' + ISNULL(STREETNAME,'') + ',' + ISNULL(ADDRESS4,'') + ',' + ISNULL(CITY,'') + ',' + ISNULL(POSTALCODE,'') ,
		OT.DESCRIPTION,
		CONVERT(VARCHAR(20),O.DATE_ENTERED,103),
		ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,''),
		A.DESCRIPTION,
		' '
	FROM
		OBJECTS O,
		OBJECT_TYPES OT,
		EMPLOYEES E,
		AREA A
	WHERE
		O.OBJECT_ID = @PROP_ID
	AND	O.OBJECT_TYPE = OT.OBJECT_TYPE_ID
	AND	O.ACCOUNT_MANAGER *= E.EMPLOYEE_ID
	AND 	O.AREA_ID *= A.AREA_ID

	INSERT INTO #R SELECT 1,'Owner','Address','Phone','Email','Website','Type',' '

	INSERT INTO #R
	SELECT
		2,
		C.COMPANY_NAME,
		ISNULL(A.HOUSENAME,'') + ',' + ISNULL(A.STREETNAME,'') + ',' + ISNULL(A.ADDRESS4,'') + ',' + ISNULL(A.CITY,'') + ',' + ISNULL(A.POSTALCODE,'') ,
		C.GENERAL_PHONE,
		C.GENERAL_EMAIL,
		C.GENERAL_WEBSITE,
		CT.DESCRIPTION,
		' '
	FROM
		OBJECTS O,
		COMPANY_OBJECT CO,
		COMPANIES C,
		COMPANY_TYPES CT,
		COMPANY_ADDRESS CA,
		ADDRESSES A
	WHERE
		O.OBJECT_ID = @PROP_ID
	AND	O.OBJECT_ID = CO.OBJECT_ID
	AND	CO.DATE_FROM < GETDATE()
	AND	(CO.DATE_TO > GETDATE() OR CO.DATE_TO IS NULL)
	AND	CO.COMPANY_ID = C.COMPANY_ID
	AND	C.COMPANY_TYPE = CT.COMPANY_TYPE_ID
	AND	C.COMPANY_ID = CA.COMPANY_ID
	AND	CA.ADDRESS_ID = A.ADDRESS_ID
	AND	CA.ADDRESS_TYPE = 1


	INSERT INTO #R SELECT 1,'Sales Contact','Phone','Email','Brochure','Presentation','All Contact',' '
	INSERT INTO #R
	SELECT
		2,
		ISNULL(CT.FIRSTNAME,'No Name') + ' ' + ISNULL(CT.LASTNAME,'No Name'),
		CT.DIRECT_PHONE,
		CT.MOBILE_PHONE,
		(SELECT 'Yes' FROM CONTACT_STATUS_HISTORY WHERE STATUS_ID = 2 AND CONTACT_ID = CT.CONTACT_ID) ,
		(SELECT 'Yes' FROM CONTACT_STATUS_HISTORY WHERE STATUS_ID = 3 AND CONTACT_ID = CT.CONTACT_ID) ,
		(SELECT 'Yes' FROM CONTACT_STATUS_HISTORY WHERE STATUS_ID = 4 AND CONTACT_ID = CT.CONTACT_ID),
		' '
	FROM
		OBJECT_CONTACT OC,
		CONTACTS CT,
		COMPANY_CONTACT CC,
		OBJECT_CONTACT_TYPE OCT,
		COMPANIES C
	WHERE
		OC.OBJECT_ID = @PROP_ID
	AND	OC.CONTACT_ID = CT.CONTACT_ID
	AND	CT.CONTACT_ID = CC.CONTACT_ID
	AND	CC.COMPANY_ID = C.COMPANY_ID
	AND	OC.OBJECT_ID = OCT.OBJECT_ID
	AND	CT.CONTACT_ID = OCT.CONTACT_ID
	AND	OCT.CONTACT_TYPE = 15


	INSERT INTO #R SELECT 3,'Date Entered','Entered By',NULL,NULL,NULL,NULL,'Note'

	INSERT INTO #R
	SELECT
		4,
		CONVERT(VARCHAR(20),N.DATE_ENTERED,103),
		ISNULL(E.FIRSTNAME,'') + ' ' + ISNULL(E.LASTNAME,''),
		NULL,
		NULL,
		NULL,
		NULL,
		N.REGARDING
	FROM
		NOTES N,
		EMPLOYEES E
	WHERE
		N.OBJECT_ID = @PROP_ID
	AND	N.RECORD_MANAGER *= E.EMPLOYEE_ID
	ORDER BY
		N.DATE_ENTERED DESC
	
	FETCH NEXT FROM PROPS INTO @PROP_ID
END

CLOSE PROPS
DEALLOCATE PROPS

SELECT * FROM #R






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_PROSPECT_STATUS_DETAILS
(
	@ACCMAN INT
) AS


IF @ACCMAN = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACCMAN
END

IF @ACCMAN = 0
BEGIN
	SELECT
		COUNT(*)
	FROM
			OBJECTS O,
			OBJECT_STATUS_HISTORY OS
		WHERE
			O.OBJECT_ID = OS.OBJECT_ID
		AND	GETDATE() > OS.DATE_FROM
		AND	(GETDATE() < OS.DATE_TO OR OS.DATE_TO IS NULL OR OS.DATE_TO = 01/01/1900)
		AND	OS.STATUS_ID = 1
END		
ELSE
BEGIN
	SELECT
		COUNT(*)
	FROM
			OBJECTS O,
			OBJECT_STATUS_HISTORY OS
		WHERE
			O.OBJECT_ID = OS.OBJECT_ID
		AND	GETDATE() > OS.DATE_FROM
		AND	(GETDATE() < OS.DATE_TO OR OS.DATE_TO IS NULL OR OS.DATE_TO = 01/01/1900)
		AND	OS.STATUS_ID = 1
		AND	O.ACCOUNT_MANAGER = @ACCMAN
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE RPT_VETTING
(
	@ACC INT
) AS



IF @ACC = 0
BEGIN
	SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND 	EXEC_DES = 0
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END
ELSE
	BEGIN
		SELECT
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'') AS GUARDIAN,
		O.OBJECT_NAME AS PROPERTY,
		RO.DATE_FROM AS START,
		CASE R.PHOTO_ID
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS PHOTO,
		CASE R.LICENSE
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS LICENSE,
		CASE R.APPLIC_FORM 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS APPLICATION,
		CASE R.BANK_UTIL 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [BANK-UTILITY],
		CASE R.REF 
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [REFERENCES],
		CASE R.BOOKLET
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS BOOKLET,
		CASE R.STAND
			WHEN 0 THEN 'No'
			ELSE 'Yes'
		END AS [STANDING ORDER],
		R.VNOTES AS NOTES
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND	O.ACCOUNT_MANAGER = @ACC
	AND 	EXEC_DES = 0
	ORDER BY 
		O.OBJECT_NAME,
		ISNULL(R.FIRSTNAME,'') + '  ' + ISNULL(LASTNAME,'')
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE RPT_VETTING_DETAILS
(
	@ACC INT
) AS

IF @ACC = 0
BEGIN
	SELECT 'All Account Managers' as ACCOUNT_MANAGER
END
ELSE
BEGIN
	SELECT
		ISNULL(FIRSTNAME,'') + ' ' + ISNULL(LASTNAME,'') AS ACCOUNT_MANAGER
	FROM
		EMPLOYEES
	WHERE
		EMPLOYEE_ID = @ACC
END

IF @ACC = 0
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND	R.EXEC_DES = 0
END
ELSE
BEGIN
	SELECT
		COUNT(*) AS CNT
	FROM
		RESIDENTS R,
		RESIDENT_OBJECT RO,
		OBJECTS O
	WHERE
		((GETDATE() BETWEEN RO.DATE_FROM AND ISNULL(RO.DATE_TO, DATEADD(D,1,GETDATE()))) OR RO.DATE_TO = 01/01/1900)
	AND	R.RESIDENT_ID = RO.RESIDENT_ID
	AND	RO.OBJECT_ID = O.OBJECT_ID
	AND	(R.PHOTO_ID = 0 OR R.APPLIC_FORM=0 OR R.BANK_UTIL=0 OR R.REF=0 OR R.STAND=0)
	AND	R.EXEC_DES = 0
	AND	O.ACCOUNT_MANAGER = @ACC
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE SAVE_SECOND_ADDRESS
(
	@GUARD INT,
	@ADDR1 VARCHAR(250),
	@ADDR2 VARCHAR(250),
	@ADDR3 VARCHAR(250),
	@ADDR4 VARCHAR(250),
	@POST VARCHAR(250),
	@CITY VARCHAR(250),
	@COUNTY VARCHAR(250),
	@COUNTRY VARCHAR(250),
	@AREA INT,
	@EMPLOY INT
) AS

DECLARE @CNT INT
DECLARE @ADD_ID INT
SELECT @ADD_ID = 0

SELECT @CNT = COUNT(*) FROM RESIDENT_ADDRESS WHERE RESIDENT_ID = @GUARD AND ADDRESS_TYPE = 4


IF @CNT = 0
BEGIN
	INSERT INTO 
		ADDRESSES (HOUSENAME, STREETNAME, ADDRESS4,ADDRESS5,CITY,POSTALCODE, COUNTY, COUNTRY, AREA_ID, DATE_ENTERED, RECORD_MANAGER)
	SELECT
		@ADDR1,
		@ADDR2,
		@ADDR3,
		@ADDR4,
		@CITY,
		@POST,
		@COUNTY,
		@COUNTRY,
		@AREA,
		GETDATE(),
		@EMPLOY

	SELECT @ADD_ID = @@IDENTITY

	INSERT INTO RESIDENT_ADDRESS
		SELECT @GUARD, @ADD_ID, 4
END
ELSE
BEGIN

	SELECT @ADD_ID = ADDRESS_ID FROM RESIDENT_ADDRESS WHERE RESIDENT_ID = @GUARD AND ADDRESS_TYPE = 4

	UPDATE 
		ADDRESSES
	SET
		HOUSENAME =@ADDR1,
		STREETNAME = @ADDR2,
		ADDRESS4 = @ADDR3,
		ADDRESS5 = @ADDR4,
		CITY = @CITY,
		POSTALCODE = @POST,
		COUNTY = @COUNTY,
		COUNTRY = @COUNTRY,
		AREA_ID = @AREA,
		DATE_ENTERED = GETDATE(),
		RECORD_MANAGER = @EMPLOY
	WHERE
		ADDRESS_ID = @ADD_ID
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE SAVE_VISIT_ADDRESS
(
	@COMP INT,
	@ADDR1 VARCHAR(250),
	@ADDR2 VARCHAR(250),
	@ADDR3 VARCHAR(250),
	@ADDR4 VARCHAR(250),
	@POST VARCHAR(250),
	@CITY VARCHAR(250),
	@COUNTY VARCHAR(250),
	@COUNTRY VARCHAR(250),
	@AREA INT,
	@EMPLOY INT
) AS

DECLARE @ADD_ID INT
DECLARE @CNT INT
SELECT @ADD_ID = 0

SELECT @CNT = COUNT(*) FROM COMPANY_ADDRESS WHERE COMPANY_ID = @COMP AND ADDRESS_TYPE = 2


IF @CNT = 0
BEGIN
	INSERT INTO 
		ADDRESSES (HOUSENAME, STREETNAME, ADDRESS4,ADDRESS5,CITY,POSTALCODE, COUNTY, COUNTRY, AREA_ID, DATE_ENTERED, RECORD_MANAGER)
	SELECT
		@ADDR1,
		@ADDR2,
		@ADDR3,
		@ADDR4,
		@CITY,
		@POST,
		@COUNTY,
		@COUNTRY,
		@AREA,
		GETDATE(),
		@EMPLOY

	SELECT @ADD_ID = @@IDENTITY

	INSERT INTO COMPANY_ADDRESS
		SELECT @COMP, @ADD_ID, 2
END
ELSE
BEGIN
	
	SELECT @ADD_ID = ADDRESS_ID FROM COMPANY_ADDRESS WHERE COMPANY_ID = @COMP AND ADDRESS_TYPE = 2

	UPDATE 
		ADDRESSES
	SET
		HOUSENAME =@ADDR1,
		STREETNAME = @ADDR2,
		ADDRESS4 = @ADDR3,
		ADDRESS5 = @ADDR4,
		CITY = @CITY,
		POSTALCODE = @POST,
		COUNTY = @COUNTY,
		COUNTRY = @COUNTRY,
		AREA_ID = @AREA,
		DATE_ENTERED = GETDATE(),
		RECORD_MANAGER = @EMPLOY
	WHERE
		ADDRESS_ID = @ADD_ID
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE SET_DEF_PHOTO
(
	@PHOTO_ID INT,
	@PARENT INT,
	@TYPE INT
) AS


UPDATE PHOTOS SET IS_DEFAULT = 0 WHERE PARENT = @PARENT AND PHOTO_TYPE_ID = @TYPE

UPDATE PHOTOS SET IS_DEFAULT = 1 WHERE PHOTO_ID = @PHOTO_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






CREATE PROCEDURE SET_REP_SENT
(
	@INSP_ID INT
) AS


UPDATE 
	OBJECT_CHECKS
SET 
	REPORT_SENT = 1,
	DATE_SENT = GETDATE()
WHERE
	OBJECT_CHECK_ID = @INSP_ID





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO










CREATE Procedure SP_ADDADDRESS
(
	@ADRES1 NVARCHAR(500) = NULL , 
	@HOUSENUMBER NVARCHAR(50) = NULL , 
	@STREETNAME NVARCHAR(500) = NULL ,
             @ADRES4 NVARCHAR(500) = NULL , 
	@ADRES5 NVARCHAR(500) = NULL , 
	@POSTALCODE NVARCHAR(50) = NULL ,  
	@CITY  NVARCHAR(500) = NULL , 
	@COUNTRY NVARCHAR(100) = NULL ,
	@NEWADDRESS_ID INT OUTPUT
	)
As
begin
	SET DATEFORMAT DMY 
            INSERT INTO ADRESSES
	( 
		ADRES1 , HOUSENUMBER ,  STREETNAME ,
            	ADRES4 , ADRES5 , POSTALCODE ,  CITY , COUNTRY 
	) 
	VALUES
	( 
		@ADRES1 , @HOUSENUMBER ,  @STREETNAME ,
            	@ADRES4 , @ADRES5 , @POSTALCODE ,  @CITY , @COUNTRY 
	)
	SELECT @NEWADDRESS_ID = ADDRESS_ID FROM ADRESSES
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE UPDATE_ACTION
(
	@INC_ID INT,
	@ACT_ID INT,
	@DATE SMALLDATETIME,
	@STATUS INT,
	@ACTION INT,
	@DESC VARCHAR(4000),
	@RESP INT,
	@RECORD_MANAGER INT,
	@WEB BIT
)AS

DECLARE @CNT INT
DECLARE @ID INT

SELECT
	@CNT = COUNT(*) FROM COMPLAINT_HISTORY WHERE ACTION_ID = @ACT_ID

IF @CNT >= 1
BEGIN
	UPDATE
		COMPLAINT_HISTORY
	SET
		STATUS_CODE = @STATUS,
		ACTION_UNDERTAKEN = @ACTION,
		DESCRIPTION = @DESC,
		RESPONSIBLE = @RESP,
		RECORD_MANAGER=@RECORD_MANAGER,
		SHOW_OWNER = @WEB
	WHERE
		ACTION_ID = @ACT_ID

END
ELSE
BEGIN
	INSERT INTO COMPLAINT_HISTORY (COMPLAINT_ID,
				DATE_ENTERED,
				STATUS_CODE,
				ACTION_UNDERTAKEN,
				DESCRIPTION,
				RESPONSIBLE,
				RECORD_MANAGER,
				SHOW_OWNER)
	VALUES
		(@INC_ID,
		@DATE,
		@STATUS,
		@ACTION,
		@DESC,
		@RESP,
		@RECORD_MANAGER,
		@WEB)

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_COMPANY
(
	@COMP_ID INT,
	@COMPNAME VARCHAR(250),
	@HOUSENAME VARCHAR(50),
	@STREETNAME VARCHAR(50),
	@ADDRESS4 VARCHAR(50),
	@ADDRESS5 VARCHAR(50),
	@CITY VARCHAR(50),
	@COUNTY VARCHAR(50),
	@POSTALCODE VARCHAR(50),
	@COUNTRY VARCHAR(50),
	@AREA_ID INT,
	@STATUS_ID INT,
	@COMPANY_TYPE INT,
	@STAT_EFF VARCHAR(20),
	@ACCOUNT_MANAGER INT,
	@SALES_MANAGER INT,
	@RECORD_MODIFIER INT,
	@TEL VARCHAR(50),
	@FAX VARCHAR(50),
	@EMAIL VARCHAR(50),
	@WEB VARCHAR(50)
)AS

DECLARE @ADD_ID AS INT

SELECT TOP 1
	@ADD_ID = A.ADDRESS_ID
FROM 
	ADDRESSES A,
	COMPANY_ADDRESS CA
WHERE
	CA.ADDRESS_ID = A.ADDRESS_ID
AND
	CA.COMPANY_ID = @COMP_ID
ORDER BY A.ADDRESS_ID DESC


UPDATE
	ADDRESSES
SET
	HOUSENAME = @HOUSENAME,
	STREETNAME = @STREETNAME,
	ADDRESS4 = @ADDRESS4,
	ADDRESS5 = @ADDRESS5,
	CITY = @CITY,
	COUNTY = @COUNTY,
	POSTALCODE = @POSTALCODE,
	COUNTRY = @COUNTRY,
	AREA_ID = @AREA_ID
WHERE
	ADDRESS_ID = @ADD_ID

UPDATE 
	COMPANIES
SET
	COMPANY_NAME = @COMPNAME,
	ACCOUNT_MANAGER = @ACCOUNT_MANAGER,
	SALES_MANAGER = @SALES_MANAGER,
	STATUS_ID = @STATUS_ID,
	COMPANY_TYPE = @COMPANY_TYPE,
	STATUS_EFFECTIVE = CONVERT(SMALLDATETIME,@STAT_EFF,103),
	GENERAL_PHONE = @TEL,
	GENERAL_FAX = @FAX,
	GENERAL_EMAIL = @EMAIL,
	GENERAL_WEBSITE = @WEB,
	RECORD_MODIFIER = @RECORD_MODIFIER,
	DATE_MODIFIED = getdate()
WHERE
	COMPANY_ID = @COMP_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_COMPANY_BANK
(	
	@COMP_ID INT,
	@SORTCODE VARCHAR(10),
	@ACCOUNT VARCHAR(10),
	@ANAME VARCHAR(250),
	@ADDRESS1 VARCHAR(250), 
	@ADDRESS2 VARCHAR(250),
	@ADDRESS3 VARCHAR(250),
	@CITY VARCHAR(250),
	@POSTCODE VARCHAR(250),
	@COUNTY VARCHAR(250),
	@DDAY INT
)AS

DECLARE @BID INT
DECLARE @AID INT

SELECT @BID = ISNULL(BANKDETAIL_ID,0) FROM COMPANY_BANK WHERE COMPANY_ID = @COMP_ID

IF @BID IS NULL
BEGIN
	INSERT INTO 
		ADDRESSES (HOUSENUMBER, STREETNAME, ADDRESS4, CITY, POSTALCODE, COUNTY)
	SELECT
		@ADDRESS1,
		@ADDRESS2,
		@ADDRESS3,
		@CITY,
		@POSTCODE,
		@COUNTY

	SELECT @AID = @@IDENTITY

	INSERT INTO BANK_DETAILS
	SELECT
		@SORTCODE,
		@ACCOUNT,
		@ANAME,
		@AID

	SELECT @BID = @@IDENTITY

	INSERT INTO COMPANY_BANK
		SELECT @COMP_ID, @BID, @DDAY
END
ELSE
BEGIN
	SELECT @BID = BANKDETAIL_ID FROM COMPANY_BANK WHERE COMPANY_ID = @COMP_ID

	SELECT @AID = ADDRESS_ID FROM BANK_DETAILS WHERE BANKDETAIL_ID = @BID

	UPDATE 
		ADDRESSES
	SET
		HOUSENUMBER = @ADDRESS1,
		STREETNAME = @ADDRESS2,
		ADDRESS4 = @ADDRESS3,
		CITY = @CITY,
		POSTALCODE = @POSTCODE,
		COUNTY = @COUNTY
	WHERE
		ADDRESS_ID = @AID

	UPDATE
		BANK_DETAILS
	SET
		SORTCODE = @SORTCODE,
		ACCOUNTNUMBER = @ACCOUNT,
		ACCOUNTNAME = @ANAME
	WHERE
		BANKDETAIL_ID = @BID

	UPDATE
		COMPANY_BANK
	SET
		DEBIT_DAY = @DDAY
	WHERE
		COMPANY_ID = @COMP_ID
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_COMPANY_NOTE
(
	@COMP_ID NUMERIC(18),
	@NOTE_ID NUMERIC(18),
	@DESC VARCHAR(8000),
	@DATE SMALLDATETIME,
	@INOUTLOOK BIT,
	@RECORD_MANAGER INT,
	@CONTACT_ID NUMERIC(18)
) AS

IF @NOTE_ID <> 0
BEGIN
	UPDATE
		NOTES
	SET
		CONTACT_ID = @CONTACT_ID,
		ACTIVITY_DATE = @DATE,
		REGARDING = @DESC,
		SAVED_IN_OUTLOOK = @INOUTLOOK,
		RECORD_MANAGER = @RECORD_MANAGER,
		DATE_ENTERED = GETDATE()
	WHERE
		ACTIVITY_ID = @NOTE_ID
END
ELSE
BEGIN
	INSERT INTO
		NOTES
	SELECT
		@COMP_ID,
		NULL,
		@CONTACT_ID,
		NULL,
		@DATE,
		@DESC,
		@INOUTLOOK,
		@RECORD_MANAGER,
		GETDATE(),0
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO













CREATE PROCEDURE UPDATE_CONTACT
(	@PROP_ID INT,
	@COMP_ID INT,
	@CONTACT_ID INT,
	@STATUS_ID INT,
	@TITLE VARCHAR(50),
	@FIRSTNAME VARCHAR(50),
	@INITIALS VARCHAR(50),
	@PREFIX VARCHAR(50),
	@SALUTATION VARCHAR(250),
	@LASTNAME VARCHAR(50),
	@WKTEL VARCHAR(50),
	@FAX VARCHAR(50),
	@MOBILE VARCHAR(50),
	@EMAIL VARCHAR(50),
	@JOB_TITLE VARCHAR(50),
	@BULK INT,
	@NOTES VARCHAR(4000),
	@RECORD_MODIFIER INT,
	@STAT_EFF SMALLDATETIME,
	@SRC VARCHAR(10)

)AS

DECLARE @STAT INT
DECLARE @DT SMALLDATETIME
DECLARE @OSTAT  INT


DECLARE @CNT INT
DECLARE @ID INT

SELECT
	@CNT = COUNT(*) FROM CONTACTS WHERE CONTACT_ID = @CONTACT_ID

IF @CNT = 1
BEGIN

	SELECT 
		@STAT = CONTACT_STATUS_ID
	FROM
		CONTACTS
	WHERE
		CONTACT_ID = @CONTACT_ID

	UPDATE
		CONTACTS
	SET
		TITLE = @TITLE,
		FIRSTNAME = @FIRSTNAME,
		INITIALS  = @INITIALS,
		LASTNAME=@LASTNAME,
		PREFIX = @PREFIX,
		SALUTATION = @SALUTATION,
		DIRECT_PHONE = @WKTEL,
		DIRECT_FAX = @FAX,
		DIRECT_EMAIL = @EMAIL,
		MOBILE_PHONE = @MOBILE,
		JOB_TITLE = @JOB_TITLE,
		CONTACT_STATUS_ID = @STATUS_ID,
		NOTES = @NOTES,
		RECORD_MODIFIER = @RECORD_MODIFIER,
		DATE_MODIFIED=GETDATE(),
		RECIEVE_MAIL = @BULK,
		COMPANY_ID = @COMP_ID,
		STAT_EFF = @STAT_EFF
	WHERE
		CONTACT_ID = @CONTACT_ID


	IF @STAT <> @STATUS_ID
	BEGIN
		UPDATE
			CONTACT_STATUS_HISTORY
		SET
			DATE_TO = @STAT_EFF
		WHERE
			CONTACT_ID = @CONTACT_ID
		AND	STATUS_ID = @STAT
		AND	DATE_TO = 01/01/1900
		
		INSERT INTO CONTACT_STATUS_HISTORY
			SELECT @CONTACT_ID, @STATUS_ID, @STAT_EFF, 01/01/1900
	END

END
ELSE
BEGIN

	INSERT INTO CONTACTS (TITLE,
					FIRSTNAME,
					INITIALS,
					LASTNAME,
					PREFIX,
					SALUTATION,
					DIRECT_PHONE,
					DIRECT_FAX,
					DIRECT_EMAIL,
					MOBILE_PHONE,
					JOB_TITLE,
					CONTACT_STATUS_ID ,
					STAT_EFF,
					NOTES ,
					RECORD_MODIFIER,
					DATE_MODIFIED,
					RECIEVE_MAIL,
					COMPANY_ID )
			VALUES
		(@TITLE,
		@FIRSTNAME,
		@INITIALS,
		@LASTNAME,
		@PREFIX,
		@SALUTATION,
		@WKTEL,
		@FAX,
		@EMAIL,
		@MOBILE,
		@JOB_TITLE,
		@STATUS_ID,
		@STAT_EFF,
		@NOTES,
		@RECORD_MODIFIER,
		GETDATE(),
		@BULK,
		@COMP_ID)

		SELECT @CONTACT_ID = @@IDENTITY

		INSERT INTO CONTACT_STATUS_HISTORY
			SELECT @CONTACT_ID, @STATUS_ID, @STAT_EFF, 01/01/1900

		
		INSERT INTO COMPANY_CONTACT (COMPANY_ID, CONTACT_ID) SELECT @COMP_ID, @CONTACT_ID

		IF @SRC = 'PROP'
		BEGIN
			INSERT INTO OBJECT_CONTACT VALUES(@PROP_ID, @CONTACT_ID,GETDATE(),NULL,@NOTES,@STATUS_ID,@RECORD_MODIFIER,GETDATE())
		END

END

SELECT @CONTACT_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_FACILITY
(
	@PROP_ID INT,
	@FAC_ID INT,
	@FAC_TYPE INT,
	@FAC_DESC VARCHAR(250),
	@FAC_LOC VARCHAR(250),
	@FAC_SN VARCHAR(50),
	@INSDATE VARCHAR(250),
	@REMDATE VARCHAR(250),
	@LASTCHECK VARCHAR(250),
	@NEXTCHECK VARCHAR(250),
	@MAINT_ID INT,
	@NOTES VARCHAR(4000),
	@RES_ID INT,
	@RECORD_MANAGER INT,
	@INUSE BIT,
	@INSP BIT
)AS

DECLARE @CNT INT

SELECT
	@CNT = COUNT(*) FROM FACILITIES WHERE FACILITY_ID = @FAC_ID

IF @CNT = 1
BEGIN
	UPDATE
		FACILITIES
	SET
		FACILITY_TYPE = @FAC_TYPE,
		SERIAL_NUMBER = @FAC_SN,
		DESCRIPTION = @FAC_DESC,
		LOCATION = @FAC_LOC,
		DATE_INSTALLED = CONVERT(SMALLDATETIME,@INSDATE,103),
		DATE_REMOVED = CONVERT(SMALLDATETIME,@REMDATE,103),
		DATE_LAST_CHECK = CONVERT(SMALLDATETIME,@LASTCHECK,103),
		DATE_NEXT_CHECK = CONVERT(SMALLDATETIME,@NEXTCHECK,103),
		MAINT_ID = @MAINT_ID,
		REMARKS = @NOTES,
		RESIDENT_ID = @RES_ID,
		RECORD_MANAGER = @RECORD_MANAGER,
		DATE_MODIFIED=GETDATE(),
		IN_USE = @INUSE,
		IN_INSP = @INSP
	WHERE
		FACILITY_ID = @FAC_ID
END
ELSE
BEGIN
	INSERT INTO FACILITIES (FACILITY_TYPE,
					SERIAL_NUMBER,
					DESCRIPTION ,
					LOCATION,
					DATE_INSTALLED,
					DATE_REMOVED,
					DATE_LAST_CHECK,
					DATE_NEXT_CHECK,
					MAINT_ID,
					REMARKS,
					RESIDENT_ID,
					RECORD_MANAGER,
					DATE_MODIFIED,
					IN_USE,
					IN_INSP)
	VALUES
		(@FAC_TYPE,
		@FAC_SN,
		@FAC_DESC,
		@FAC_LOC,
		@INSDATE,
		@REMDATE,
		@LASTCHECK,
		@NEXTCHECK,
		@MAINT_ID,
		@NOTES,
		@RES_ID,
		@RECORD_MANAGER,
		GETDATE(),
		@INUSE,
		@INSP)

	INSERT INTO 
		OBJECT_FACILITIES
	SELECT
		@PROP_ID,
		@@IDENTITY
	
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO












CREATE PROCEDURE UPDATE_GUARDIAN
(	@PROP_ID INT,
	@GUARD_ID INT,
	@STATUS_ID INT,
	@TITLE VARCHAR(50),
	@FIRSTNAME VARCHAR(50),
	@INITIALS VARCHAR(50),
	@LASTNAME VARCHAR(50),
	@PREFIX VARCHAR(50),
	@SALUTATION VARCHAR(250),
	@DOB VARCHAR(50),
	@NAT VARCHAR(50),
	@SEX INT,
	@WKTEL VARCHAR(50),
	@HMTEL VARCHAR(50),
	@PTEL VARCHAR(50),
	@MOBILE VARCHAR(50),
	@HMMOB VARCHAR(50),
	@PMOB VARCHAR(50),
	@FAX VARCHAR(50),
	@EMAIL VARCHAR(50),
	@HMEMAIL VARCHAR(50),
	@PEMAIL VARCHAR(50),
	@RECORD_MODIFIER INT,
	@RENT VARCHAR(50),
	@BREAK VARCHAR(50),
	@REASON VARCHAR(250),
	@FIRE VARCHAR(50),
	@INS VARCHAR(50),
	@MAIN BIT,
	@DATE_FROM VARCHAR(50),
	@DATE_TO VARCHAR(50),
	@ROOM VARCHAR(250)
)AS

DECLARE @CNT INT
DECLARE @ID INT
DECLARE @DT SMALLDATETIME

IF @DOB IS NULL
BEGIN
	SELECT @DOB='1/1/1900'
END

IF @FIRE IS NULL
BEGIN
	SELECT @FIRE='1/1/1900'
END


IF @BREAK IS NULL
BEGIN
	SELECT @BREAK='1/1/1900'
END

SELECT
	@CNT = COUNT(*) FROM RESIDENTS WHERE RESIDENT_ID = @GUARD_ID

IF @CNT = 1
BEGIN
	UPDATE
		RESIDENTS
	SET
		TITLE = @TITLE,
		FIRSTNAME = @FIRSTNAME,
		INITIALS  = @INITIALS,
		LASTNAME=@LASTNAME,
		PREFIX= @PREFIX,
		SALUTATION = @SALUTATION,
		BIRTH_DATE = CONVERT(SMALLDATETIME,@DOB,103),
		NATIONALITY = @NAT,
		GENDER = @SEX,
		PHONE = @WKTEL,
		PRIVATE_PHONE = @HMTEL,
		PARENT_PHONE=@PTEL,
		FAX = @FAX,
		EMAIL = @EMAIL,
		PRIVATE_EMAIL = @HMEMAIL,
		PARENT_EMAIL = @PEMAIL,
		MOBILE = @MOBILE,
		PRIVATE_MOBILE = @HMMOB,
		PARENT_MOBILE = @PMOB,
		RESIDENT_STATUS_ID = @STATUS_ID,
		RECORD_MODIFIER = @RECORD_MODIFIER,
		DATE_MODIFIED=GETDATE(),
		RENT =@RENT,
		RENT_BREAK = CONVERT(SMALLDATETIME,@BREAK,103),
		BREAK_REASON = @REASON,
		FIREPACK = CONVERT(SMALLDATETIME,@FIRE,103),
		INSURANCE = @INS
	WHERE
		RESIDENT_ID = @GUARD_ID

	SELECT 
		@DT = DATE_FROM
	FROM
		RESIDENT_OBJECT
	WHERE
		RESIDENT_ID = @GUARD_ID
	AND	OBJECT_ID = @PROP_ID

	UPDATE
		RESIDENT_OBJECT
	SET
		MAIN_RESIDENT = @MAIN,
		DATE_FROM = CONVERT(SMALLDATETIME,@DATE_FROM,103),
		DATE_TO = CONVERT(SMALLDATETIME,@DATE_TO,103),
		ROOM = @ROOM
	WHERE
		RESIDENT_ID = @GUARD_ID
	AND	OBJECT_ID = @PROP_ID
	AND	DATE_FROM = @DT

END
ELSE
BEGIN

	INSERT INTO
		RESIDENTS
		
		(TITLE,
		FIRSTNAME,
		INITIALS,
		LASTNAME,
		PREFIX,
		SALUTATION,
		BIRTH_DATE,
		NATIONALITY,
		GENDER,
		PHONE,
		PRIVATE_PHONE,
		PARENT_PHONE,
		FAX,
		EMAIL,
		PRIVATE_EMAIL,
		PARENT_EMAIL,
		MOBILE,
		PRIVATE_MOBILE,
		PARENT_MOBILE,
		RESIDENT_STATUS_ID,
		RECORD_MODIFIER,
		DATE_MODIFIED,
		RENT,
		RENT_BREAK,
		BREAK_REASON,
		FIREPACK,
		INSURANCE)
	VALUES
		(@TITLE,
		@FIRSTNAME,
		@INITIALS,
		@LASTNAME,
		@PREFIX,
		@SALUTATION,
		CONVERT(SMALLDATETIME,@DOB,103),
		@NAT,
		@SEX,
		@WKTEL,
		@HMTEL,
		@PTEL,
		@FAX,
		@EMAIL,
		@HMEMAIL,
		@PEMAIL,
		@MOBILE,
		@HMMOB,
		@PMOB,
		@STATUS_ID,
		@RECORD_MODIFIER,
		GETDATE(),
		@RENT,
		CONVERT(SMALLDATETIME,@BREAK,103),
		@REASON,
		CONVERT(SMALLDATETIME,@FIRE,103),
		@INS)

	SELECT @GUARD_ID = @@IDENTITY

	INSERT INTO
		RESIDENT_OBJECT
	SELECT
		@GUARD_ID,
		@PROP_ID,
		CONVERT(SMALLDATETIME,@DATE_FROM,103),
		CONVERT(SMALLDATETIME,@DATE_TO,103),
		@MAIN,
		@RECORD_MODIFIER,
		GETDATE(),
		ROOM = @ROOM

	SELECT @GUARD_ID

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_GUARDIAN_BANK
(	
	@GUARD_ID INT,
	@SORTCODE VARCHAR(10),
	@ACCOUNT VARCHAR(10),
	@ANAME VARCHAR(250),
	@ADDRESS1 VARCHAR(250), 
	@ADDRESS2 VARCHAR(250),
	@ADDRESS3 VARCHAR(250),
	@CITY VARCHAR(250),
	@POSTCODE VARCHAR(250),
	@COUNTY VARCHAR(250),
	@DDAY INT
)AS

DECLARE @BID INT
DECLARE @AID INT

SELECT @BID = ISNULL(BANKDETAIL_ID,0) FROM RESIDENT_BANK WHERE RESIDENT_ID = @GUARD_ID

IF @BID IS NULL
BEGIN
	INSERT INTO 
		ADDRESSES (HOUSENUMBER, STREETNAME, ADDRESS4, CITY, POSTALCODE, COUNTY)
	SELECT
		@ADDRESS1,
		@ADDRESS2,
		@ADDRESS3,
		@CITY,
		@POSTCODE,
		@COUNTY

	SELECT @AID = @@IDENTITY

	INSERT INTO BANK_DETAILS
	SELECT
		@SORTCODE,
		@ACCOUNT,
		@ANAME,
		@AID

	SELECT @BID = @@IDENTITY

	INSERT INTO RESIDENT_BANK
		SELECT @GUARD_ID, @BID, @DDAY
END
ELSE
BEGIN
	SELECT @BID = BANKDETAIL_ID FROM RESIDENT_BANK WHERE RESIDENT_ID = @GUARD_ID

	SELECT @AID = ADDRESS_ID FROM BANK_DETAILS WHERE BANKDETAIL_ID = @BID

	UPDATE 
		ADDRESSES
	SET
		HOUSENUMBER = @ADDRESS1,
		STREETNAME = @ADDRESS2,
		ADDRESS4 = @ADDRESS3,
		CITY = @CITY,
		POSTALCODE = @POSTCODE,
		COUNTY = @COUNTY
	WHERE
		ADDRESS_ID = @AID

	UPDATE
		BANK_DETAILS
	SET
		SORTCODE = @SORTCODE,
		ACCOUNTNUMBER = @ACCOUNT,
		ACCOUNTNAME = @ANAME
	WHERE
		BANKDETAIL_ID = @BID

	UPDATE
		RESIDENT_BANK
	SET
		DEBIT_DAY = @DDAY
	WHERE
		RESIDENT_ID = @GUARD_ID
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE UPDATE_INCIDENT
(	@PROP_ID INT,
	@COMP_ID INT,
	@INC_ID INT,
	@INC_TYPE INT,
	@SRC_TYPE INT,
	@URG_TYPE INT,
	@STARTDATE SMALLDATETIME,
	@RESDATE SMALLDATETIME,
	@CNAME VARCHAR(500),
	@NAME_ID INT,
	@DPHONE VARCHAR(250),
	@MOBILE VARCHAR(250),
	@WKPHONE VARCHAR(250),
	@EMAIL VARCHAR(250),
	@DESC VARCHAR(4000),
	@SOL VARCHAR(4000),
	@RECORD_MANAGER INT,
	@WEB BIT
)AS

DECLARE @CNT INT
DECLARE @ID INT

SELECT
	@CNT = COUNT(*) FROM COMPLAINTS WHERE COMPLAINT_ID = @INC_ID

IF @CNT >= 1
BEGIN
	UPDATE
		COMPLAINTS
	SET
		COMPLAINT_TYPE=@INC_TYPE,
		COMPLAINT_SOURCE=@SRC_TYPE,
		COMPANY_ID = @COMP_ID,
		URGENCY=@URG_TYPE,
		COMPLAINT_DATE=@STARTDATE,
		RESOLUTION_DATE=@RESDATE,
		C_NAME=@CNAME ,
		NAME_ID=@NAME_ID ,
		DIRECT_PHONE=@DPHONE,
		MOBILE_PHONE=@MOBILE,
		PHONE=@WKPHONE,
		EMAIL=@EMAIL,
		DESCRIPTION=@DESC,
		SOLUTION=@SOL,
		RECORD_MANAGER=@RECORD_MANAGER,
		SHOW_OWNER = @WEB	
	WHERE
		COMPLAINT_ID = @INC_ID

	UPDATE
		OBJECT_COMPLAINTS
	SET
		OBJECT_ID = @PROP_ID
	WHERE
		COMPLAINT_ID = @INC_ID
	
END
ELSE
BEGIN
	INSERT INTO COMPLAINTS (COMPLAINT_TYPE,
				COMPLAINT_SOURCE,
				COMPANY_ID,
				URGENCY,
				COMPLAINT_DATE,
				RESOLUTION_DATE,
				C_NAME,
				NAME_ID,
				DIRECT_PHONE,
				MOBILE_PHONE,
				PHONE,
				EMAIL,
				DESCRIPTION,
				SOLUTION,
				RECORD_MANAGER,
				SHOW_OWNER )
	VALUES
		(@INC_TYPE,
		@SRC_TYPE,
		@COMP_ID,
		@URG_TYPE,
		@STARTDATE,
		@RESDATE,
		@CNAME ,
		@NAME_ID ,
		@DPHONE,
		@MOBILE,
		@WKPHONE,
		@EMAIL,
		@DESC,
		@SOL,
		@RECORD_MANAGER,
		@WEB)

	SELECT @ID = @@IDENTITY

	INSERT INTO 
		OBJECT_COMPLAINTS
	SELECT
		@PROP_ID,
		@ID

	INSERT INTO COMPLAINT_HISTORY
		SELECT
			@ID,
			5,
			@STARTDATE,
			@RECORD_MANAGER,
			@RECORD_MANAGER,
			0,
			'',
			@RECORD_MANAGER,
			0
	
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_INSPECTION
(
	@INSP_ID AS INT,
	@DATE VARCHAR(20),
	@INSPECTOR INT,
	@REP_COMM VARCHAR(4000)
) AS

UPDATE
	OBJECT_CHECKS
SET
	DATE_CHECK  = CONVERT(SMALLDATETIME,@DATE,103),
	RECORD_MANAGER = @INSPECTOR,
	REPORT_COMMENTS = @REP_COMM
WHERE
	OBJECT_CHECK_ID = @INSP_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_INVOICE
(
	@COMP_ID NUMERIC(18),
	@INVOICE_ID INT,
	@DATEOFISSUE SMALLDATETIME,
	@DESCRIPTION VARCHAR(4000),
	@OVERDUEAFTER_ID INT,
	@AMOUNT VARCHAR(10),
	@VAT VARCHAR(10),
	@RECORD_MANAGER INT,
	@PAID SMALLDATETIME,
	@CONTACT_ID NUMERIC(18)
) AS


DECLARE @ID INT

IF @INVOICE_ID <> 0
BEGIN
	UPDATE
		INVOICES
	SET
		DATEOFISSUE = @DATEOFISSUE,
		DESCRIPTION = @DESCRIPTION,
		CONTACT_ID = @CONTACT_ID,
		AMOUNT = @AMOUNT,
		VAT = @VAT,
		OVERDUEAFTER_ID = @OVERDUEAFTER_ID,
		RECORD_MANAGER=@RECORD_MANAGER
	WHERE
		INVOICEID = @INVOICE_ID

	UPDATE
		COMPANY_INVOICES
	SET
		PAID = @PAID
	WHERE
		INVOICEID = @INVOICE_ID

	SELECT @ID = @INVOICE_ID
END
ELSE
BEGIN
	INSERT INTO
		INVOICES
	SELECT
		@DESCRIPTION,
		@DATEOFISSUE,
		@CONTACT_ID,
		@OVERDUEAFTER_ID,
		@AMOUNT,
		@VAT,
		NULL,
		NULL,
		NULL,
		@RECORD_MANAGER

	SELECT @ID = @@IDENTITY

	INSERT INTO
		COMPANY_INVOICES
	SELECT
		@COMP_ID,
		@ID,
		@PAID
END

SELECT @ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE UPDATE_MERGE_DOC
(
	@DOC_ID INT,
	@DOC_LIST_NAME VARCHAR(250),
	@TYPE INT,
	@DESC VARCHAR(1000),
	@RECORD_MODIFIER INT
) AS

UPDATE
	MERGE_DOCUMENTS
SET
	DOC_LIST_NAME = @DOC_LIST_NAME,
	DOC_TYPE = @TYPE,
	DESCRIPTION = @DESC,
	RECORD_MANAGER = @RECORD_MODIFIER,
	DATE_ENTERED = GETDATE()
WHERE
	DOC_ID = @DOC_ID
	







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO








CREATE PROCEDURE UPDATE_MERGE_DOC_DOC 
(
	@FILENAME VARCHAR(250),
	@DOC_ID INT,
	@DOC IMAGE,
	@SIZE NUMERIC(18),
	@RECORD_MODIFIER INT
) AS

UPDATE
	MERGE_DOCUMENTS
SET
	DOC_NAME = @FILENAME,
	DOCUMENT = @DOC,
	FILESIZE = @SIZE,
	RECORD_MANAGER = @RECORD_MODIFIER,
	DATE_ENTERED = GETDATE()
WHERE
	DOC_ID = @DOC_ID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_METER
(	@PROP_ID INT,
	@MET_ID INT,
	@MET_TYPE INT,
	@LOC VARCHAR(250),
	@MET_SN VARCHAR(50),
	@STARTDATE SMALLDATETIME,
	@FINISHDATE SMALLDATETIME,
	@SUPP_ID INT,
	@NOTES VARCHAR(4000),
	@RECORD_MODIFIER INT,
	@INUSE BIT
)AS

DECLARE @CNT INT
DECLARE @ID INT

SELECT
	@CNT = COUNT(*) FROM METERS WHERE METER_ID = @MET_ID

IF @CNT >= 1
BEGIN
	UPDATE
		METERS
	SET
		METERTYPE = @MET_TYPE,
		SERIALNUMBER = @MET_SN,
		LOCATION = @LOC,
		SUPP_ID = @SUPP_ID,
		NOTES = @NOTES,
		MODIFIED_BY = @RECORD_MODIFIER,
		DATE_MODIFIED=GETDATE(),
		IN_USE = @INUSE,
		START_DATE = @STARTDATE,
		END_DATE = @FINISHDATE
	WHERE
		METER_ID = @MET_ID

END
ELSE
BEGIN
	INSERT INTO METERS (METERTYPE,
					SERIALNUMBER,
					LOCATION ,
					SUPP_ID,
					NOTES,
					START_DATE,
					END_DATE,
					MODIFIED_BY )
	VALUES
		(@MET_TYPE,
		@MET_SN,
		@LOC,
		@SUPP_ID,
		@NOTES,
		@STARTDATE,
		@FINISHDATE,
		@RECORD_MODIFIER)

	SELECT @ID = @@IDENTITY

	INSERT INTO 
		OBJECT_METER
	SELECT
		@ID,
		@PROP_ID
	
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_METERREADING
(	
	@READ_ID INT,
	@MET_ID INT,
	@RATE_ID INT,
	@READDATE VARCHAR(20),
	@READING VARCHAR(50),
	@INSP INT,
	@INSP_ID INT
)AS

DECLARE @CNT INT
DECLARE @RDG VARCHAR(50)
DECLARE @ID INT



IF @READ_ID > 0
BEGIN
	UPDATE
		METER_READINGS
	SET
		DATED = CONVERT(SMALLDATETIME,@READDATE,103),
		READING = @READING,
		OPERATOR = @INSP
	WHERE
		READING_ID = @READ_ID

END
ELSE
BEGIN
	INSERT INTO METER_READINGS (METER_ID, RATE_ID, DATED, OPERATOR, READING, OBJECT_CHECK_ID)
	SELECT
		@MET_ID,
		@RATE_ID,
		CONVERT(SMALLDATETIME,@READDATE,103),
		@INSP,
		@READING,
		@INSP_ID
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_METER_READINGS
(	
	@MET_ID INT,
	@DATE SMALLDATETIME,
	@READ VARCHAR(50),
	@INDEX INT,
	@INSP_ID INT
)AS

DECLARE @CNT INT
DECLARE @RCNT INT
DECLARE @CHECK_ID INT
DECLARE @RATE INT

SELECT @CNT = 1
DECLARE RATES CURSOR FOR
	SELECT RATE_ID FROM METER_RATES WHERE METER_ID = @MET_ID ORDER BY RATE_ID

OPEN RATES

FETCH NEXT FROM RATES INTO @RATE

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @CNT = @INDEX
	BEGIN
		SELECT @RCNT = 0
		SELECT @RCNT = READING_ID FROM METER_READINGS WHERE METER_ID = @MET_ID AND DATED = @DATE AND RATE_ID = @RATE

		IF @RCNT <> 0
		BEGIN
			UPDATE METER_READINGS SET READING = @READ, OPERATOR=@INSP_ID WHERE READING_ID = @RCNT
		END
		ELSE
		BEGIN
			INSERT INTO METER_READINGS (METER_ID, DATED, OPERATOR, READING,RATE_ID)
				SELECT @MET_ID, @DATE,@INSP_ID, @READ,@RATE
		END
	END
	SELECT @CNT = @CNT + 1 	
	FETCH NEXT FROM RATES INTO @RATE
END

CLOSE RATES
DEALLOCATE RATES








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO











CREATE PROCEDURE UPDATE_PROPERTY
(
	@PROP_ID INT,
	@KEY_NUMBER VARCHAR(20),
	@PROPERTY_ID VARCHAR(50),
	@OBJECT_NAME VARCHAR(200),
	@HOUSENAME VARCHAR(50),
	@STREETNAME VARCHAR(50),
	@ADDRESS4 VARCHAR(50),
	@CITY VARCHAR(50),
	@COUNTY VARCHAR(50),
	@POSTALCODE VARCHAR(50),
	@COUNTRY VARCHAR(50),
	@AREA_ID INT,
	@REGION_MANAGER INT,
	@MAX_NR_RESIDENTS INT,
	@STATUS_ID INT,
	@OBJECT_TYPE INT,
	@STAT_EFF SMALLDATETIME,
	@DATE_STOPPED SMALLDATETIME,
	@DATE_STARTED SMALLDATETIME,
	@ACCOUNT_MANAGER INT,
	@PROPERTY_MANAGER INT,
	@PROPERTY_INSPECTOR INT,
	@GUARDIAN_MANAGER INT,
	@RECORD_MODIFIER INT,
	@M_FEE VARCHAR(50),
	@L_FEE VARCHAR(50),
	@CALAM_LIMIT VARCHAR(50)
)AS

DECLARE @STAT INT
DECLARE @DTFROM SMALLDATETIME
DECLARE @OSTAT  INT

SELECT 
	@STAT = STATUS_ID
FROM
	OBJECTS
WHERE
	OBJECT_ID = @PROP_ID

SELECT
	@DTFROM = DATE_FROM
FROM
	OBJECT_STATUS_HISTORY
WHERE
	OBJECT_ID = @PROP_ID
AND	STATUS_ID = @STAT

SELECT
	@OSTAT = STATUS_ID
FROM
	OBJECT_STATUS_HISTORY
WHERE
	OBJECT_ID = @PROP_ID
AND	DATE_TO = @DTFROM


UPDATE 
	OBJECTS
SET
	OBJECT_NAME = @OBJECT_NAME,
	KEY_NUMBER = @KEY_NUMBER,
	PROPERTY_ID = @PROPERTY_ID,
	HOUSENAME = @HOUSENAME,
	STREETNAME = @STREETNAME,
	ADDRESS4 = @ADDRESS4,
	CITY = @CITY,
	COUNTY = @COUNTY,
	POSTALCODE = @POSTALCODE,
	COUNTRY = @COUNTRY,
	AREA_ID = @AREA_ID,
	REGION_MANAGER = @REGION_MANAGER,
	MAX_NR_RESIDENTS = @MAX_NR_RESIDENTS,
	STATUS_ID = @STATUS_ID,
	OBJECT_TYPE = @OBJECT_TYPE,
	MONTHLY_FEE = CONVERT(MONEY,@M_FEE),
	LIC_FEE = CONVERT(MONEY,@L_FEE),
	CALAM_LIMIT = CONVERT(MONEY,@CALAM_LIMIT),
	STAT_EFF = @STAT_EFF,
	DATE_STOPPED = @DATE_STOPPED,
	DATE_STARTED = @DATE_STARTED,
	ACCOUNT_MANAGER = @ACCOUNT_MANAGER,
	PROPERTY_MANAGER = @PROPERTY_MANAGER,
	PROPERTY_INSPECTOR = @PROPERTY_INSPECTOR,
	GUARDIAN_MANAGER = @GUARDIAN_MANAGER,
	RECORD_MODIFIER = @RECORD_MODIFIER,
	DATE_MODIFIED = getdate()
WHERE
	OBJECT_ID = @PROP_ID


IF @STAT <> @STATUS_ID
BEGIN
	UPDATE
		OBJECT_STATUS_HISTORY
	SET
		DATE_TO = @STAT_EFF
	WHERE
		OBJECT_ID = @PROP_ID
	AND	STATUS_ID = @STAT
	AND	DATE_TO = NULL
	
	INSERT INTO
		OBJECT_STATUS_HISTORY
	SELECT
		@PROP_ID,
		@STATUS_ID,
		@STAT_EFF,
		NULL
END


IF @DTFROM <> @STAT_EFF
BEGIN
	UPDATE
		OBJECT_STATUS_HISTORY
	SET
		DATE_TO = @STAT_EFF
	WHERE
		OBJECT_ID = @PROP_ID
	AND	STATUS_ID = @OSTAT

	UPDATE
		OBJECT_STATUS_HISTORY
	SET
		DATE_FROM = @STAT_EFF
	WHERE
		OBJECT_ID = @PROP_ID
	AND	STATUS_ID = @STATUS_ID
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_PROPERTY_NOTE
(
	@COMP_ID NUMERIC(18),
	@PROP_ID NUMERIC(18),
	@NOTE_ID NUMERIC(18),
	@DESC VARCHAR(8000),
	@DATE SMALLDATETIME,
	@INOUTLOOK BIT,
	@INSP BIT,
	@RECORD_MANAGER INT
) AS

IF @NOTE_ID <> 0
BEGIN
	UPDATE
		NOTES
	SET
		ACTIVITY_DATE = @DATE,
		REGARDING = @DESC,
		SAVED_IN_OUTLOOK = @INOUTLOOK,
		IN_INSP = @INSP,
		RECORD_MANAGER = @RECORD_MANAGER,
		DATE_ENTERED = GETDATE()
	WHERE
		ACTIVITY_ID = @NOTE_ID
END
ELSE
BEGIN
	INSERT INTO
		NOTES
	SELECT
		@COMP_ID,
		@PROP_ID,
		NULL,
		NULL,
		@DATE,
		@DESC,
		@INOUTLOOK,
		@RECORD_MANAGER,
		GETDATE(),
		IN_INSP = @INSP
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_ROUTE 
(
	@ROUTE_ID INT,
	@NAME VARCHAR(25),
	@ACTIVE INT
)AS

UPDATE
	ROUTES
SET
	NAME = @NAME,
	ACTIVE = @ACTIVE
WHERE
	ROUTEID = @ROUTE_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_ROUTE_DATE
(
	@ROUTE_ID INT,
	@DATE VARCHAR(20)
) AS


INSERT INTO
	ROUTE_INSPECTIONS
SELECT
	@ROUTE_ID,
	CONVERT(SMALLDATETIME,@DATE, 103)








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE UPDATE_SECURITY
(
	@PROP_ID INT,
	@SEC_ID INT,
	@SEC_TYPE INT,
	@SEC_DESC VARCHAR(250),
	@SEC_LOC VARCHAR(250),
	@SEC_SN VARCHAR(50),
	@INSDATE VARCHAR(250),
	@REMDATE VARCHAR(250),
	@LASTCHECK VARCHAR(250),
	@NEXTCHECK VARCHAR(250),
	@MAINT_ID INT,
	@NOTES VARCHAR(4000),
	@RES_ID INT,
	@RECORD_MANAGER INT,
	@INUSE BIT,
	@CODE VARCHAR(50),
	@EM_CONT VARCHAR(250),
	@CONT_NO VARCHAR(50)
)AS

DECLARE @CNT INT

SELECT
	@CNT = COUNT(*) FROM SECURITIES WHERE SECURITY_ID = @SEC_ID

IF @CNT = 1
BEGIN
	UPDATE
		SECURITIES
	SET
		SECURITY_TYPE = @SEC_TYPE,
		SERIAL_NUMBER = @SEC_SN,
		DESCRIPTION = @SEC_DESC,
		LOCATION = @SEC_LOC,
		DATE_INSTALLED = CONVERT(SMALLDATETIME,@INSDATE,103),
		DATE_REMOVED = CONVERT(SMALLDATETIME,@REMDATE,103),
		DATE_LAST_CHECK = CONVERT(SMALLDATETIME,@LASTCHECK,103),
		DATE_NEXT_CHECK = CONVERT(SMALLDATETIME,@NEXTCHECK,103),
		MAINT_ID = @MAINT_ID,
		REMARKS = @NOTES,
		RESIDENT_ID = @RES_ID,
		RECORD_MANAGER = @RECORD_MANAGER,
		DATE_MODIFIED=GETDATE(),
		IN_USE = @INUSE,
		CODE = @CODE,
		EM_CONT = @EM_CONT,
		CONT_NO = @CONT_NO
	WHERE
		SECURITY_ID = @SEC_ID
END
ELSE
BEGIN
	INSERT INTO SECURITIES (SECURITY_TYPE,
					SERIAL_NUMBER,
					DESCRIPTION ,
					LOCATION,
					DATE_INSTALLED,
					DATE_REMOVED,
					DATE_LAST_CHECK,
					DATE_NEXT_CHECK,
					MAINT_ID,
					REMARKS,
					RESIDENT_ID,
					RECORD_MANAGER,
					DATE_MODIFIED,
					CODE,
					EM_CONT,
					CONT_NO)
	VALUES
		(@SEC_TYPE,
		@SEC_SN,
		@SEC_DESC,
		@SEC_LOC,
		@INSDATE,
		@REMDATE,
		@LASTCHECK,
		@NEXTCHECK,
		@MAINT_ID,
		@NOTES,
		@RES_ID,
		@RECORD_MANAGER,
		GETDATE(),
		@CODE,
		@EM_CONT,
		@CONT_NO)

	INSERT INTO 
		OBJECT_SECURITIES
	SELECT
		@PROP_ID,
		@@IDENTITY
	
END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE UPDATE_VETTING
(
	@GUARD INT,
	@PHOTO INT = 0,
	@APP INT = 0,
	@LIC INT = 0,
	@BANK INT = 0,
	@REF INT = 0,
	@BOOK INT = 0,
	@STAND INT = 0,
	@EXEC_DES INT = 0,
	@NOTES VARCHAR(4000),
	@INOUT INT = 0,
	@OUTDATE SMALLDATETIME
)
 AS

UPDATE
	RESIDENTS
SET
	PHOTO_ID = @PHOTO,
	APPLIC_FORM = @APP,
	LICENSE = @LIC,
	BANK_UTIL = @BANK,
	REF = @REF,
	BOOKLET = @BOOK,
	STAND = @STAND,
	EXEC_DES = @EXEC_DES,
	VNOTES = @NOTES,
	INOUT = @INOUT,	
	OUT_DATE = @OUTDATE
WHERE
	RESIDENT_ID = @GUARD







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE VALID_CONT_EMAIL
(
	@EMAIL VARCHAR(250)
) AS

SELECT
	CO.CONTACT_ID,
	ISNULL(CO.FIRSTNAME,'') + ' ' + ISNULL(CO.LASTNAME,'') AS NAME,
	C.COMPANY_ID,
	C.COMPANY_NAME
FROM 
	CONTACTS CO,
	COMPANY_CONTACT CC,
	COMPANIES C	
WHERE 
	(CO.EMAIL = @EMAIL
OR	CO.PRIVATE_EMAIL = @EMAIL
OR	CO.DIRECT_EMAIL = @EMAIL)
AND	CO.CONTACT_ID = CC.CONTACT_ID
AND	CC.COMPANY_ID = C.COMPANY_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO









CREATE PROCEDURE VALID_GUARD_EMAIL
(
	@EMAIL VARCHAR(250)
) AS

SELECT
	R.RESIDENT_ID,
	ISNULL(R.FIRSTNAME,'') + ' ' + ISNULL(R.LASTNAME,'') AS NAME,
	O.OBJECT_NAME AS PROPERTY,
	O.OBJECT_ID AS PROP_ID
FROM 
	RESIDENTS  R,
	RESIDENT_OBJECT RO,
	OBJECTS O
WHERE 
	(R.EMAIL = @EMAIL
OR	R.PRIVATE_EMAIL = @EMAIL
OR	R.PARENT_EMAIL = @EMAIL)
AND	R.RESIDENT_ID = RO.RESIDENT_ID
AND	RO.OBJECT_ID = O.OBJECT_ID








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE WLSP_CreateCheckListRoute
as
begin 
set nocount on 
truncate table dbo.ISS_CheckList
insert into dbo.ISS_CheckList ( OBJECT_ID,Description) select OBJECT_ID, ltrim(OBJECT_NAME) from dbo.OBJECTS 
select * from dbo.ISS_CheckList order by description
end 










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE PROCEDURE WLSP_CreateNewTable
@SQL varchar(4000)
AS
begin
set nocount on
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FILTERTABEL_INSCHRIJVINGEN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FILTERTABEL_INSCHRIJVINGEN]
exec ( @SQL) 
GRANT ALL ON FILTERTABEL_INSCHRIJVINGEN TO CAMELOT_USERS
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE PROCEDURE WLSP_DropTheTable
AS
begin
set nocount on
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FILTERTABEL_INSCHRIJVINGEN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FILTERTABEL_INSCHRIJVINGEN]
--CREATE TABLE [dbo].[FILTERTABEL_INSCHRIJVINGEN] (
--	[id] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
--) ON [PRIMARY]
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO










CREATE PROCEDURE WLSP_LastMonthsComments 
@Object_ID int 
as
begin 
SELECT TOP 1 OBJECT_ID, DATE_CHECK, ISNULL(Remarks, 
    'None Reported') AS LastOverAll, ISNULL(Damages, 
    'None Reported') AS LastDamages, ISNULL(Repairs, 
    'No Repairs') AS LastRepairs, ISNULL(NextClientAction, 
    'No Action by Client') AS LastClientAction, 
    ISNULL(NextCamelotAction, 'No Action Specified') 
    AS LastCamelotAction
FROM dbo.OBJECT_CHECKS
WHERE (DATE_CHECK IS NOT NULL) AND 
    OBject_ID = @OBject_ID
ORDER BY DATE_CHECK DESC
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE PROCEDURE WLSP_MonthlyPropertyManagementReport
AS
begin
set nocount on
declare @ObjectID int , @Inspected datetime , @OverAllImpressions varchar(1500) ,@Damages varchar(4000) , @NextCamelotAction varchar(1500) , @NextClientAction varchar(1500),@CamelotAction varchar(1500) , @ClientAction varchar(1500) , @Repairs varchar(1500) 
--Truncate Table  dbo.MonthlyHolding
delete from  dbo.MonthlyHolding
insert into MonthlyHolding( OBject_ID , Date_Entered,Client,CompanyName,FullAddress, PostalCode,City) 
SELECT DISTINCT O.OBJECT_ID, O.DATE_ENTERED, O.OBJECT_NAME , 
(select Top 1 CN.Company_Name from dbo.Companies CN left join dbo.Company_Object CO on  CN.Company_ID = Co.Company_ID where Co.Object_ID = O.Object_ID and CN.Company_Name is not null order by Co.DATE_FROM desc) ,
CASE WHEN O.STREETNAME IS NULL THEN '' ELSE O.STREETNAME + ' ' END + CASE WHEN HOUSENUMBER IS NULL 
                      THEN '' ELSE O.HOUSENUMBER END, POSTALCode,City 
from OBJECTS O with (nolock)  order by Object_ID
DECLARE DD_cursor CURSOR Local For 
select  OBJECT_ID 
FROM MonthlyHolding 
OPEN DD_cursor
FETCH NEXT FROM DD_cursor 
            INTO  @ObjectID
            if (@@FETCH_STATUS = 0)  
            begin
                 while (@@FETCH_STATUS = 0)   
                   begin   
                        select Top 1 @Inspected = DATE_CHECK , @Damages = Damages , @Repairs = Repairs , @CamelotAction =CamelotAction , @ClientAction= ClientAction,@NextCamelotAction =NextCamelotAction , @NextClientAction= NextClientAction , @OverAllImpressions = Remarks  from OBJECT_CHECKS with (nolock) where OBject_ID = @ObjectID  order by Date_Check  desc
                        if @Inspected is not Null  update MonthlyHolding  SET DateReported = convert(varchar(12) , @Inspected, 113) ,Repairs = IsNull(@Repairs,'None'), Remarks=@OverAllImpressions,Damages = IsNull(@Damages,'None' ), NextCamelotAction = IsNull(@NextCamelotAction,'None'),CamelotAction = IsNull(@CamelotAction,'None'), ClientAction = IsNull(@ClientAction,'None') , NextClientAction = IsNull(@NextClientAction,'None') where Current of DD_cursor
                     FETCH NEXT FROM DD_cursor 
	        INTO  @ObjectID 
                 end
            end
  CLOSE DD_Cursor
DEALLOCATE DD_Cursor
update MonthlyHolding set Client = CompanyName where CompanyName is not null
select  *  from  MonthlyHolding
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

