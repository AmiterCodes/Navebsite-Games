<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityList.ascx.cs" Inherits="Navebsite.Controls.ActivityList" %>

<div class="activities">
ACTIVITY
<asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="20"
           CellSpacing="20"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="1"
           runat="server"
                CssClass="activity_list">


               
         <ItemTemplate>
             <div class="activity">
                 <div class="activity_text"><%# DataBinder.Eval(Container.DataItem, "ActivityText") %></div>
                
                <div class="activity_time"><%# DataBinder.Eval(Container.DataItem, "Timestamp") %></div>
                
             </div>
         </ItemTemplate>
 
      </asp:DataList>
    </div>