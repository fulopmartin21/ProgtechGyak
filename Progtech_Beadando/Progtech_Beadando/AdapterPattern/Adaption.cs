using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Progtech_Beadando.AdapterPattern
{
    class Adaption
    {
        public void SpecialRequest(List<Car> kocsik)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() {Filter="Excel Workbook|*.xlsx" })
            {
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    try
                    {
                        using(XLWorkbook workbook=new XLWorkbook())
                        {
                            IXLWorksheet workSheet= workbook.AddWorksheet("Auto_Log");
                            IXLCell Cell= workSheet.FirstCell();
                            workSheet.ActiveCell = Cell;
                            Cell.Value="Márka";
                            int row=workSheet.ActiveCell.Address.RowNumber;
                            Cell = workSheet.Cell(row, 2);
                            Cell.Value="Típus";
                            row = Cell.Address.RowNumber;
                            Cell = workSheet.Cell(row, 3);
                            Cell.Value = "Végösszeg";
                            Cell = workSheet.Cell(row, 4);
                            Cell.Value = "Extrák";
                            row++;
                            int teljesosszeg = 0;
                            for(int i=0;i<kocsik.Count;i++)
                            {
                                    Cell = workSheet.Cell(row, 1);
                                    Cell.Value = kocsik[i].brand;

                                    Cell = workSheet.Cell(row, 2);
                                    Cell.Value = kocsik[i].type;

                                    Cell = workSheet.Cell(row, 3);
                                    Cell.Value = kocsik[i].price;
                                    teljesosszeg += kocsik[i].price;
                                    Cell = workSheet.Cell(row, 4);
                                for (int j = 0; j < kocsik[i].extra.Count; j++)
                                {
                                    Cell.Value +=" "+kocsik[i].extra[j].name;
                                        }
                                row++;
                            }
                            Cell = workSheet.Cell(row, 1);
                            Cell.Value = "Teljes összeg:";
                            Cell = workSheet.Cell(row, 2);
                            Cell.Value = teljesosszeg;
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Successful Export!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
