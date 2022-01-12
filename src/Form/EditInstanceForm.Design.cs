using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace VRChatRejoinTool.Form {
	partial class EditInstanceForm {
		void initializeComponent() {
			const int
				textBoxW = 320,
				margin	= 12,
				padding	= 6;

			int curW = 0, curH = 0;
			Assembly execAsm = Assembly.GetExecutingAssembly();

			/*\
			|*| Contextmenu Initialization
			\*/
			this.components				= new Container();
			this.instanceIdContextMenu	= new ContextMenuStrip(components);
			this.copyLaunchInstanceLink	= new ToolStripMenuItem();
			this.copyInstanceLink		= new ToolStripMenuItem();
			this.saveLaunchInstanceLink	= new ToolStripMenuItem();
			this.saveInstanceLink		= new ToolStripMenuItem();

			this.instanceIdContextMenu.SuspendLayout();

			this.copyInstanceLink.Text			= "Copy Instance (https://) Link (&C)";
			this.copyInstanceLink.Click			+= new EventHandler(copyInstanceLinkClick);
			this.copyInstanceLink.ShortcutKeys	= Keys.Control | Keys.C;

			this.copyLaunchInstanceLink.Text 			= "Copy Instance (vrchat://) Link (&V)";
			this.copyLaunchInstanceLink.Click			+= new EventHandler(copyLaunchInstanceLinkClick);
			this.copyLaunchInstanceLink.ShortcutKeys	= Keys.Control | Keys.Shift | Keys.C;

			this.saveLaunchInstanceLink.Text			= "Save Instance (vrchat://) Shortcut (&S)";
			this.saveLaunchInstanceLink.Click			+= new EventHandler(saveLaunchInstanceLinkClick);
			this.saveLaunchInstanceLink.ShortcutKeys	= Keys.Control | Keys.S;

			this.saveInstanceLink.Text			= "Save Instance (https://) Shortcut (&S)";
			this.saveInstanceLink.Click			+= new EventHandler(saveInstanceLinkClick);
			this.saveInstanceLink.ShortcutKeys	= Keys.Control | Keys.Shift | Keys.S;

			this.instanceIdContextMenu.Opened	+= new EventHandler(openContextMenu);
			this.instanceIdContextMenu.Items.Add(this.copyLaunchInstanceLink);
			this.instanceIdContextMenu.Items.Add(this.copyInstanceLink);
			this.instanceIdContextMenu.Items.Add(this.saveLaunchInstanceLink);
			this.instanceIdContextMenu.Items.Add(this.saveInstanceLink);

			this.instanceIdContextMenu.ResumeLayout(false);

			/*\
			|*| UI Initialization
			\*/
			this.worldIdLabel		= new Label();
			this.worldId			= new TextBox();
			this.permissionLabel	= new Label();
			this.permission			= new ComboBox();
			this.regionLabel		= new Label();
			this.region				= new ComboBox();
			this.customRegion		= new TextBox();
			this.instanceName		= new TextBox();
			this.instanceNameLabel	= new Label();
			this.nonce				= new TextBox();
			this.nonceLabel			= new Label();
			this.ownerId			= new TextBox();
			this.ownerIdLabel		= new Label();
			this.instanceIdLabel	= new Label();
			this.instanceId			= new Label();
			
			this.launchVrc			= new Button();
			this.detail				= new Button();
			this.userDetail			= new Button();
			if (vrcInviteMePath != null) this.inviteMe = new Button();

			this.SuspendLayout();
			curH = padding;
			curW = margin;

			/*\
			|*| World ID
			\*/
			this.worldIdLabel.Text		= "World ID";
			this.worldIdLabel.AutoSize	= false;
			this.worldIdLabel.Location	= new Point(curW, curH);
			this.worldIdLabel.Size		= new Size(textBoxW, 18);
			this.worldIdLabel.Font		= new Font("Consolas", 12F);

			curH += this.worldIdLabel.Size.Height;
			curH += padding;

			this.worldId.Text			= this.instance.WorldId;
			this.worldId.Size			= new Size(textBoxW, 20);
			this.worldId.Font			= new Font("Consolas", 9F);
			this.worldId.Location		= new Point(curW, curH);
			this.worldId.TextChanged	+= new EventHandler(textBoxChanged);

			curH += this.worldId.Size.Height;
			curH += padding;

			/*\
			|*| Permission
			\*/
			this.permissionLabel.Text		= "Permission";
			this.permissionLabel.AutoSize	= false;
			this.permissionLabel.Location	= new Point(curW, curH);
			this.permissionLabel.Size		= new Size(textBoxW, 18);
			this.permissionLabel.Font		= new Font("Consolas", 12F);

			curH += this.permissionLabel.Size.Height;
			curH += padding;

			this.permission.DataSource				= Enum.GetValues(typeof(Permission));
			this.permission.DropDownStyle			= ComboBoxStyle.DropDownList;
			this.permission.Size					= new Size(textBoxW, 20);
			this.permission.Font					= new Font("Consolas", 9F);
			this.permission.Location				= new Point(curW, curH);
			this.permission.SelectedIndexChanged	+= new EventHandler(permissionChanged);

			curH += this.permission.Size.Height;
			curH += padding;

			/*\
			|*| Region
			\*/
			this.regionLabel.Text		= "Region";
			this.regionLabel.AutoSize	= false;
			this.regionLabel.Location	= new Point(curW, curH);
			this.regionLabel.Size		= new Size(textBoxW, 18);
			this.regionLabel.Font		= new Font("Consolas", 12F);

			curH += this.regionLabel.Size.Height;
			curH += padding;

			this.region.DataSource				= Enum.GetValues(typeof(ServerRegion));
			this.region.DropDownStyle			= ComboBoxStyle.DropDownList;
			this.region.Size					= new Size(textBoxW, 20);
			this.region.Font					= new Font("Consolas", 9F);
			this.region.Location				= new Point(curW, curH);
			this.region.SelectedIndexChanged	+= new EventHandler(regionChanged);

			curH += this.region.Size.Height;
			curH += padding;

			this.customRegion.Text			= this.instance.CustomRegion;
			this.customRegion.Size			= new Size(textBoxW, 20);
			this.customRegion.Font			= new Font("Consolas", 9F);
			this.customRegion.Location		= new Point(curW, curH);
			this.customRegion.TextChanged	+= new EventHandler(textBoxChanged);

			curH += this.customRegion.Size.Height;
			curH += padding;

			/*\
			|*| InstanceName
			\*/
			this.instanceNameLabel.Text		= "Instance Name (invalid)";
			this.instanceNameLabel.AutoSize	= false;
			this.instanceNameLabel.Location	= new Point(curW, curH);
			this.instanceNameLabel.Size		= new Size(textBoxW, 18);
			this.instanceNameLabel.Font		= new Font("Consolas", 12F);

			curH += this.instanceNameLabel.Size.Height;
			curH += padding;

			this.instanceName.Text			= this.instance.InstanceName;
			this.instanceName.Size			= new Size(textBoxW, 20);
			this.instanceName.Font			= new Font("Consolas", 9F);
			this.instanceName.Location		= new Point(curW, curH);
			this.instanceName.TextChanged	+= new EventHandler(textBoxChanged);

			curH += this.instanceName.Size.Height;
			curH += padding;

			/*\
			|*| Owner ID
			\*/
			this.ownerIdLabel.Text		= "Owner ID (invalid)";
			this.ownerIdLabel.AutoSize	= false;
			this.ownerIdLabel.Location	= new Point(curW, curH);
			this.ownerIdLabel.Size		= new Size(textBoxW, 18);
			this.ownerIdLabel.Font		= new Font("Consolas", 12F);

			curH += this.ownerIdLabel.Size.Height;
			curH += padding;

			this.ownerId.Text			= this.instance.OwnerId;
			this.ownerId.Size			= new Size(textBoxW, 20);
			this.ownerId.Font			= new Font("Consolas", 9F);
			this.ownerId.Location		= new Point(curW, curH);
			this.ownerId.TextChanged	+= new EventHandler(textBoxChanged);

			curH += this.ownerId.Size.Height;
			curH += padding;

			/*\
			|*| Nonce
			\*/
			this.nonceLabel.Text		= "Nonce (invalid)";
			this.nonceLabel.AutoSize	= false;
			this.nonceLabel.Location	= new Point(curW, curH);
			this.nonceLabel.Size		= new Size(textBoxW, 18);
			this.nonceLabel.Font		= new Font("Consolas", 12F);
			this.nonceLabel.DoubleClick	+= new EventHandler(nonceLabelDoubleClick);

			curH += this.nonceLabel.Size.Height;
			curH += padding;

			this.nonce.Text			= this.instance.Nonce;
			this.nonce.Size			= new Size(textBoxW, 20);
			this.nonce.Font			= new Font("Consolas", 9F);
			this.nonce.Location		= new Point(curW, curH);
			this.nonce.TextChanged	+= new EventHandler(textBoxChanged);

			curH += this.nonce.Size.Height;
			curH += padding;

			/*\
			
			|*| Instance Id
			\*/
			this.instanceIdLabel.Text		= "Instance ID";
			this.instanceIdLabel.AutoSize	= false;
			this.instanceIdLabel.Location	= new Point(curW, curH);
			this.instanceIdLabel.Size		= new Size(textBoxW, 18);
			this.instanceIdLabel.Font		= new Font("Consolas", 12F);
		
			curH += this.instanceIdLabel.Size.Height;
			curH += padding;

			this.instanceId.Text		= "wrld_xxx:12345~public";
			this.instanceId.AutoSize	= false;
			this.instanceId.Location	= new Point(curW, curH);
			this.instanceId.Size		= new Size(textBoxW, 75);
			this.instanceId.Font		= new Font("Consolas", 9F);

			curH += this.instanceId.Size.Height;
			curH += padding;

			/*\
			|*| Buttons
			\*/
			this.launchVrc.Text			= "Launch (&L)";
			this.launchVrc.Location		= new Point(curW, curH);
			this.launchVrc.Size			= new Size(75, 23);
			this.launchVrc.Click		+= new EventHandler(launchVrcButtonClick);
			this.launchVrc.UseMnemonic	= true;

			curW += this.launchVrc.Size.Width;
			curW += padding;

			if (vrcInviteMePath != null) {
				// FIXME: (&I) will not shown if netcoreapp3.1
				this.inviteMe.Text			= "Invite Me (&I)";
				this.inviteMe.Location		= new Point(curW, curH);
				this.inviteMe.Size			= new Size(75, 23);
				this.inviteMe.Click			+= new EventHandler(inviteMeButtonClick);
				this.inviteMe.UseMnemonic	= true;

				curW += this.inviteMe.Size.Width;
				curW += padding;
			}

			this.detail.Text		= "Detail (&D)";
			this.detail.Location	= new Point(curW, curH);
			this.detail.Size		= new Size(75, 23);
			this.detail.Click		+= new EventHandler(detailButtonClick);
			this.detail.UseMnemonic	= true;

			curW += this.detail.Size.Width;
			curW += padding;

			this.userDetail.Text		= "User (&U)";
			this.userDetail.Location	= new Point(curW, curH);
			this.userDetail.Size		= new Size(75, 23);
			this.userDetail.Click		+= new EventHandler(userDetailButtonClick);
			this.userDetail.UseMnemonic	= true;

			curW = margin;
			curH += this.launchVrc.Size.Height;
			curH += padding;

			/*\
			|*| Form
			\*/
			this.Text				= "Edit Instance - VRChat RejoinTool";

#if NETCOREAPP
			this.ClientSize			= new Size(textBoxW + (margin * 2), curH);
#else
			// net framework special fix
			this.ClientSize			= new Size(textBoxW + (margin * 2) - 10, curH - 10);
#endif

			this.MinimumSize		= this.Size;
			this.MaximumSize		= this.Size;
			this.FormBorderStyle	= FormBorderStyle.FixedSingle;
			this.Icon				= new Icon(execAsm.GetManifestResourceStream("icon"));
			this.ContextMenuStrip	= instanceIdContextMenu;
			this.KeyDown			+= new KeyEventHandler(windowKeyDown);
			this.KeyPreview			= true;

			this.Controls.Add(this.worldIdLabel);
			this.Controls.Add(this.worldId);
			this.Controls.Add(this.permissionLabel);
			this.Controls.Add(this.permission);
			this.Controls.Add(this.regionLabel);
			this.Controls.Add(this.region);
			this.Controls.Add(this.customRegion);
			this.Controls.Add(this.instanceNameLabel);
			this.Controls.Add(this.instanceName);
			this.Controls.Add(this.ownerIdLabel);
			this.Controls.Add(this.ownerId);
			this.Controls.Add(this.nonceLabel);
			this.Controls.Add(this.nonce);
			
			this.Controls.Add(this.instanceId);
			this.Controls.Add(this.instanceIdLabel);
			this.Controls.Add(this.instanceId);
			this.Controls.Add(this.launchVrc);
			if (vrcInviteMePath != null) this.Controls.Add(this.inviteMe);
			this.Controls.Add(this.detail);
			this.Controls.Add(this.userDetail);

			this.ResumeLayout(false);
		}
	}
}

