<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Assign_Students_To_Class.aspx.cs" Inherits="FPY_Homework_Management.Teacher_Assign_Students_To_Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assign To Class</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
</head>
<body>
        <div>
            <form id="frmAssignToClass" runat="server">
                <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>--%>
                <%--<asp:SqlDataSource ID="ViewAllStudents" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [StudentID], [StudentFirstName], [StudentLastName], [StudentUsername] FROM [Students] ORDER BY [StudentFirstName] DESC, [StudentLastName] DESC"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="ViewAllStudents" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentFirstName, StudentLastName, StudentUsername FROM Students ORDER BY StudentFirstName DESC, StudentLastName DESC"></asp:SqlDataSource>

            

                <%--<asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT [ClassID], [ClassTeacherID], [ClassSubject], [ClassYearGroup], [ClassName] FROM [Class] ORDER BY [ClassName] DESC"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="ViewAllClasses" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT * FROM Class ORDER BY ClassName DESC"></asp:SqlDataSource>

                <div class="row" style="width:20%; padding-left:5%; padding-right:5%; padding-bottom:10px; padding-top:25px">                
                    <span style="font-weight:bold">Class*</span><br/>
                    <asp:DropDownList ID="drpSelectClass" runat="server" DataSourceID="ViewAllClasses" DataTextField="ClassName" DataValueField="ClassID" class="custom-select"></asp:DropDownList>
                    <asp:Button ID="btnSelectClass" runat="server" Text="Select" OnClick="btnSelectClass_Click"/>
                </div>
                
                <br/>

                <!-- students in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where (selected ClassID) == StudentsInClass.ClassID -->
                
                <!-- students not in selected class -->
                <!-- select student.username, student.name, StudentsInClass.ClassID from student join studentsInClass where StudentsInClass.ClassID != (selected ClassID) -->
                

                <div id="gridViews">

                <span style="font-weight:bold">Students Not In Selected Class</span><br/>
                <asp:GridView ID="allOtherStudents" DataSourceID="ViewAllStudentsNotInClass" runat="server" DataKeyNames="StudentID" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="StudentID" ReadOnly="true"/>
                        <asp:BoundField DataField="StudentUsername" HeaderText="Student Username" ReadOnly="true" SortExpression="StudentUsername"/>
                        <asp:BoundField DataField="StudentFirstName" HeaderText="Student First Name" ReadOnly="true" SortExpression="StudentFirstName"/>
                        <asp:BoundField DataField="StudentLastName" HeaderText="Student Last Name" ReadOnly="true" SortExpression="StudentLastName"/>
                        <asp:BoundField DataField="StudentDOB" HeaderText="Student DOB" ReadOnly="true" SortExpression="StudentDOB"/>
                        <%--<asp:ButtonField HeaderText="Add Student to class" Text="Add" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Add Student To Class" ShowHeader="True" Text="Add" ItemStyle-HorizontalAlign="Center" />--%>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" HeaderText="Add Student To Class" ShowHeader="True" Text="Add" ItemStyle-HorizontalAlign="Center" CommandArgument="Container.DataItemIndex" />  <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView><br/><br/>
                
                <span style="font-weight:bold">Students In Selected Class</span><br/>
                <asp:GridView ID="allStudentsInClass" DataSourceID="ViewAllStudentsInClass" runat="server" DataKeyNames="StudentID" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="StudentID" ReadOnly="true"/>
                        <asp:BoundField DataField="StudentUsername" HeaderText="Student Username" ReadOnly="true" SortExpression="StudentUsername"/>
                        <asp:BoundField DataField="StudentFirstName" HeaderText="Student First Name" ReadOnly="true" SortExpression="StudentFirstName"/>
                        <asp:BoundField DataField="StudentLastName" HeaderText="Student Last Name" ReadOnly="true" SortExpression="StudentLastName"/>
                        <asp:BoundField DataField="StudentDOB" HeaderText="Student DOB" ReadOnly="true" SortExpression="StudentDOB"/>
                        <%--<asp:ButtonField HeaderText="Remove Student from class" Text="Remove" />--%>
                        <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Remove Student From Class" ShowHeader="True" Text="Remove" ItemStyle-HorizontalAlign="Center" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>                                
                                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" CommandName="Select" HeaderText="Remove Student From Class" ShowHeader="True" Text="Remove" ItemStyle-HorizontalAlign="Center" /> <%--CommandArgument="Container.DataItemIndex"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                </div>

                <asp:SqlDataSource ID="ViewAllStudentsNotInClass" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students"></asp:SqlDataSource>
                <asp:SqlDataSource ID="ViewAllStudentsInClass" runat="server" ConnectionString="<%$ ConnectionStrings:PRCO304_CHarding %>" SelectCommand="SELECT StudentID, StudentUsername, StudentFirstName, StudentLastName, StudentDOB FROM Students"></asp:SqlDataSource>



            </form>
        </div>
</body>
</html>
