using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CodeHelpers.System.Drawing
{
	public static class SImage
	{
		#region Public Methods

		public static Image CreateThumb(this Image originalImage, int size)
		{
			return CreateThumb(originalImage, size, 80);
		}

		public static Image CreateThumb(this Image originalImage, int size, int quality)
		{
			if (quality.IsNotBetween(0, 100))
				throw new ArgumentOutOfRangeException(
					nameof(quality), "Quality value must be between 0 and 100.");

			// JPEG image codec
			ImageCodecInfo imgCodec = GetImageEncoder(originalImage.RawFormat);
			Image thumbImage = null;
			using (EncoderParameters encoderParams = new EncoderParameters(1))
			{
				// Encoder parameter for image quality
				encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);

				int maxSize = size;

				int w = originalImage.Width;
				int h = originalImage.Height;

				if (w > maxSize)
				{
					h = (h * maxSize) / w;
					w = maxSize;
				}

				if (h > maxSize)
				{
					w = (w * maxSize) / h;
					h = maxSize;
				}

				thumbImage = originalImage.GetThumbnailImage(
					w, h, new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero
				);
			}

			return thumbImage;
		}

		public static ImageCodecInfo GetImageEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs)
				if (codec.FormatID == format.Guid)
					return codec;
			return null;
		}

		public static void SignateOnImage(string orgImagePath, string newImagePath, string signateImagePath)
		{
			using (Image signateImage = new Bitmap(signateImagePath))
			{
				SignateOnImage(orgImagePath, newImagePath, signateImage);
			}
		}

		public static void SignateOnImage(string orgImagePath, string newImagePath, Image signateImage)
		{
			using (Image orgImage = new Bitmap(orgImagePath))
			using (Graphics graphicImage = Graphics.FromImage(orgImage))
			{
				graphicImage.SmoothingMode = SmoothingMode.HighSpeed;
				int logoWidth = (30 * orgImage.Width) / 100;
				int logoHeight = (30 * orgImage.Height) / 100;
				int logoMax = (logoWidth >= logoHeight ? logoHeight : logoWidth);
				using (Image newSignateImage = CreateThumb(signateImage, logoMax))
				{
					int rectX = ((int)((1.5 * orgImage.Width) / 100));
					int rectY = orgImage.Height - (15 * orgImage.Height) / 100;
					Rectangle drect = new Rectangle(
						rectX, rectY, newSignateImage.Width, newSignateImage.Height);
					graphicImage.DrawImage(newSignateImage, drect);
					orgImage.Save(newImagePath, orgImage.RawFormat);
				}
			}
		}

		#endregion Public Methods
	}
}