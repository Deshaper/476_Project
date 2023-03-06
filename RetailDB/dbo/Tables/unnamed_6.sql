ALTER TABLE [dbo].[Purchased]  WITH CHECK ADD FOREIGN KEY([Cus_id])
REFERENCES [dbo].[Customer] ([Cus_id])