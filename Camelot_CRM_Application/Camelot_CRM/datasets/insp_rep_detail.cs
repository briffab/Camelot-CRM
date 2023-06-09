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
    public class insp_rep_detail : DataSet {
        
        private DetailDataTable tableDetail;
        
        public insp_rep_detail() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected insp_rep_detail(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Detail"] != null)) {
                    this.Tables.Add(new DetailDataTable(ds.Tables["Detail"]));
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
        public DetailDataTable Detail {
            get {
                return this.tableDetail;
            }
        }
        
        public override DataSet Clone() {
            insp_rep_detail cln = ((insp_rep_detail)(base.Clone()));
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
            if ((ds.Tables["Detail"] != null)) {
                this.Tables.Add(new DetailDataTable(ds.Tables["Detail"]));
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
            this.tableDetail = ((DetailDataTable)(this.Tables["Detail"]));
            if ((this.tableDetail != null)) {
                this.tableDetail.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "insp_rep_detail";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/insp_rep_detail.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableDetail = new DetailDataTable();
            this.Tables.Add(this.tableDetail);
        }
        
        private bool ShouldSerializeDetail() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void DetailRowChangeEventHandler(object sender, DetailRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DetailDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnComment;
            
            internal DetailDataTable() : 
                    base("Detail") {
                this.InitClass();
            }
            
            internal DetailDataTable(DataTable table) : 
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
            
            internal DataColumn CommentColumn {
                get {
                    return this.columnComment;
                }
            }
            
            public DetailRow this[int index] {
                get {
                    return ((DetailRow)(this.Rows[index]));
                }
            }
            
            public event DetailRowChangeEventHandler DetailRowChanged;
            
            public event DetailRowChangeEventHandler DetailRowChanging;
            
            public event DetailRowChangeEventHandler DetailRowDeleted;
            
            public event DetailRowChangeEventHandler DetailRowDeleting;
            
            public void AddDetailRow(DetailRow row) {
                this.Rows.Add(row);
            }
            
            public DetailRow AddDetailRow(string Comment) {
                DetailRow rowDetailRow = ((DetailRow)(this.NewRow()));
                rowDetailRow.ItemArray = new object[] {
                        Comment};
                this.Rows.Add(rowDetailRow);
                return rowDetailRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                DetailDataTable cln = ((DetailDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new DetailDataTable();
            }
            
            internal void InitVars() {
                this.columnComment = this.Columns["Comment"];
            }
            
            private void InitClass() {
                this.columnComment = new DataColumn("Comment", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnComment);
            }
            
            public DetailRow NewDetailRow() {
                return ((DetailRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new DetailRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(DetailRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.DetailRowChanged != null)) {
                    this.DetailRowChanged(this, new DetailRowChangeEvent(((DetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.DetailRowChanging != null)) {
                    this.DetailRowChanging(this, new DetailRowChangeEvent(((DetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.DetailRowDeleted != null)) {
                    this.DetailRowDeleted(this, new DetailRowChangeEvent(((DetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.DetailRowDeleting != null)) {
                    this.DetailRowDeleting(this, new DetailRowChangeEvent(((DetailRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveDetailRow(DetailRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DetailRow : DataRow {
            
            private DetailDataTable tableDetail;
            
            internal DetailRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableDetail = ((DetailDataTable)(this.Table));
            }
            
            public string Comment {
                get {
                    try {
                        return ((string)(this[this.tableDetail.CommentColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDetail.CommentColumn] = value;
                }
            }
            
            public bool IsCommentNull() {
                return this.IsNull(this.tableDetail.CommentColumn);
            }
            
            public void SetCommentNull() {
                this[this.tableDetail.CommentColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class DetailRowChangeEvent : EventArgs {
            
            private DetailRow eventRow;
            
            private DataRowAction eventAction;
            
            public DetailRowChangeEvent(DetailRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public DetailRow Row {
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
