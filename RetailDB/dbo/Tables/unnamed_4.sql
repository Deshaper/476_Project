ALTER TABLE [dbo].[Commodity]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[Categories] ([Category])