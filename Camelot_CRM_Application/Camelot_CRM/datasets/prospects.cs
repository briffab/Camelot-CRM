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
    public class prospects : DataSet {
        
        private prospects_statsDataTable tableprospects_stats;
        
        public prospects() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected prospects(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["prospects_stats"] != null)) {
                    this.Tables.Add(new prospects_statsDataTable(ds.Tables["prospects_stats"]));
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
        public prospects_statsDataTable prospects_stats {
            get {
                return this.tableprospects_stats;
            }
        }
        
        public override DataSet Clone() {
            prospects cln = ((prospects)(base.Clone()));
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
            if ((ds.Tables["prospects_stats"] != null)) {
                this.Tables.Add(new prospects_statsDataTable(ds.Tables["prospects_stats"]));
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
            this.tableprospects_stats = ((prospects_statsDataTable)(this.Tables["prospects_stats"]));
            if ((this.tableprospects_stats != null)) {
                this.tableprospects_stats.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "prospects";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/prospects.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableprospects_stats = new prospects_statsDataTable();
            this.Tables.Add(this.tableprospects_stats);
        }
        
        private bool ShouldSerializeprospects_stats() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void prospects_statsRowChangeEventHandler(object sender, prospects_statsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class prospects_statsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnA;
            
            private DataColumn columnB;
            
            private DataColumn columnC;
            
            private DataColumn columnD;
            
            private DataColumn columnE;
            
            private DataColumn columnF;
            
            private DataColumn columnG;
            
            private DataColumn columnH;
            
            internal prospects_statsDataTable() : 
                    base("prospects_stats") {
                this.InitClass();
            }
            
            internal prospects_statsDataTable(DataTable table) : 
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
            
            internal DataColumn HColumn {
                get {
                    return this.columnH;
                }
            }
            
            public prospects_statsRow this[int index] {
                get {
                    return ((prospects_statsRow)(this.Rows[index]));
                }
            }
            
            public event prospects_statsRowChangeEventHandler prospects_statsRowChanged;
            
            public event prospects_statsRowChangeEventHandler prospects_statsRowChanging;
            
            public event prospects_statsRowChangeEventHandler prospects_statsRowDeleted;
            
            public event prospects_statsRowChangeEventHandler prospects_statsRowDeleting;
            
            public void Addprospects_statsRow(prospects_statsRow row) {
                this.Rows.Add(row);
            }
            
            public prospects_statsRow Addprospects_statsRow(string A, string B, string C, string D, string E, string F, string G, string H) {
                prospects_statsRow rowprospects_statsRow = ((prospects_statsRow)(this.NewRow()));
                rowprospects_statsRow.ItemArray = new object[] {
                        A,
                        B,
                        C,
                        D,
                        E,
                        F,
                        G,
                        H};
                this.Rows.Add(rowprospects_statsRow);
                return rowprospects_statsRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                prospects_statsDataTable cln = ((prospects_statsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new prospects_statsDataTable();
            }
            
            internal void InitVars() {
                this.columnA = this.Columns["A"];
                this.columnB = this.Columns["B"];
                this.columnC = this.Columns["C"];
                this.columnD = this.Columns["D"];
                this.columnE = this.Columns["E"];
                this.columnF = this.Columns["F"];
                this.columnG = this.Columns["G"];
                this.columnH = this.Columns["H"];
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
                this.columnH = new DataColumn("H", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnH);
            }
            
            public prospects_statsRow Newprospects_statsRow() {
                return ((prospects_statsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new prospects_statsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(prospects_statsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.prospects_statsRowChanged != null)) {
                    this.prospects_statsRowChanged(this, new prospects_statsRowChangeEvent(((prospects_statsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.prospects_statsRowChanging != null)) {
                    this.prospects_statsRowChanging(this, new prospects_statsRowChangeEvent(((prospects_statsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.prospects_statsRowDeleted != null)) {
                    this.prospects_statsRowDeleted(this, new prospects_statsRowChangeEvent(((prospects_statsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.prospects_statsRowDeleting != null)) {
                    this.prospects_statsRowDeleting(this, new prospects_statsRowChangeEvent(((prospects_statsRow)(e.Row)), e.Action));
                }
            }
            
            public void Removeprospects_statsRow(prospects_statsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class prospects_statsRow : DataRow {
            
            private prospects_statsDataTable tableprospects_stats;
            
            internal prospects_statsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableprospects_stats = ((prospects_statsDataTable)(this.Table));
            }
            
            public string A {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.AColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.AColumn] = value;
                }
            }
            
            public string B {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.BColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.BColumn] = value;
                }
            }
            
            public string C {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.CColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.CColumn] = value;
                }
            }
            
            public string D {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.DColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.DColumn] = value;
                }
            }
            
            public string E {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.EColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.EColumn] = value;
                }
            }
            
            public string F {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.FColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.FColumn] = value;
                }
            }
            
            public string G {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.GColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.GColumn] = value;
                }
            }
            
            public string H {
                get {
                    try {
                        return ((string)(this[this.tableprospects_stats.HColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableprospects_stats.HColumn] = value;
                }
            }
            
            public bool IsANull() {
                return this.IsNull(this.tableprospects_stats.AColumn);
            }
            
            public void SetANull() {
                this[this.tableprospects_stats.AColumn] = System.Convert.DBNull;
            }
            
            public bool IsBNull() {
                return this.IsNull(this.tableprospects_stats.BColumn);
            }
            
            public void SetBNull() {
                this[this.tableprospects_stats.BColumn] = System.Convert.DBNull;
            }
            
            public bool IsCNull() {
                return this.IsNull(this.tableprospects_stats.CColumn);
            }
            
            public void SetCNull() {
                this[this.tableprospects_stats.CColumn] = System.Convert.DBNull;
            }
            
            public bool IsDNull() {
                return this.IsNull(this.tableprospects_stats.DColumn);
            }
            
            public void SetDNull() {
                this[this.tableprospects_stats.DColumn] = System.Convert.DBNull;
            }
            
            public bool IsENull() {
                return this.IsNull(this.tableprospects_stats.EColumn);
            }
            
            public void SetENull() {
                this[this.tableprospects_stats.EColumn] = System.Convert.DBNull;
            }
            
            public bool IsFNull() {
                return this.IsNull(this.tableprospects_stats.FColumn);
            }
            
            public void SetFNull() {
                this[this.tableprospects_stats.FColumn] = System.Convert.DBNull;
            }
            
            public bool IsGNull() {
                return this.IsNull(this.tableprospects_stats.GColumn);
            }
            
            public void SetGNull() {
                this[this.tableprospects_stats.GColumn] = System.Convert.DBNull;
            }
            
            public bool IsHNull() {
                return this.IsNull(this.tableprospects_stats.HColumn);
            }
            
            public void SetHNull() {
                this[this.tableprospects_stats.HColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class prospects_statsRowChangeEvent : EventArgs {
            
            private prospects_statsRow eventRow;
            
            private DataRowAction eventAction;
            
            public prospects_statsRowChangeEvent(prospects_statsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public prospects_statsRow Row {
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
