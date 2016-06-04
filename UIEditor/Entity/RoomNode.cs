﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SourceGrid;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Views;
using Structure;
using UIEditor.Component;
using Button = SourceGrid.Cells.Button;

namespace UIEditor.Entity
{
    [Serializable]
    public class RoomNode : ViewNode
    {
        private static int index = 0;

        public string Symbol { get; set; }

        public string PinCode { get; set; }

        /// <summary>
        /// 是否将该房间作为默认显示页面
        /// </summary>
        public bool DefaultRoom { get; set; }

        #region 构造函数

        public RoomNode()
        {
            index++;

            Text = ResourceMng.GetString("TextRoom") + "_" + index;

            Symbol = MyConst.DefaultIcon;
            PinCode = "";
            this.DefaultRoom = false;

            Name = ImageKey = SelectedImageKey = MyConst.View.KnxRoomType;
        }

        public RoomNode(KNXRoom knx)
            : base(knx)
        {
            Symbol = knx.Symbol;
            PinCode = knx.PinCode;
            this.DefaultRoom = knx.DefaultRoom;

            Name = ImageKey = SelectedImageKey = MyConst.View.KnxRoomType;
        }

        protected RoomNode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion

        public KNXRoom ToKNX()
        {
            var knx = new KNXRoom();

            base.ToKnx(knx);

            knx.Symbol = this.Symbol;
            knx.PinCode = this.PinCode;
            knx.DefaultRoom = this.DefaultRoom;

            knx.Pages = new List<KNXPage>();

            return knx;
        }

        public override void DisplayProperties(Grid grid)
        {
            #region 显示属性

            grid.Tag = this;

            var nameModel = new Cell();
            nameModel.BackColor = grid.BackColor;

            var stringEditor = new TextBox(typeof(string));

            var valueChangedController = new ValueChangedEvent();

            var currentRow = 0;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropType"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Name);

            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropTitle"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Text);
            grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropIcon"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Symbol);
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            if (this.Symbol != null)
            {
                grid[currentRow, MyConst.ValueColumn].Image =
                    ImageHelper.LoadImage(Path.Combine(MyCache.ProjImagePath, this.Symbol));
            }
            grid[currentRow, MyConst.ButtonColumn] = new Button("...");
            var symbolButtonController = new SourceGrid.Cells.Controllers.Button();
            symbolButtonController.Executed += PickImage;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(symbolButtonController);

            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropPassword"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.PinCode);
            grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropIsDefaultRoom"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.DefaultRoom, typeof(bool));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            #endregion
        }

        public override void ChangePropValues(CellContext context)
        {
            int row = context.Position.Row;

            #region room

            switch (row)
            {
                case 1:
                    this.Text = context.Value.ToString();
                    break;
                case 2:
                    this.Symbol = context.Value.ToString();
                    break;
                case 3:
                    this.PinCode = context.Value.ToString();
                    break;
                case 4:
                    this.DefaultRoom = Convert.ToBoolean(context.Value);
                    break;
                default:
                    ShowSaveEntityMsg(MyConst.View.KnxRoomType);
                    break;
            }

            #endregion
        }

        public override ViewNode Clon2()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as RoomNode;
        }
    }
}
