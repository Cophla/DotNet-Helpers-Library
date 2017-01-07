using System;
using System.Drawing;

namespace CodeHelpers.System.Drawing
{
	public static class SImage
	{
		#region Public Methods

		public static Image CreateThumb(this Image originalImage, int size)
		{
			Image thumbImage = null;
			using (Image mainImg = (Image)originalImage.Clone())
			{
				int maxSize = size;

				int w = mainImg.Width;
				int h = mainImg.Height;

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

				using (Bitmap myBitmap = new Bitmap(mainImg))
				{
					thumbImage = myBitmap.GetThumbnailImage(
						w, h, new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero
					);
				}
			}

			return thumbImage;
		}

		public static Image CreateThumbThenDispose(this Image originalImage, int size)
		{
			Image thumbImage = null;
			using (originalImage)
			{
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

				using (Bitmap myBitmap = new Bitmap(originalImage))
				{
					thumbImage = myBitmap.GetThumbnailImage(
						w, h, new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero
					);
				}
			}

			return thumbImage;
		}

		#endregion Public Methods
	}
}