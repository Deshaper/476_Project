ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([Commo_id])
REFERENCES [dbo].[Commodity] ([Commo_id])