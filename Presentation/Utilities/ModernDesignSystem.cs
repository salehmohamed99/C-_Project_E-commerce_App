using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentation.Utilities
{
    /// <summary>
    /// Unified Design System for professional, consistent UI across all forms
    /// </summary>
    public static class ModernDesignSystem
    {
        // ??????????????????????????????????????????????????????????????????
        //  COLOR PALETTE - Professional & Consistent
        // ??????????????????????????????????????????????????????????????????
        public static class Colors
        {
            // Primary Colors
            public static readonly Color Primary = Color.FromArgb(99, 102, 241);      // Indigo
            public static readonly Color PrimaryDark = Color.FromArgb(79, 70, 229);
            public static readonly Color PrimaryLight = Color.FromArgb(129, 140, 248);

            // Backgrounds
            public static readonly Color DarkBackground = Color.FromArgb(15, 17, 26);
            public static readonly Color CardBackground = Color.White;
            public static readonly Color ContentBackground = Color.FromArgb(243, 245, 250);
            public static readonly Color HoverBackground = Color.FromArgb(248, 249, 252);
            public static readonly Color ActiveBackground = Color.FromArgb(28, 32, 48);

            // Text Colors
            public static readonly Color TextPrimary = Color.FromArgb(17, 24, 39);
            public static readonly Color TextSecondary = Color.FromArgb(107, 114, 128);
            public static readonly Color TextMuted = Color.FromArgb(156, 163, 175);
            public static readonly Color TextLight = Color.White;

            // Status Colors
            public static readonly Color Success = Color.FromArgb(34, 197, 94);
            public static readonly Color SuccessLight = Color.FromArgb(220, 252, 231);
            public static readonly Color Warning = Color.FromArgb(251, 146, 60);
            public static readonly Color WarningLight = Color.FromArgb(254, 243, 199);
            public static readonly Color Danger = Color.FromArgb(239, 68, 68);
            public static readonly Color DangerLight = Color.FromArgb(254, 226, 226);
            public static readonly Color Info = Color.FromArgb(59, 130, 246);
            public static readonly Color InfoLight = Color.FromArgb(224, 242, 254);

            // Grid Colors
            public static readonly Color GridHeader = Color.FromArgb(248, 249, 252);
            public static readonly Color GridAltRow = Color.FromArgb(250, 251, 254);
            public static readonly Color GridSelection = Color.FromArgb(238, 242, 255);
            public static readonly Color GridBorder = Color.FromArgb(229, 231, 235);
        }

        // ??????????????????????????????????????????????????????????????????
        //  TYPOGRAPHY - Consistent Font Styles
        // ??????????????????????????????????????????????????????????????????
        public static class Typography
        {
            public static Font H1 => new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            public static Font H2 => new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            public static Font H3 => new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            public static Font H4 => new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            
            public static Font Body => new Font("Segoe UI", 10F);
            public static Font BodyLarge => new Font("Segoe UI", 11F);
            public static Font BodySmall => new Font("Segoe UI", 9F);
            
            public static Font Button => new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            public static Font ButtonLarge => new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            
            public static Font Grid => new Font("Segoe UI", 9.5F);
            public static Font GridHeader => new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            
            public static Font Label => new Font("Segoe UI", 9.5F);
            public static Font LabelSmall => new Font("Segoe UI", 8.5F);
        }

        // ??????????????????????????????????????????????????????????????????
        //  SPACING - Consistent Margins & Padding
        // ??????????????????????????????????????????????????????????????????
        public static class Spacing
        {
            public const int XSmall = 4;
            public const int Small = 8;
            public const int Medium = 16;
            public const int Large = 24;
            public const int XLarge = 32;
            public const int XXLarge = 48;
        }

        // ??????????????????????????????????????????????????????????????????
        //  BUTTON STYLES - Reusable Button Configurations
        // ??????????????????????????????????????????????????????????????????
        public static class Buttons
        {
            public static void ApplyPrimaryStyle(Button btn, string text = "", int width = 140, int height = 44)
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Size = new Size(width, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Colors.Primary;
                btn.ForeColor = Colors.TextLight;
                btn.Font = Typography.Button;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Colors.PrimaryDark;
                ApplyRoundedCorners(btn, 8);
            }

            public static void ApplySecondaryStyle(Button btn, string text = "", int width = 140, int height = 44)
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Size = new Size(width, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Colors.CardBackground;
                btn.ForeColor = Colors.TextPrimary;
                btn.Font = Typography.Button;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Colors.GridBorder;
                btn.FlatAppearance.MouseOverBackColor = Colors.HoverBackground;
                ApplyRoundedCorners(btn, 8);
            }

            public static void ApplySuccessStyle(Button btn, string text = "", int width = 140, int height = 44)
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Size = new Size(width, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Colors.Success;
                btn.ForeColor = Colors.TextLight;
                btn.Font = Typography.Button;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
                ApplyRoundedCorners(btn, 8);
            }

            public static void ApplyDangerStyle(Button btn, string text = "", int width = 140, int height = 44)
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Size = new Size(width, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Colors.Danger;
                btn.ForeColor = Colors.TextLight;
                btn.Font = Typography.Button;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
                ApplyRoundedCorners(btn, 8);
            }

            public static void ApplyWarningStyle(Button btn, string text = "", int width = 140, int height = 44)
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Size = new Size(width, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Colors.Warning;
                btn.ForeColor = Colors.TextLight;
                btn.Font = Typography.Button;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 88, 12);
                ApplyRoundedCorners(btn, 8);
            }

            public static void ApplyLinkStyle(Button btn, string text = "")
            {
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Colors.Primary;
                btn.Font = Typography.Body;
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.MouseEnter += (s, e) => btn.ForeColor = Colors.PrimaryDark;
                btn.MouseLeave += (s, e) => btn.ForeColor = Colors.Primary;
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  INPUT STYLES - TextBox & ComboBox Styling
        // ??????????????????????????????????????????????????????????????????
        public static class Inputs
        {
            public static void ApplyModernStyle(TextBox txt, string placeholder = "")
            {
                txt.Font = Typography.Body;
                txt.BackColor = Colors.CardBackground;
                txt.ForeColor = Colors.TextPrimary;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Height = 36;
                
                if (!string.IsNullOrEmpty(placeholder))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Colors.TextMuted;
                    txt.GotFocus += (s, e) =>
                    {
                        if (txt.Text == placeholder)
                        {
                            txt.Text = "";
                            txt.ForeColor = Colors.TextPrimary;
                        }
                    };
                    txt.LostFocus += (s, e) =>
                    {
                        if (string.IsNullOrWhiteSpace(txt.Text))
                        {
                            txt.Text = placeholder;
                            txt.ForeColor = Colors.TextMuted;
                        }
                    };
                }
            }

            public static void ApplyModernStyle(ComboBox cmb)
            {
                cmb.Font = Typography.Body;
                cmb.BackColor = Colors.CardBackground;
                cmb.ForeColor = Colors.TextPrimary;
                cmb.FlatStyle = FlatStyle.Flat;
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb.Height = 36;
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  PANEL STYLES - Cards & Containers
        // ??????????????????????????????????????????????????????????????????
        public static class Panels
        {
            public static void ApplyCardStyle(Panel pnl, int radius = 12)
            {
                pnl.BackColor = Colors.CardBackground;
                ApplyRoundedCorners(pnl, radius);
                AddShadow(pnl);
            }

            public static void ApplyStatCardStyle(Panel pnl, Color iconColor, string icon, string title, string value)
            {
                pnl.BackColor = Colors.CardBackground;
                pnl.Size = new Size(240, 120);
                ApplyRoundedCorners(pnl, 12);
                AddShadow(pnl);

                var lblIcon = new Label
                {
                    Text = icon,
                    Font = new Font("Segoe UI Symbol", 28F),
                    ForeColor = iconColor,
                    AutoSize = true,
                    Location = new Point(20, 20)
                };

                var lblTitle = new Label
                {
                    Text = title,
                    Font = Typography.BodySmall,
                    ForeColor = Colors.TextSecondary,
                    AutoSize = true,
                    Location = new Point(20, 70)
                };

                var lblValue = new Label
                {
                    Text = value,
                    Font = Typography.H2,
                    ForeColor = Colors.TextPrimary,
                    AutoSize = true,
                    Location = new Point(140, 35)
                };

                pnl.Controls.AddRange(new Control[] { lblIcon, lblTitle, lblValue });
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  DATA GRID STYLES - Professional Grid Styling
        // ??????????????????????????????????????????????????????????????????
        public static class Grids
        {
            public static void ApplyModernStyle(DataGridView dgv)
            {
                dgv.BackgroundColor = Colors.CardBackground;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = Colors.GridBorder;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.ColumnHeadersHeight = 48;
                dgv.RowTemplate.Height = 56;
                dgv.EnableHeadersVisualStyles = false;
                
                // Enable horizontal scrollbar if needed
                dgv.ScrollBars = ScrollBars.Both;

                dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Colors.GridHeader,
                    ForeColor = Colors.TextSecondary,
                    Font = Typography.GridHeader,
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(Spacing.Medium, 0, 0, 0),
                    SelectionBackColor = Colors.GridHeader,
                    SelectionForeColor = Colors.TextSecondary
                };

                dgv.DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = Typography.Grid,
                    Padding = new Padding(Spacing.Medium, 0, Spacing.Medium, 0),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    SelectionBackColor = Colors.GridSelection,
                    SelectionForeColor = Colors.TextPrimary,
                    ForeColor = Colors.TextPrimary,
                    BackColor = Colors.CardBackground
                };

                dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Colors.GridAltRow,
                    SelectionBackColor = Colors.GridSelection,
                    SelectionForeColor = Colors.TextPrimary,
                    ForeColor = Colors.TextPrimary
                };
            }

            /// <summary>
            /// Makes DataGridView responsive by adjusting to parent size
            /// </summary>
            public static void MakeResponsive(DataGridView dgv, int margin = 24)
            {
                if (dgv.Parent == null) return;

                dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                dgv.Width = dgv.Parent.Width - (margin * 2);
                dgv.Height = dgv.Parent.Height - dgv.Top - margin;
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  FORM UTILITIES - Common Form Operations
        // ??????????????????????????????????????????????????????????????????
        public static class Forms
        {
            public static void ApplyModernFormStyle(Form form, string title, int width = 1200, int height = 700)
            {
                form.Text = title;
                form.Size = new Size(width, height);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BackColor = Colors.ContentBackground;
                form.Font = Typography.Body;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.MinimumSize = new Size(800, 600);
            }

            public static Panel CreateHeader(string title, string subtitle = "")
            {
                var pnl = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = string.IsNullOrEmpty(subtitle) ? 80 : 100,
                    BackColor = Colors.DarkBackground
                };

                var pnlAccent = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 3,
                    BackColor = Colors.Primary
                };
                pnl.Controls.Add(pnlAccent);

                var lblIcon = new Label
                {
                    Text = "?",
                    Font = new Font("Segoe UI", 20F),
                    ForeColor = Colors.Primary,
                    Location = new Point(Spacing.Large, 20),
                    AutoSize = true
                };

                var lblTitle = new Label
                {
                    Text = title,
                    Font = Typography.H3,
                    ForeColor = Colors.TextLight,
                    Location = new Point(Spacing.Large + 40, 25),
                    AutoSize = true
                };

                pnl.Controls.AddRange(new Control[] { lblIcon, lblTitle });

                if (!string.IsNullOrEmpty(subtitle))
                {
                    var lblSubtitle = new Label
                    {
                        Text = subtitle,
                        Font = Typography.BodySmall,
                        ForeColor = Colors.TextMuted,
                        Location = new Point(Spacing.Large + 40, 55),
                        AutoSize = true
                    };
                    pnl.Controls.Add(lblSubtitle);
                }

                return pnl;
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  VISUAL EFFECTS - Shadows & Rounded Corners
        // ??????????????????????????????????????????????????????????????????
        public static void ApplyRoundedCorners(Control ctrl, int radius)
        {
            try
            {
                var path = new GraphicsPath();
                int d = radius * 2;
                var rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
                path.CloseFigure();

                ctrl.Region = new Region(path);
            }
            catch { /* Fallback to square corners */ }
        }

        private static void AddShadow(Control ctrl)
        {
            // Note: Windows Forms doesn't support native drop shadows
            // This is a visual indicator placeholder
            // For real shadows, consider using a custom paint or third-party libraries
        }

        // ??????????????????????????????????????????????????????????????????
        //  MESSAGE BOXES - Styled Notifications
        // ??????????????????????????????????????????????????????????????????
        public static class Messages
        {
            public static void ShowSuccess(string message, string title = "Success")
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static void ShowError(string message, string title = "Error")
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            public static void ShowWarning(string message, string title = "Warning")
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public static DialogResult ShowConfirmation(string message, string title = "Confirm")
            {
                return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        // ??????????????????????????????????????????????????????????????????
        //  RESPONSIVE UTILITIES - Helper for Responsive Design
        // ??????????????????????????????????????????????????????????????????
        public static class Responsive
        {
            /// <summary>
            /// Makes a control fill its parent with specified margins
            /// </summary>
            public static void FillParent(Control control, int margin = 24)
            {
                if (control.Parent == null) return;

                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                control.Location = new Point(margin, control.Top);
                control.Width = control.Parent.Width - (margin * 2);
                control.Height = control.Parent.Height - control.Top - margin;
            }

            /// <summary>
            /// Centers a control horizontally in its parent
            /// </summary>
            public static void CenterHorizontally(Control control)
            {
                if (control.Parent == null) return;
                control.Left = (control.Parent.Width - control.Width) / 2;
            }

            /// <summary>
            /// Adjusts font size based on form size
            /// </summary>
            public static Font GetResponsiveFont(int formWidth, Font baseFont)
            {
                float scale = formWidth < 1000 ? 0.9f : formWidth > 1500 ? 1.1f : 1.0f;
                return new Font(baseFont.FontFamily, baseFont.Size * scale, baseFont.Style);
            }
        }
    }
}
