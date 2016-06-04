﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SourceGrid;
using Structure;
using Structure.Control;
using UIEditor.Component;

namespace UIEditor.Entity.Control
{
    [Serializable]
    public class SceneButtonNode : ControlBaseNode
    {
        private static int index = 0;


        public string ImageOn { get; set; }

        /// <summary>
        /// 开启时控件的背景色
        /// </summary>
        public string ColorOn { get; set; }

        public string ImageOff { get; set; }

        /// <summary>
        /// 关闭时控件的背景色
        /// </summary>
        public string ColorOff { get; set; }

        public bool IsGroup { get; set; }

        public int DefaultValue { get; set; }

        ////按钮说明
        //public string Description { get; set; }

        ////是否有长按事件
        //public bool HasLongClickCommand { get; set; }


        #region 构造函数
        public SceneButtonNode()
        {
            index++;

            this.Text = ResourceMng.GetString("TextSceneButton") + "_" + index;

            this.Width = 150;
            this.Height = 40;
            this.FlatStyle = EFlatStyle.Stereo;

            this.Clickable = true;

            this.ImageOn = "stripOn.png";
            this.ColorOn = this.BackgroundColor;
            this.ImageOff = "stripOff.png";
            this.ColorOff = this.BackgroundColor;
            this.IsGroup = false;
            //this.Description = "";
            //this.HasLongClickCommand = true;

            string FileImageOn = Path.Combine(MyCache.ProjImagePath, this.ImageOn);
            if (!File.Exists(FileImageOn))
            {
                File.Copy(Path.Combine(MyCache.ProjectResImgDir, this.ImageOn), Path.Combine(MyCache.ProjImagePath, this.ImageOn));
            }

            string FileImageOff = Path.Combine(MyCache.ProjImagePath, this.ImageOff);
            if (!File.Exists(FileImageOff))
            {
                File.Copy(Path.Combine(MyCache.ProjectResImgDir, this.ImageOff), Path.Combine(MyCache.ProjImagePath, this.ImageOff));
            }

            Name = ImageKey = SelectedImageKey = MyConst.Controls.KnxSceneButtonType;
        }

        public SceneButtonNode(KNXSceneButton knx)
            : base(knx)
        {
            this.ImageOn = knx.ImageOn;
            this.ColorOn = knx.ColorOn;
            this.ImageOff = knx.ImageOff;
            this.ColorOff = knx.ColorOff;
            this.IsGroup = knx.IsGroup;
            this.DefaultValue = knx.DefaultValue;
            //this.Description = knx.Description;
            //this.HasLongClickCommand = knx.HasLongClickCommand;

            Name = ImageKey = SelectedImageKey = MyConst.Controls.KnxSceneButtonType;
        }

        protected SceneButtonNode(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion

        public KNXSceneButton ToKnx()
        {
            var knx = new KNXSceneButton();

            base.ToKnx(knx);

            knx.ImageOn = this.ImageOn;
            knx.ColorOn = this.ColorOn;
            knx.ImageOff = this.ImageOff;
            knx.ColorOff = this.ColorOff;
            knx.IsGroup = this.IsGroup;
            knx.DefaultValue = this.DefaultValue;
            //knx.Description = this.Description;
            //knx.HasLongClickCommand = this.HasLongClickCommand;

            return knx;
        }

        public override void DisplayProperties(Grid grid)
        {
            base.DisplayProperties(grid);

            var nameModel = new SourceGrid.Cells.Views.Cell();
            nameModel.BackColor = grid.BackColor;

            var stringEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            var intEditor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));

            var valueChangedController = new ValueChangedEvent();

            #region TreeNode属性
            /* 0 类型 */
            var currentRow = 0;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropType"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Name);

            /* 1 名称 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropTitle"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Text);
            grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            #endregion

            #region ViewNode属性
            /* 2 左上角顶点位置X */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropX"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Left);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 3 左上角顶点位置Y */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropY"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Top);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 4 宽度 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropWidth"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Width);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 5 高度 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropHeight"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Height);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 6 显示边框 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropBorderWidth"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.DisplayBorder, typeof(bool));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 7 边框颜色 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropBorderColor"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.BorderColor)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.BorderColor);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.BorderColor);
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            var colorButtonController = new SourceGrid.Cells.Controllers.Button();
            colorButtonController.Executed += PickColor;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(colorButtonController);

            /* 8 不透明度 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropAlpha"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Alpha);
            grid[currentRow, MyConst.ValueColumn].Editor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(Double)); ;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 9 圆角半径 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropRadius"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Radius);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 10 背景色 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropBackColor"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.BackgroundColor)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.BackgroundColor);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.BackgroundColor);
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
             colorButtonController = new SourceGrid.Cells.Controllers.Button();
            colorButtonController.Executed += PickColor;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(colorButtonController);

            /* 11 平面样式 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropFlatStyle"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.FlatStyle, typeof(EFlatStyle));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 12 字体颜色 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropFontColor"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.FontColor);
            grid[currentRow, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.FontColor);
            grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            var foreColorButtonController = new SourceGrid.Cells.Controllers.Button();
            foreColorButtonController.Executed += PickColor;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(foreColorButtonController);

            /* 13 字体大小 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropFontSize"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.FontSize);
            grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            #endregion

            #region ControlBaseNode
            /* 14 ETS写地址表 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropEtsWriteAddressIds"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(EtsAddressDictToString(this.WriteAddressIds));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            var writeAddButton = new SourceGrid.Cells.Controllers.Button();
            writeAddButton.Executed += PickMultiWriteAddress;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(writeAddButton);

            /* 15 ETS读地址 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropEtsReadAddressId"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(EtsAddressDictToString(this.ReadAddressId));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            var readAddButton = new SourceGrid.Cells.Controllers.Button();
            readAddButton.Executed += PickSingleReadAddress;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(readAddButton);

            /* 16 有没有提示 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropHasTip"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.HasTip, typeof(bool));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* `7 提示 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropTip"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Tip, stringEditor);
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            /* 18 是否可以点击 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropClickable"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Clickable, typeof(bool));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            #endregion

            #region 自定义属性
            /* 19 开启时显示的图标 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropSwitchImageOn"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.ImageOn)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.ImageOn);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image =
                    ImageHelper.LoadImage(Path.Combine(MyCache.ProjImagePath, this.ImageOn));
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            var imageButtonController = new SourceGrid.Cells.Controllers.Button();
            imageButtonController.Executed += PickImage;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(imageButtonController);

            /* 20 开启时控件显示的背景色 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropColorOn"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.ColorOn)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.ColorOn);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.ColorOn);
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            colorButtonController = new SourceGrid.Cells.Controllers.Button();
            colorButtonController.Executed += PickColor;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(colorButtonController);

            /* 21 关闭时显示的图标 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropSwitchImageOff"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.ImageOff)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.ImageOff);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image =
                    ImageHelper.LoadImage(Path.Combine(MyCache.ProjImagePath, this.ImageOff));
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            imageButtonController = new SourceGrid.Cells.Controllers.Button();
            imageButtonController.Executed += PickImage;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(imageButtonController);

            /* 22 关闭时控件显示的背景色 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropColorOff"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            if (null == this.ColorOff)
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell("");
            }
            else
            {
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.ColorOff);
                grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
                grid[currentRow, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.ColorOff);
            }
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            grid[currentRow, MyConst.ButtonColumn] = new SourceGrid.Cells.Button("...");
            colorButtonController = new SourceGrid.Cells.Controllers.Button();
            colorButtonController.Executed += PickColor;
            grid[currentRow, MyConst.ButtonColumn].Controller.AddController(colorButtonController);

            /* 23 该控件是否与其他场景按钮属于同一组 */
            currentRow++;
            grid.Rows.Insert(currentRow);
            grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropIsGroup"));
            grid[currentRow, MyConst.NameColumn].View = nameModel;
            grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.IsGroup, typeof(bool));
            grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            //if (this.isGroup)
            //{
                /* 20 默认值，选中组(isGroup)特性时才有效 */
                currentRow++;
                grid.Rows.Insert(currentRow);
                grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell(ResourceMng.GetString("PropDefaultValue"));
                grid[currentRow, MyConst.NameColumn].View = nameModel;
                grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.DefaultValue);
                grid[currentRow, MyConst.ValueColumn].Editor = intEditor;
                grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            //}

            //currentRow++;
            //grid.Rows.Insert(currentRow);
            //grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell("按钮说明");
            //grid[currentRow, MyConst.NameColumn].View = nameModel;
            //grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.Description);
            //grid[currentRow, MyConst.ValueColumn].Editor = stringEditor;
            //grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);

            //currentRow++;
            //grid.Rows.Insert(currentRow);
            //grid[currentRow, MyConst.NameColumn] = new SourceGrid.Cells.Cell("是否长按");
            //grid[currentRow, MyConst.NameColumn].View = nameModel;
            //grid[currentRow, MyConst.ValueColumn] = new SourceGrid.Cells.Cell(this.HasLongClickCommand, typeof(bool));
            //grid[currentRow, MyConst.ValueColumn].AddController(valueChangedController);
            #endregion

        }

        public override void ChangePropValues(CellContext context)
        {
            int row = context.Position.Row;
            var grid = context.Grid as Grid;

            switch (row)
            {
                #region TreeNode属性
                case 0:    // 类型
                    break;
                case 1:    // 名称
                    this.Text = (string)context.Value;
                    break;
                #endregion

                #region ViewNode属性
                case 2:     // 左上角顶点位置X
                    this.Left = Convert.ToInt32(context.Value);
                    break;
                case 3:     // 左上角顶点位置Y
                    this.Top = Convert.ToInt32(context.Value);
                    break;
                case 4:     // 宽度
                    this.Width = Convert.ToInt32(context.Value);
                    break;
                case 5:     // 高度
                    this.Height = Convert.ToInt32(context.Value);
                    break;
                case 6:     // 边框宽度
                    this.DisplayBorder = Convert.ToBoolean(context.Value);
                    break;
                case 7:     // 边框颜色
                    this.BorderColor = (string)context.Value;
                    break;
                case 8:     // 不透明度
                    this.Alpha = Convert.ToDouble(context.Value);
                    break;
                case 9:     // 圆角半径
                    this.Radius = Convert.ToInt32(context.Value);
                    break;
                case 10:     // 背景色
                    this.BackgroundColor = (string)context.Value;
                    grid[row, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.BackgroundColor);
                    break;
                case 11:     // 平面样式
                    this.FlatStyle = (EFlatStyle)Convert.ToInt32(context.Value);
                    break;
                case 12:     // 字体颜色
                    this.FontColor = (string)context.Value;
                    grid[row, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.FontColor);
                    break;
                case 13:    // 字体大小
                    this.FontSize = Convert.ToInt32(context.Value);
                    break;
                #endregion

                #region ControlBaseNode属性
                case 14:    // ETS写地址表
                    break;
                case 15:    // ETS读地址
                    break;
                case 16:    // 有没有提示
                    this.HasTip = Convert.ToBoolean(context.Value);
                    break;
                case 17:    // 提示
                    this.Tip = (string)context.Value;
                    break;
                case 18:    // 是否可以点击
                    this.Clickable = Convert.ToBoolean(context.Value);
                    break;
                #endregion

                #region 自定义属性
                case 19: // 开启时显示的标
                    this.ImageOn = (string)context.Value;
                    if (null != this.ImageOn)
                    {
                        grid[row, MyConst.ValueColumn].Image = ImageHelper.LoadImage(Path.Combine(MyCache.ProjImagePath, this.ImageOn));
                    }
                    else
                    {
                        grid[row, MyConst.ValueColumn].Image = null;
                    }
                    break;
                case 20:     // 开启时控件显示的背景色
                    this.ColorOn = (string)context.Value;
                    grid[row, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.ColorOn);
                    break;
                case 21:    // 关闭时显示的图标
                    this.ImageOff = (string)context.Value;
                    if (null != this.ImageOff)
                    {
                        grid[row, MyConst.ValueColumn].Image = ImageHelper.LoadImage(Path.Combine(MyCache.ProjImagePath, this.ImageOff));
                    }
                    else
                    {
                        grid[row, MyConst.ValueColumn].Image = null;
                    }
                    break;
                case 22:     // 关闭时控件显示的背景色
                    this.ColorOff = (string)context.Value;
                    grid[row, MyConst.ValueColumn].Image = ImageHelper.CreateImage(this.ColorOff);
                    break;
                case 23:    // 是否可以点击
                    this.IsGroup = Convert.ToBoolean(context.Value);
                    //grid.Rows.Clear();
                    //DisplayProperties(grid);
                    break;
                case 24:    // 默认值，选中组(isGroup)特性时才有效
                    this.DefaultValue = Convert.ToInt32(context.Value);
                    break;
                //case 13:
                //    this.Description = context.Value.ToString();
                //    break;
                //case 14:
                //    this.HasLongClickCommand = (bool)context.Value;
                //    break;
                default:
                    ShowSaveEntityMsg(MyConst.Controls.KnxSceneButtonType);
                    break;
                #endregion
            }

            this.PropertiesChangedNotify(this, EventArgs.Empty);

        }

        public override ViewNode Clon2()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as GroupBoxNode;
        }
    }
}
