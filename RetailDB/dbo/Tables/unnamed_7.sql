ALTER TABLE [dbo].[Rate]  WITH CHECK ADD FOREIGN KEY([Seller_id])
REFERENCES [dbo].[Seller] ([Seller_id])