using DevExpress.Utils.Html;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Windows.Forms;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VNS_Tutorial2023
{
     public class MsgBox
    {
		
        public void ShowInfo(string messageText)
        {
            string html = @"<div class=""frame"" id=""frame"">
                        <div class=""header"">
                            <div class=""caption"">Thông báo</div>
    	                    <div class=""close-button"" id=""closebutton"">
		                    </div>
                        </div>
                        <div class=""content"" id=""content"">
    	                    <div class=""message text"">" + string.Format("{0}", messageText) + @"</div>
    	                    <div class=""message button"" tabindex=""1"" id=""dialogresult-ok"">OK</div>
                        </div>
                    </div>";
            string css = @"body{	
	                            padding: 20px;
	                            font-size: 14px;
	                            font-family: 'Segoe UI';
                            }
                            .frame {
	                            width: 450px;
	                            color: @ControlText;
	                            background-color: @Window;
	                            border: 1px solid @Blue;
	                            border-radius: 16px;
	                            display: flex;
	                            flex-direction: column;
	                            justify-content: center;
	                            box-shadow: 0px 8px 16px @Blue/0.6;
                            }
                            .header {
	                            padding: 8px;
	                            color: @White;
	                            background-color: @Blue;
	                            border-radius: 15px 15px 0px 0px;
	                            display: flex;
	                            justify-content: space-between;
	                            align-items: center;
                            }
                            .caption {
	                            margin: 0px 10px;
	                            font-weight: bold;
                            }
                            .close-button {
	                            padding: 8px;
	                            border-radius: 5px;
                            }
                            .close-button:hover {
	                            background-color: @WindowText/0.1;
                            }
                            .close-button:active {
	                            background-color: @ControlText/0.05;
                            }
                            .close-button-img {
	                            fill: White;
	                            width: 18px;
	                            height: 18px;
	                            opacity: 0.8;
                            }
                            .content {
	                            display: flex;
	                            align-items: center;
	                            flex-direction: column;
	                            padding: 10px;
                            }
                            .message {
	                            margin: 7px;
                            }
                            .icon {
	                            width: 48px;
	                            height: 48px;
	                            opacity: 0.8;
                            }
                            .text {
	                            color: @ControlText;
	                            text-align: center;
                            }
                            .button {
	                            color: @Blue;
	                            padding: 8px 24px;
	                            border: 1px solid @Blue;
	                            border-radius: 5px;
                            }
                            .button:hover {
	                            color: @White;
	                            background-color: @Blue;
	                            box-shadow: 0px 0px 10px @Blue/0.5;
                            }";
            //HtmlTemplateCollection htmlTemplateCollection1 = new HtmlTemplateCollection();
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });

            XtraMessageBox.Show(xtraMessageBoxArgs);
        }
        public void ShowError(string messageText)
        {
            string html =
                        @"<div class=""frame"" id=""frame"">
	                    <div class=""header"">
		                    <div class=""header-element caption"">Thông báo lỗi</div>" +
                            @"</div>
                        
	                    <div class=""message-text"" id=""content"">" + string.Format("{0}", messageText) + "</div>" +
                        @"<div class=""buttons"">
                            <img src=""Icons/warning.png""/>
		                    <div class=""button"" tabindex=""1"" id=""dialogresult-ok"">OK</div>
	                    </div>
                    </div>";
            string css =
                        @"body{
	                            padding: 15px;
	                            font-size: 14px;
	                            font-family: 'Segoe UI';
                            }
                            .frame {
	                            min-width: 470px;
	                            background-color: @Window;
	                            border-radius: 10px;
	                            box-shadow: 0px 8px 10px 0px rgba(0, 0, 0, 0.2);
                            }
                            .header {
	                            background-color: @Critical;
	                            padding: 5px;
	                            display: flex;
	                            align-items: center;
	                            justify-content: space-between;
	                            border-radius: 10px 10px 0px 0px;
                            }
                            .header-element {
	                            margin: 5px 5px 5px 25px;
                            }
                            .caption {
	                            color: @White;
	                            font-weight: bold;
                            }
                            .close-button-img {
	                            fill: @White;
	                            width: 18px;
	                            height: 18px;
	                            opacity: 0.8;
                            }
                            .close-button {
	                            padding: 5px;
	                            border-radius: 4px;
                            }
                            .close-button:hover {
	                            background-color: @WindowText/0.1;
                            }
                            .close-button:active {
	                            background-color: @ControlText/0.05;
                            }
                            .message-text {
	                            margin: 15px 30px;
	                            font-size: 12px;
	                            white-space: pre;
	                            color: @WindowText/0.8;
                            }
                            .buttons {
	                            margin: 10px;
	                            display: flex;
	                            justify-content: center;
                            }
                            .button {
	                            color: @Critical;
	                            border-radius: 5px;
	                            padding: 8px 24px;
	                            margin: 0px 5px;
	                            border: solid 1px @Transparent;
                            }
                            .button:hover {
	                            color: @White;
	                            background-color: @Critical;
	                            box-shadow: 0px 0px 10px @Critical/0.5;
                            }
                            .button:focus {
	                            border-color: @Critical;
                            }";
            //HtmlTemplateCollection htmlTemplateCollection1 = new HtmlTemplateCollection();
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });
            XtraMessageBox.Show(xtraMessageBoxArgs);
        }
        public void ShowException(Exception ex)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                    SplashScreenManager.CloseForm();
            string html =
                        @"<div class=""frame"" id=""frame"">
	                    <div class=""header"">
		                    <div class=""header-element caption"">Thông báo lỗi</div>" +
                            @"</div>
	                    <div class=""message-text"" id=""content"">" + string.Format("{0}", ex) + "</div>" +
                        @"<div class=""buttons"">
		                    <div class=""button"" tabindex=""1"" id=""dialogresult-ok"">OK</div>
	                    </div>
                    </div>";
            string css =
                        @"body{
	                            padding: 15px;
	                            font-size: 14px;
	                            font-family: 'Segoe UI';
                            }
                            .frame {
	                            min-width: 470px;
	                            background-color: @Window;
	                            border-radius: 10px;
	                            box-shadow: 0px 8px 10px 0px rgba(0, 0, 0, 0.2);
                            }
                            .header {
	                            background-color: @Critical;
	                            padding: 5px;
	                            display: flex;
	                            align-items: center;
	                            justify-content: space-between;
	                            border-radius: 10px 10px 0px 0px;
                            }
                            .header-element {
	                            margin: 5px 5px 5px 25px;
                            }
                            .caption {
	                            color: @White;
	                            font-weight: bold;
                            }
                            .close-button-img {
	                            fill: @White;
	                            width: 18px;
	                            height: 18px;
	                            opacity: 0.8;
                            }
                            .close-button {
	                            padding: 5px;
	                            border-radius: 4px;
                            }
                            .close-button:hover {
	                            background-color: @WindowText/0.1;
                            }
                            .close-button:active {
	                            background-color: @ControlText/0.05;
                            }
                            .message-text {
	                            margin: 15px 30px;
	                            font-size: 12px;
	                            white-space: pre;
	                            color: @WindowText/0.8;
                            }
                            .buttons {
	                            margin: 10px;
	                            display: flex;
	                            justify-content: flex-end;
                            }
                            .button {
	                            color: @Critical;
	                            border-radius: 5px;
	                            padding: 8px 24px;
	                            margin: 0px 5px;
	                            border: solid 1px @Transparent;
                            }
                            .button:hover {
	                            color: @White;
	                            background-color: @Critical;
	                            box-shadow: 0px 0px 10px @Critical/0.5;
                            }
                            .button:focus {
	                            border-color: @Critical;
                            }";
            //HtmlTemplateCollection htmlTemplateCollection1 = new HtmlTemplateCollection();
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });

            XtraMessageBox.Show(xtraMessageBoxArgs);

        }
        public void ShowWarning(string messageText)
        {
            string html =
                        @"<div class=""frame"" id=""frame"">
	                    <div class=""header"">
		                    <div class=""header-element caption"">Thông báo lỗi</div>" +
                            @"</div>
                        
	                    <div class=""message-text"" id=""content"">" + string.Format("{0}", messageText) + "</div>" +
                        @"<div class=""buttons"">
                            <img src=""Icons/warning.png""/>
		                    <div class=""button"" tabindex=""1"" id=""dialogresult-ok"">OK</div>
	                    </div>
                    </div>";
            string css =
                        @"body{
	                            padding: 15px;
	                            font-size: 14px;
	                            font-family: 'Segoe UI';
                            }
                            .frame {
	                            min-width: 470px;
	                            background-color: @Window;
	                            border-radius: 10px;
	                            box-shadow: 0px 8px 10px 0px rgba(0, 0, 0, 0.2);
                            }
                            .header {
                                background-color: @Yellow;
	                            padding: 5px;
	                            display: flex;
	                            align-items: center;
	                            justify-content: space-between;
	                            border-radius: 10px 10px 0px 0px;
                            }
                            .header-element {
	                            margin: 5px 5px 5px 25px;
                            }
                            .caption {
	                            color: @White;
	                            font-weight: bold;
                            }
                            .close-button-img {
	                            fill: @White;
	                            width: 18px;
	                            height: 18px;
	                            opacity: 0.8;
                            }
                            .close-button {
	                            padding: 5px;
	                            border-radius: 4px;
                            }
                            .close-button:hover {
	                            background-color: @WindowText/0.1;
                            }
                            .close-button:active {
	                            background-color: @ControlText/0.05;
                            }
                            .message-text {
	                            margin: 15px 30px;
	                            font-size: 12px;
	                            white-space: pre;
	                            color: @WindowText/0.8;
                            }
                            .buttons {
	                            margin: 10px;
	                            display: flex;
	                            justify-content: center;
                            }
                            .button {
	                            color: @Critical;
	                            border-radius: 5px;
	                            padding: 8px 24px;
	                            margin: 0px 5px;
	                            border: solid 1px @Transparent;
                            }
                            .button:hover {
	                            color: @White;
	                            background-color: @Blue;
	                            box-shadow: 0px 0px 10px @Critical/0.5;
                            }
                            .button:focus {
	                            border-color: @Critical;
                            }";
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });

            XtraMessageBox.Show(xtraMessageBoxArgs);
        }
        public bool getYes_ShowMessage_Question(string str)
        {
            DialogResult dCliResTest = XtraMessageBox.Show(str, "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dCliResTest == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public void Notifications(string notificationsText)
        {
            string html = @"
						<div class=""container"">
						<div class=""toast-notification success"">
							<div class=""stripe-green""></div>
							<div class=""content"">
								<div class=""text header"">Success</div>
								<div class=""text"">"+ string.Format("{0}", notificationsText) + @"</div>
							</div>
						</div>
					</div>";
			string css = @"
						.container {
							display: flex;
							flex-direction: column;
							width: 100%;
							height: 100%;
							background-color: @Window;
							align-items: center;
							justify-content: center;
						}

						.toast-notification {
							display: flex;
							flex-direction: row;
							border-radius: 6px;
							border-style: solid;
							border-width: 1px 1px 1px 0px;
							margin: 12px;
							align-items: center;
						}

						.success {
							border-color: @green/0.3;
							background-color: @green/0.03;
							box-shadow: 8px 8px 8px @green/0.05;
						}

						.warning {
							border-color: @orange/0.3;
							background-color: @orange/0.03;
							box-shadow: 8px 8px 8px @orange/0.05;
						}


						.stripe-green {
							width: 3px;
							background-color: @green/0.8;
							height: 100%;
							border-radius: 6px 0px 0px 6px;
						}

						.content {
							display: flex;
							flex-direction: column;
							padding: 8px;
						}

						.header {
							font-size: 18px;
							font-weight: bold;
							padding: 6px;
						}

						.text {
							font-family: 'Segoe UI';
							font-size: 14px;
							color: #606060;
							padding: 0px 6px 6px 6px;
						}
						";
            //HtmlTemplateCollection htmlTemplateCollection1 = new HtmlTemplateCollection();
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });
            XtraMessageBox.Show(xtraMessageBoxArgs);
        }
		public void Dialogs(string dialogs)
		{
			string html = @"
						<div class=""frame"" id=""frame"">
							<div class=""content"">
								<div class=""text caption"">${Thông Báo}</div>
								<div id=""content"">
		   							<div class=""text message"">"+ string.Format("{0}", dialogs)+ @"</div>
								</div>
							</div>
							<div class=""buttons"">
								<div class=""button"" tabindex=""1"" id=""dialogresult-yes"">Ok</div>
    							<div class=""button"" tabindex=""3"" id=""dialogresult-cancel"">Cancel</div>
							</div>
						</div>";
			string css = @"
						body{
							padding: 15px;
							font-size: 10pt;
							font-family: ""Segoe UI"";
							text-align: center;
						}
						.frame{
							color: @ControlText;
							background-color: @White;
							border: 1px solid @Black/0.2;
							border-radius: 10px;
							box-shadow: 0px 5px 10px 0px rgba(0, 0, 0, 0.2);
						}
						.content {
							padding: 15px;
						}
						.text {
							padding: 10px;
							text-align: left;
						}
						.caption {
							font-size: 15pt;
							font-family: 'Segoe UI Semibold';
						}
						.message {
							white-space: pre;
						}
						.buttons {
							background-color: @Control;
							padding: 20px;
							display: flex;
							flex-direction: row;
							justify-content: center;
							border-top: 1px solid @Black/0.1;
							border-radius: 0px 0px 10px 10px;
						}
						.button {
							color: @WindowText;
							background-color: @White;
							min-width: 80px;
							margin: 0px 5px;
							padding: 5px;
							border: 1px solid @Black/0.15;
							border-radius: 5px;
						}
						.button:hover {
							background-color: @Black/0.1;
						}
						.button:focus {
							background-color: @HighlightAlternate;
							border: 1px solid @HighlightAlternate;
							color: @White;
						}";
            //HtmlTemplateCollection htmlTemplateCollection1 = new HtmlTemplateCollection();
            XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
            xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
            {
                Template = html,
                Styles = css,
            });
			//DialogResult resuls = XtraMessageBox.Show(dialogs, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            DialogResult resuls = XtraMessageBox.Show(xtraMessageBoxArgs);
        }
		public bool Oke_Cancel_ShowMessage_Question(string str)
		{
			DialogResult result = XtraMessageBox.Show(str,"Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if(result == DialogResult.OK)
			{
				return true;
			}
			return false;
		}
		
		public void AlertControls(string alertControls, string caption, string text)
		{
			// Faild
			string html = @"<div class=""container"">
								<div class=""popup"">
    								<div class=""header"">
    									<div class=""header-caption"">
    										<img src=""../img/Info.svg"" class=""header-caption-icon"" />
    										<div class=""header-caption-text"">" + string.Format("{0}", alertControls) + @"</div>
    									</div>
    									<div class=""header-buttons"">
    										<div id=""closeButton"" class=""header-button"">
    											<img src=""../img/Close.svg"" class=""close-button"" />
    										</div>
    									</div>
    								</div>
    								<div class=""message"">
    									<div class=""message-image-container"">
	    									<img src=""../img/User.svg"" class=""message-image"" />
    									</div>
    									<div class=""message-text-container"">
    										<div class=""message-caption"">" + string.Format("{0}",caption) +@"</div>
    										<div class=""message-text"">" + string.Format("{0}", text)+ @"</div>
    									</div>
    								</div>
    								<div class=""buttons"">
    									<div class=""button"">Reply</div>
    									<div class=""button"">Mark as read</div>
    								</div>
								</div>
							</div>";
			string css = @"
						.container{
							padding: 6px 14px 20px 14px;
						} 
						.popup{
							width: 362px;
							height: auto;
							padding: 4px;
							border-radius: 4px;
							box-shadow: 0px 8px 16px rgba(0,0,0,0.25);
							border: 1px solid @WindowText/0.2;
							display: flex;
							flex-direction: column;
							font-family: ""Segoe UI"";
							text-align: center;
							justify-content: space-around;
							background-color: @Control;
							color: @ControlText;
							font-size: 10pt;
						}
						.header{
							display: flex;
							flex-direction: row;
							justify-content: space-between;
							font-family: 'Segoe UI Semibold';
						}
						.header-caption{
							padding: 10px 10px 0px 10px;
							display: flex;
							flex-direction: row;
						}
						.header-caption-icon{
							width: 18px;
							height: 18px;
						}
						.header-caption-text{
							padding-left: 10px;
						}
						.header-buttons{
							display: flex;
							flex-direction: row;
							padding: 5px 2px 0px 0px;
						}
						.header-button{
							padding: 5px;
							border-radius: 2px;
							align-self: center;
						}
						.header-button:hover{
							background-color: @HotTrackedColor/0.9;
						}
						.header-button:active{
							background-color: @HotTrackedColor/0.6;
						}
						.close-button{
							width: 18px;
							height: 18px;
						}
						.message{
							display: flex;
							flex-direction: row;
						}
						.message-text-container{
							text-align: left;
							padding: 10px;
						}
						.message-image-container{
							align-self: center;
							padding: 9px;
						}
						.message-image{
							width: 54px;
							height: 54px;
						}
						.message-caption{
							font-size: 10.5pt;
							font-family: 'Segoe UI Semibold';
						}
						.message-text{
						}
						.buttons{
							display: flex;
							flex-direction: row;
							justify-content: space-between;
						}
						.button{
							margin: 9px;
							padding: 8px;
							width: 100%;
							border-radius: 4px;
							box-shadow: 1px 1px 1px rgba(0,0,0,0.25);
							background-color: @Window;
							color: @WindowText;
							font-size: 10.5pt;
							font-family: 'Segoe UI Semibold';
							border: 1px solid @WindowText/0.1;
    
						}
						.button:hover{
							background-color: @HotTrackedColor/0.9;
							color: @HotTrackedForeColor;
							border: 1px solid @HotTrackedForeColor/0.2;
						}
						.button:active{
							background-color: @HotTrackedColor/0.6;
						}";
			XtraMessageBoxArgs xtraMessageBoxArgs = new XtraMessageBoxArgs();
			xtraMessageBoxArgs.HtmlTemplate.Assign(new HtmlTemplate()
			{
				Template = html,
				Styles = css,
			});
			XtraMessageBox.Show(xtraMessageBoxArgs);
		}
    }
}
