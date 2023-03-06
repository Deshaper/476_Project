ALTER TABLE [dbo].[Check_out]  WITH CHECK ADD FOREIGN KEY([Cus_id])
REFERENCES [dbo].[Customer] ([Cus_id])