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
    public class insp_prop : DataSet {
        
        private propDataTable tableprop;
        
        public insp_prop() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected insp_prop(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["prop"] != null)) {
                    this.Tables.Add(new propDataTable(ds.Tables["prop"]));
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
        public propDataTable prop {
            get {
                return this.tableprop;
            }
        }
        
        public override DataSet Clone() {
            insp_prop cln = ((insp_prop)(base.Clone()));
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
            if ((ds.Tables["prop"] != null)) {
                this.Tables.Add(new propDataTable(ds.Tables["prop"]));
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
            this.tableprop = ((propDataTable)(this.Tables["prop"]));
            if ((this.tableprop != null)) {
                this.tableprop.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "insp_prop";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/insp_prop.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableprop = new propDataTable();
            this.Tables.Add(this.tableprop);
        }
        
        private bool ShouldSerializeprop() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void propRowChangeEventHandler(object sender, propRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnprop;
            
            internal propDataTable() : 
                    base("prop") {
                this.InitClass();
            }
            
            internal propDataTable(DataTable table) : 
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
            
            internal DataColumn propColumn {
                get {
                    return this.columnprop;
                }
            }
            
            public propRow this[int index] {
                get {
                    return ((propRow)(this.Rows[index]));
                }
            }
            
            public event propRowChangeEventHandler propRowChanged;
            
            public event propRowChangeEventHandler propRowChanging;
            
            public event propRowChangeEventHandler propRowDeleted;
            
            public event propRowChangeEventHandler propRowDeleting;
            
            public void AddpropRow(propRow row) {
                this.Rows.Add(row);
            }
            
            public propRow AddpropRow(string prop) {
                propRow rowpropRow = ((propRow)(this.NewRow()));
                rowpropRow.ItemArray = new object[] {
                        prop};
                this.Rows.Add(rowpropRow);
                return rowpropRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                propDataTable cln = ((propDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new propDataTable();
            }
            
            internal void InitVars() {
                this.columnprop = this.Columns["prop"];
            }
            
            private void InitClass() {
                this.columnprop = new DataColumn("prop", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnprop);
            }
            
            public propRow NewpropRow() {
                return ((propRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new propRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(propRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.propRowChanged != null)) {
                    this.propRowChanged(this, new propRowChangeEvent(((propRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.propRowChanging != null)) {
                    this.propRowChanging(this, new propRowChangeEvent(((propRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.propRowDeleted != null)) {
                    this.propRowDeleted(this, new propRowChangeEvent(((propRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.propRowDeleting != null)) {
                    this.propRowDeleting(this, new propRowChangeEvent(((propRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovepropRow(propRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propRow : DataRow {
            
            private propDataTable tableprop;
            
            internal propRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableprop = ((propDataTable)(this.Table));
            }
            
            public string prop {
                get {
                    try {
                        return ((string)(this[this.tableprop.propColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprop.propColumn] = value;
                }
            }
            
            public bool IspropNull() {
                return this.IsNull(this.tableprop.propColumn);
            }
            
            public void SetpropNull() {
                this[this.tableprop.propColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class propRowChangeEvent : EventArgs {
            
            private propRow eventRow;
            
            private DataRowAction eventAction;
            
            public propRowChangeEvent(propRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public propRow Row {
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
