ALTER TABLE [dbo].[Commodity_rate]  WITH CHECK ADD FOREIGN KEY([Comm_id])
REFERENCES [dbo].[Comment] ([Comm_id])