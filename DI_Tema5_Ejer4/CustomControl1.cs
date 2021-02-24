using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema5_Ejer4
{
    public partial class DibujoAhorcado : Control
    {
        int errores = 0;

        public int Errores { 
            get => errores;

            set
            {
                errores = value;
                CambiaError?.Invoke(this, EventArgs.Empty);
                if(errores == 6)
                {
                    Ahorcado?.Invoke(this,EventArgs.Empty);
                }
            }
        }

        public DibujoAhorcado()
        {
            InitializeComponent();
            CambiaError += refresca;

        }


        
        [Category("Cositas")]
        [Description("Pues eso, cuando cambia error... se activa")]
        public event System.EventHandler CambiaError;

        [Category("cositas")]
        [Description("Cuando un jugador canta uno, no te jode")]
        public event System.EventHandler Ahorcado;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Pen p = new Pen(Color.Blue);
            pe.Graphics.DrawLine(p,new Point(20, 400),new Point(20,100));
            pe.Graphics.DrawLine(p, new Point(20, 100), new Point(100, 100));
            pe.Graphics.DrawLine(p, new Point(100, 100), new Point(100, 120));
            p.Color = Color.Red;
            switch (Errores)
            {
                case 6:
                    pe.Graphics.DrawLine(p, new Point(100, 250), new Point(145, 350));
                    goto case 5;
                case 5:
                    pe.Graphics.DrawLine(p, new Point(100, 250), new Point(55, 350));
                    goto case 4;
                case 4:
                    pe.Graphics.DrawLine(p, new Point(100, 160), new Point(100, 250));
                    goto case 3;
                case 3:
                    pe.Graphics.DrawLine(p, new Point(100, 160), new Point(145, 200));
                    goto case 2;
                case 2:
                    pe.Graphics.DrawLine(p, new Point(100, 160), new Point(55, 200));
                    goto case 1;
                case 1:
                    pe.Graphics.DrawEllipse(p,new Rectangle(new Point(80,120),new Size(40,40)));
                    break;
                default:
                    if (errores != 0)
                    {
                        SolidBrush b = new SolidBrush(this.ForeColor);
                        pe.Graphics.DrawString("¿Ande vas? ¡Payaso!", this.Font, b, 80, 120);
                    }
                    break;
            }

        }

        
        public void refresca(Object sender,EventArgs e)
        {
            Refresh();
        }
        

            
    } 
}
