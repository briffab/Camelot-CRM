﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Camelot.datasets {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class props_by_status : DataSet {
        
        private propertiesDataTable tableproperties;
        
        public props_by_status() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected props_by_status(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["properties"] != null)) {
                    this.Tables.Add(new propertiesDataTable(ds.Tables["properties"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public propertiesDataTable properties {
            get {
                return this.tableproperties;
            }
        }
        
        public override DataSet Clone() {
            props_by_status cln = ((props_by_status)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["properties"] != null)) {
                this.Tables.Add(new propertiesDataTable(ds.Tables["properties"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableproperties = ((propertiesDataTable)(this.Tables["properties"]));
            if ((this.tableproperties != null)) {
                this.tableproperties.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "props_by_status";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/props_by_status.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableproperties = new propertiesDataTable();
            this.Tables.Add(this.tableproperties);
        }
        
        private bool ShouldSerializeproperties() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void propertiesRowChangeEventHandler(object sender, propertiesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propertiesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnobject_name;
            
            private DataColumn columnhousename;
            
            private DataColumn columnhousenumber;
            
            private DataColumn columnstreet;
            
            private DataColumn columnaddress4;
            
            private DataColumn columncity;
            
            private DataColumn columnpostalcode;
            
            private DataColumn columnacman;
            
            private DataColumn columnmax_nr_residents;
            
            private DataColumn columncompany_name;
            
            private DataColumn columnstatus_description;
            
            private DataColumn columnoccup;
            
            internal propertiesDataTable() : 
                    base("properties") {
                this.InitClass();
            }
            
            internal propertiesDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn object_nameColumn {
                get {
                    return this.columnobject_name;
                }
            }
            
            internal DataColumn housenameColumn {
                get {
                    return this.columnhousename;
                }
            }
            
            internal DataColumn housenumberColumn {
                get {
                    return this.columnhousenumber;
                }
            }
            
            internal DataColumn streetColumn {
                get {
                    return this.columnstreet;
                }
            }
            
            internal DataColumn address4Column {
                get {
                    return this.columnaddress4;
                }
            }
            
            internal DataColumn cityColumn {
                get {
                    return this.columncity;
                }
            }
            
            internal DataColumn postalcodeColumn {
                get {
                    return this.columnpostalcode;
                }
            }
            
            internal DataColumn acmanColumn {
                get {
                    return this.columnacman;
                }
            }
            
            internal DataColumn max_nr_residentsColumn {
                get {
                    return this.columnmax_nr_residents;
                }
            }
            
            internal DataColumn company_nameColumn {
                get {
                    return this.columncompany_name;
                }
            }
            
            internal DataColumn status_descriptionColumn {
                get {
                    return this.columnstatus_description;
                }
            }
            
            internal DataColumn occupColumn {
                get {
                    return this.columnoccup;
                }
            }
            
            public propertiesRow this[int index] {
                get {
                    return ((propertiesRow)(this.Rows[index]));
                }
            }
            
            public event propertiesRowChangeEventHandler propertiesRowChanged;
            
            public event propertiesRowChangeEventHandler propertiesRowChanging;
            
            public event propertiesRowChangeEventHandler propertiesRowDeleted;
            
            public event propertiesRowChangeEventHandler propertiesRowDeleting;
            
            public void AddpropertiesRow(propertiesRow row) {
                this.Rows.Add(row);
            }
            
            public propertiesRow AddpropertiesRow(string object_name, string housename, string housenumber, string street, string address4, string city, string postalcode, string acman, string max_nr_residents, string company_name, string status_description, string occup) {
                propertiesRow rowpropertiesRow = ((propertiesRow)(this.NewRow()));
                rowpropertiesRow.ItemArray = new object[] {
                        object_name,
                        housename,
                        housenumber,
                        street,
                        address4,
                        city,
                        postalcode,
                        acman,
                        max_nr_residents,
                        company_name,
                        status_description,
                        occup};
                this.Rows.Add(rowpropertiesRow);
                return rowpropertiesRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                propertiesDataTable cln = ((propertiesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new propertiesDataTable();
            }
            
            internal void InitVars() {
                this.columnobject_name = this.Columns["object_name"];
                this.columnhousename = this.Columns["housename"];
                this.columnhousenumber = this.Columns["housenumber"];
                this.columnstreet = this.Columns["street"];
                this.columnaddress4 = this.Columns["address4"];
                this.columncity = this.Columns["city"];
                this.columnpostalcode = this.Columns["postalcode"];
                this.columnacman = this.Columns["acman"];
                this.columnmax_nr_residents = this.Columns["max_nr_residents"];
                this.columncompany_name = this.Columns["company_name"];
                this.columnstatus_description = this.Columns["status_description"];
                this.columnoccup = this.Columns["occup"];
            }
            
            private void InitClass() {
                this.columnobject_name = new DataColumn("object_name", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnobject_name);
                this.columnhousename = new DataColumn("housename", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnhousename);
                this.columnhousenumber = new DataColumn("housenumber", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnhousenumber);
                this.columnstreet = new DataColumn("street", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnstreet);
                this.columnaddress4 = new DataColumn("address4", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnaddress4);
                this.columncity = new DataColumn("city", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncity);
                this.columnpostalcode = new DataColumn("postalcode", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnpostalcode);
                this.columnacman = new DataColumn("acman", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnacman);
                this.columnmax_nr_residents = new DataColumn("max_nr_residents", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnmax_nr_residents);
                this.columncompany_name = new DataColumn("company_name", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncompany_name);
                this.columnstatus_description = new DataColumn("status_description", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnstatus_description);
                this.columnoccup = new DataColumn("occup", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnoccup);
            }
            
            public propertiesRow NewpropertiesRow() {
                return ((propertiesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new propertiesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(propertiesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.propertiesRowChanged != null)) {
                    this.propertiesRowChanged(this, new propertiesRowChangeEvent(((propertiesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.propertiesRowChanging != null)) {
                    this.propertiesRowChanging(this, new propertiesRowChangeEvent(((propertiesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.propertiesRowDeleted != null)) {
                    this.propertiesRowDeleted(this, new propertiesRowChangeEvent(((propertiesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.propertiesRowDeleting != null)) {
                    this.propertiesRowDeleting(this, new propertiesRowChangeEvent(((propertiesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovepropertiesRow(propertiesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propertiesRow : DataRow {
            
            private propertiesDataTable tableproperties;
            
            internal propertiesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableproperties = ((propertiesDataTable)(this.Table));
            }
            
            public string object_name {
                get {
                    try {
                        return ((string)(this[this.tableproperties.object_nameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.object_nameColumn] = value;
                }
            }
            
            public string housename {
                get {
                    try {
                        return ((string)(this[this.tableproperties.housenameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.housenameColumn] = value;
                }
            }
            
            public string housenumber {
                get {
                    try {
                        return ((string)(this[this.tableproperties.housenumberColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.housenumberColumn] = value;
                }
            }
            
            public string street {
                get {
                    try {
                        return ((string)(this[this.tableproperties.streetColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.streetColumn] = value;
                }
            }
            
            public string address4 {
                get {
                    try {
                        return ((string)(this[this.tableproperties.address4Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.address4Column] = value;
                }
            }
            
            public string city {
                get {
                    try {
                        return ((string)(this[this.tableproperties.cityColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.cityColumn] = value;
                }
            }
            
            public string postalcode {
                get {
                    try {
                        return ((string)(this[this.tableproperties.postalcodeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.postalcodeColumn] = value;
                }
            }
            
            public string acman {
                get {
                    try {
                        return ((string)(this[this.tableproperties.acmanColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.acmanColumn] = value;
                }
            }
            
            public string max_nr_residents {
                get {
                    try {
                        return ((string)(this[this.tableproperties.max_nr_residentsColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.max_nr_residentsColumn] = value;
                }
            }
            
            public string company_name {
                get {
                    try {
                        return ((string)(this[this.tableproperties.company_nameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.company_nameColumn] = value;
                }
            }
            
            public string status_description {
                get {
                    try {
                        return ((string)(this[this.tableproperties.status_descriptionColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.status_descriptionColumn] = value;
                }
            }
            
            public string occup {
                get {
                    try {
                        return ((string)(this[this.tableproperties.occupColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableproperties.occupColumn] = value;
                }
            }
            
            public bool Isobject_nameNull() {
                return this.IsNull(this.tableproperties.object_nameColumn);
            }
            
            public void Setobject_nameNull() {
                this[this.tableproperties.object_nameColumn] = System.Convert.DBNull;
            }
            
            public bool IshousenameNull() {
                return this.IsNull(this.tableproperties.housenameColumn);
            }
            
            public void SethousenameNull() {
                this[this.tableproperties.housenameColumn] = System.Convert.DBNull;
            }
            
            public bool IshousenumberNull() {
                return this.IsNull(this.tableproperties.housenumberColumn);
            }
            
            public void SethousenumberNull() {
                this[this.tableproperties.housenumberColumn] = System.Convert.DBNull;
            }
            
            public bool IsstreetNull() {
                return this.IsNull(this.tableproperties.streetColumn);
            }
            
            public void SetstreetNull() {
                this[this.tableproperties.streetColumn] = System.Convert.DBNull;
            }
            
            public bool Isaddress4Null() {
                return this.IsNull(this.tableproperties.address4Column);
            }
            
            public void Setaddress4Null() {
                this[this.tableproperties.address4Column] = System.Convert.DBNull;
            }
            
            public bool IscityNull() {
                return this.IsNull(this.tableproperties.cityColumn);
            }
            
            public void SetcityNull() {
                this[this.tableproperties.cityColumn] = System.Convert.DBNull;
            }
            
            public bool IspostalcodeNull() {
                return this.IsNull(this.tableproperties.postalcodeColumn);
            }
            
            public void SetpostalcodeNull() {
                this[this.tableproperties.postalcodeColumn] = System.Convert.DBNull;
            }
            
            public bool IsacmanNull() {
                return this.IsNull(this.tableproperties.acmanColumn);
            }
            
            public void SetacmanNull() {
                this[this.tableproperties.acmanColumn] = System.Convert.DBNull;
            }
            
            public bool Ismax_nr_residentsNull() {
                return this.IsNull(this.tableproperties.max_nr_residentsColumn);
            }
            
            public void Setmax_nr_residentsNull() {
                this[this.tableproperties.max_nr_residentsColumn] = System.Convert.DBNull;
            }
            
            public bool Iscompany_nameNull() {
                return this.IsNull(this.tableproperties.company_nameColumn);
            }
            
            public void Setcompany_nameNull() {
                this[this.tableproperties.company_nameColumn] = System.Convert.DBNull;
            }
            
            public bool Isstatus_descriptionNull() {
                return this.IsNull(this.tableproperties.status_descriptionColumn);
            }
            
            public void Setstatus_descriptionNull() {
                this[this.tableproperties.status_descriptionColumn] = System.Convert.DBNull;
            }
            
            public bool IsoccupNull() {
                return this.IsNull(this.tableproperties.occupColumn);
            }
            
            public void SetoccupNull() {
                this[this.tableproperties.occupColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propertiesRowChangeEvent : EventArgs {
            
            private propertiesRow eventRow;
            
            private DataRowAction eventAction;
            
            public propertiesRowChangeEvent(propertiesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public propertiesRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
