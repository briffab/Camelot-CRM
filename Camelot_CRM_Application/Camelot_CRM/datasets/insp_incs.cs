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
    public class insp_incs : DataSet {
        
        private incidentDataTable tableincident;
        
        public insp_incs() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected insp_incs(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["incident"] != null)) {
                    this.Tables.Add(new incidentDataTable(ds.Tables["incident"]));
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
        public incidentDataTable incident {
            get {
                return this.tableincident;
            }
        }
        
        public override DataSet Clone() {
            insp_incs cln = ((insp_incs)(base.Clone()));
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
            if ((ds.Tables["incident"] != null)) {
                this.Tables.Add(new incidentDataTable(ds.Tables["incident"]));
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
            this.tableincident = ((incidentDataTable)(this.Tables["incident"]));
            if ((this.tableincident != null)) {
                this.tableincident.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "insp_incs";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/insp_incs.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableincident = new incidentDataTable();
            this.Tables.Add(this.tableincident);
        }
        
        private bool ShouldSerializeincident() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void incidentRowChangeEventHandler(object sender, incidentRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incidentDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnA;
            
            private DataColumn columnB;
            
            private DataColumn columnC;
            
            private DataColumn columnD;
            
            private DataColumn columnE;
            
            private DataColumn columnF;
            
            private DataColumn columnG;
            
            internal incidentDataTable() : 
                    base("incident") {
                this.InitClass();
            }
            
            internal incidentDataTable(DataTable table) : 
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
            
            internal DataColumn AColumn {
                get {
                    return this.columnA;
                }
            }
            
            internal DataColumn BColumn {
                get {
                    return this.columnB;
                }
            }
            
            internal DataColumn CColumn {
                get {
                    return this.columnC;
                }
            }
            
            internal DataColumn DColumn {
                get {
                    return this.columnD;
                }
            }
            
            internal DataColumn EColumn {
                get {
                    return this.columnE;
                }
            }
            
            internal DataColumn FColumn {
                get {
                    return this.columnF;
                }
            }
            
            internal DataColumn GColumn {
                get {
                    return this.columnG;
                }
            }
            
            public incidentRow this[int index] {
                get {
                    return ((incidentRow)(this.Rows[index]));
                }
            }
            
            public event incidentRowChangeEventHandler incidentRowChanged;
            
            public event incidentRowChangeEventHandler incidentRowChanging;
            
            public event incidentRowChangeEventHandler incidentRowDeleted;
            
            public event incidentRowChangeEventHandler incidentRowDeleting;
            
            public void AddincidentRow(incidentRow row) {
                this.Rows.Add(row);
            }
            
            public incidentRow AddincidentRow(string A, string B, string C, string D, string E, string F, string G) {
                incidentRow rowincidentRow = ((incidentRow)(this.NewRow()));
                rowincidentRow.ItemArray = new object[] {
                        A,
                        B,
                        C,
                        D,
                        E,
                        F,
                        G};
                this.Rows.Add(rowincidentRow);
                return rowincidentRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                incidentDataTable cln = ((incidentDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new incidentDataTable();
            }
            
            internal void InitVars() {
                this.columnA = this.Columns["A"];
                this.columnB = this.Columns["B"];
                this.columnC = this.Columns["C"];
                this.columnD = this.Columns["D"];
                this.columnE = this.Columns["E"];
                this.columnF = this.Columns["F"];
                this.columnG = this.Columns["G"];
            }
            
            private void InitClass() {
                this.columnA = new DataColumn("A", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnA);
                this.columnB = new DataColumn("B", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnB);
                this.columnC = new DataColumn("C", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnC);
                this.columnD = new DataColumn("D", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnD);
                this.columnE = new DataColumn("E", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnE);
                this.columnF = new DataColumn("F", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnF);
                this.columnG = new DataColumn("G", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnG);
            }
            
            public incidentRow NewincidentRow() {
                return ((incidentRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new incidentRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(incidentRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.incidentRowChanged != null)) {
                    this.incidentRowChanged(this, new incidentRowChangeEvent(((incidentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.incidentRowChanging != null)) {
                    this.incidentRowChanging(this, new incidentRowChangeEvent(((incidentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.incidentRowDeleted != null)) {
                    this.incidentRowDeleted(this, new incidentRowChangeEvent(((incidentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.incidentRowDeleting != null)) {
                    this.incidentRowDeleting(this, new incidentRowChangeEvent(((incidentRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveincidentRow(incidentRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incidentRow : DataRow {
            
            private incidentDataTable tableincident;
            
            internal incidentRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableincident = ((incidentDataTable)(this.Table));
            }
            
            public string A {
                get {
                    try {
                        return ((string)(this[this.tableincident.AColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.AColumn] = value;
                }
            }
            
            public string B {
                get {
                    try {
                        return ((string)(this[this.tableincident.BColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.BColumn] = value;
                }
            }
            
            public string C {
                get {
                    try {
                        return ((string)(this[this.tableincident.CColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.CColumn] = value;
                }
            }
            
            public string D {
                get {
                    try {
                        return ((string)(this[this.tableincident.DColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.DColumn] = value;
                }
            }
            
            public string E {
                get {
                    try {
                        return ((string)(this[this.tableincident.EColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.EColumn] = value;
                }
            }
            
            public string F {
                get {
                    try {
                        return ((string)(this[this.tableincident.FColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.FColumn] = value;
                }
            }
            
            public string G {
                get {
                    try {
                        return ((string)(this[this.tableincident.GColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincident.GColumn] = value;
                }
            }
            
            public bool IsANull() {
                return this.IsNull(this.tableincident.AColumn);
            }
            
            public void SetANull() {
                this[this.tableincident.AColumn] = System.Convert.DBNull;
            }
            
            public bool IsBNull() {
                return this.IsNull(this.tableincident.BColumn);
            }
            
            public void SetBNull() {
                this[this.tableincident.BColumn] = System.Convert.DBNull;
            }
            
            public bool IsCNull() {
                return this.IsNull(this.tableincident.CColumn);
            }
            
            public void SetCNull() {
                this[this.tableincident.CColumn] = System.Convert.DBNull;
            }
            
            public bool IsDNull() {
                return this.IsNull(this.tableincident.DColumn);
            }
            
            public void SetDNull() {
                this[this.tableincident.DColumn] = System.Convert.DBNull;
            }
            
            public bool IsENull() {
                return this.IsNull(this.tableincident.EColumn);
            }
            
            public void SetENull() {
                this[this.tableincident.EColumn] = System.Convert.DBNull;
            }
            
            public bool IsFNull() {
                return this.IsNull(this.tableincident.FColumn);
            }
            
            public void SetFNull() {
                this[this.tableincident.FColumn] = System.Convert.DBNull;
            }
            
            public bool IsGNull() {
                return this.IsNull(this.tableincident.GColumn);
            }
            
            public void SetGNull() {
                this[this.tableincident.GColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incidentRowChangeEvent : EventArgs {
            
            private incidentRow eventRow;
            
            private DataRowAction eventAction;
            
            public incidentRowChangeEvent(incidentRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public incidentRow Row {
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
