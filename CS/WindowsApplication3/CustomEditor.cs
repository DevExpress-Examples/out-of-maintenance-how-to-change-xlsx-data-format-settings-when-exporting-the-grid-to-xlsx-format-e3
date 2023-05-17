using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Reflection;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraPrinting;

namespace DXSample
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomEdit : RepositoryItemTextEdit {
        
        static RepositoryItemCustomEdit() { RegisterCustomEdit(); }

        public RepositoryItemCustomEdit() { }        

        public const string CustomEditName = "CustomEdit";

        public override string EditorTypeName { get { return CustomEditName; } }
        
        public static void RegisterCustomEdit() {
            Image img = null;
            try {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, 
              typeof(CustomEdit), typeof(RepositoryItemCustomEdit), 
              typeof(TextEditViewInfo), new TextEditPainter(), true, img));
        }
           
        string xlsxFormatString;

        public string XlsxFormatString
        {
            get { return xlsxFormatString; }
            set {
                if (xlsxFormatString != value)
                {
                    xlsxFormatString = value;                        
                    OnPropertiesChanged();
                }
            }
        }

        public override void Assign(RepositoryItem item) {
            BeginUpdate(); 
            try {
                base.Assign(item);
                RepositoryItemCustomEdit source = item as RepositoryItemCustomEdit;
                if(source == null) return;
                XlsxFormatString = source.XlsxFormatString;
            }
            finally {
                EndUpdate();
            }
        }

        public override VisualBrick GetBrick(PrintCellHelperInfo info)
        {
            TextBrick brick = base.GetBrick(info) as TextBrick;
            brick.XlsxFormatString = XlsxFormatString;
            return brick;
        }
    }


    public class CustomEdit : TextEdit {
        
        static CustomEdit() { RepositoryItemCustomEdit.RegisterCustomEdit(); }

        public CustomEdit() { }
     
        public override string EditorTypeName { 
            get { return 
            RepositoryItemCustomEdit.CustomEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomEdit Properties {
            get { return base.Properties as RepositoryItemCustomEdit; }
        }
            
    }
}


