ALTER TABLE [dbo].[Stock]  WITH CHECK ADD FOREIGN KEY([Commo_id])
REFERENCES [dbo].[Commodity] ([Commo_id])