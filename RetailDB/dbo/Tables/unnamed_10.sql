ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD FOREIGN KEY([Pur_id])
REFERENCES [dbo].[Purchased] ([Pur_id])