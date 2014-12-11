<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_questions.aspx.cs" Inherits="admin_questions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Names = "Arial"
Font-Size = "11pt" AlternatingRowStyle-BackColor = "LightGray" 
HeaderStyle-BackColor = "Gray"  ShowFooter = "true" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" 
>
            <Columns>
                <asp:TemplateField HeaderText = "Q.ID">
                    <ItemTemplate>
                        <asp:Label ID="q_id" runat="server" Text='<%# Eval("que_id") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                         <asp:Button ID="add_new" runat="server" Text="ADD" OnClick="add_question" />
                     </FooterTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText = "Question">
                    <ItemTemplate>
                        <asp:Label ID="q_question" runat="server" Text='<%# Eval("question") %>'></asp:Label>
                    </ItemTemplate>
                     <EditItemTemplate>
                   <asp:TextBox ID="e_question" runat="server" Text='<%# Eval("question") %>'></asp:TextBox>
                    </EditItemTemplate> 

                     <FooterTemplate>
                         <asp:TextBox ID="question" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Option A">
                    <ItemTemplate>
                        <asp:Label ID="q_option1" runat="server" Text='<%# Eval("option1") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="e_option1" runat="server" Text='<%# Eval("option1") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="option1" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Option B">
                    <ItemTemplate>
                        <asp:Label ID="q_option2" runat="server" Text='<%# Eval("option2") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="e_option2" runat="server" Text='<%# Eval("option2") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="option2" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Option C">
                    <ItemTemplate>
                        <asp:Label ID="q_option3" runat="server" Text='<%# Eval("option3") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="e_option3" runat="server" Text='<%# Eval("option3") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="option3" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Option D">
                    <ItemTemplate>
                        <asp:Label ID="q_option4" runat="server" Text='<%# Eval("option4") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="e_option4" runat="server" Text='<%# Eval("option4") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="option4" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Answer">
                    <ItemTemplate>
                        <asp:Label ID="q_answer" runat="server" Text='<%# Eval("answer") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="e_answer" runat="server" Text='<%# Eval("answer") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="answer" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText = "Category">
                    <ItemTemplate>
                        <asp:Label ID="q_category" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                    </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="e_category" runat="server" Text='<%# Eval("category") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="category" runat="server"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "isDeleted">
                    <ItemTemplate>
                        <asp:CheckBox ID="q_isdeleted" runat="server" Checked='<%# Eval("isDeleted") %>' />
                    </ItemTemplate>
                     <EditItemTemplate>
                        <asp:CheckBox ID="e_isdeleted" runat="server" Checked='<%# Eval("isDeleted") %>' />
                    </EditItemTemplate>
                     <FooterTemplate>
                         <asp:CheckBox ID="isdeleted" runat="server" />
                     </FooterTemplate>
                </asp:TemplateField>

                <asp:CommandField  ShowEditButton="True" />
                <asp:CommandField sh
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
