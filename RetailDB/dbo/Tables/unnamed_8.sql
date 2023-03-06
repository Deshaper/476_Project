ALTER TABLE [dbo].[Recipt]  WITH CHECK ADD FOREIGN KEY([Cho_id])
REFERENCES [dbo].[Check_out] ([Cho_id])