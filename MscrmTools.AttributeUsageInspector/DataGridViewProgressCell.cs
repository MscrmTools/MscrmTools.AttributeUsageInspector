using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MscrmTools.AttributeUsageInspector
{
    internal class DataGridViewProgressCell : DataGridViewImageCell
    {
        static readonly Image emptyImage;

        static DataGridViewProgressCell()
        {
            emptyImage =new Bitmap(1,1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates cellState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            try
            {
                double progressVal = (double) value;
                double percentage = progressVal/(double)100;
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);

                if (percentage > 0.0)
                {
                    graphics.FillRectangle(new SolidBrush(GetColorFromPercentage(Convert.ToInt32(value))), cellBounds.X + 2,
                        cellBounds.Y + 2, Convert.ToInt32((percentage*cellBounds.Width - 4)), cellBounds.Height - 4);
                    graphics.DrawString(progressVal.ToString("N") + "%", cellStyle.Font, foreColorBrush,
                        cellBounds.X + (cellBounds.Width/2) - 5, cellBounds.Y + 2);
                }
                else
                {
                    if (DataGridView.CurrentRow.Index == rowIndex)
                    {
                        graphics.DrawString(progressVal + "%", cellStyle.Font,
                            new SolidBrush(cellStyle.SelectionForeColor),
                            cellBounds.X + 6, cellBounds.Y + 2);
                    }
                    else
                    {
                        graphics.DrawString(progressVal + "%", cellStyle.Font,
                           foreColorBrush,
                           cellBounds.X + 6, cellBounds.Y + 2);
                    }
                }
            }
            catch(Exception error)
            {
                var e = error;
            }
        }

        private const int RGB_MAX = 255; // Reduce this for a darker range
        private const int RGB_MIN = 0; // Increase this for a lighter range

        private Color GetColorFromPercentage(int percentage)
        {
            // Work out the percentage of red and green to use (i.e. a percentage
            // of the range from RGB_MIN to RGB_MAX)
            var redPercent = Math.Min(200 - (percentage * 2), 100) / 100f;
            var greenPercent = Math.Min(percentage * 2, 100) / 100f;

            // Now convert those percentages to actual RGB values in the range
            // RGB_MIN - RGB_MAX
            var red = RGB_MIN + ((RGB_MAX - RGB_MIN) * redPercent);
            var green = RGB_MIN + ((RGB_MAX - RGB_MIN) * greenPercent);

            return Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), RGB_MIN);
        }
    }
}