using System;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
	// Token: 0x0200000F RID: 15
	public static class Render
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00007722 File Offset: 0x00005922
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00007729 File Offset: 0x00005929
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00007731 File Offset: 0x00005931
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00007738 File Offset: 0x00005938
		public static Color Color
		{
			get
			{
				return GUI.color;
			}
			set
			{
				GUI.color = value;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00007740 File Offset: 0x00005940
		public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawLine(from, to, thickness);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00007750 File Offset: 0x00005950
		public static void DrawLine(Vector2 from, Vector2 to, float thickness)
		{
			Vector2 normalized = (to - from).normalized;
			float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
			GUIUtility.RotateAroundPivot(num, from);
			Render.DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
			GUIUtility.RotateAroundPivot(-num, from);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000077B4 File Offset: 0x000059B4
		public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), 1f, color);
			Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), 1f, color);
			Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), 1f, color);
			Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), 1f, color);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00007839 File Offset: 0x00005A39
		public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawBox(position, size, thickness, centered);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000784C File Offset: 0x00005A4C
		public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
		{
			if (centered)
			{
				position - size / 2f;
			}
			GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007906 File Offset: 0x00005B06
		public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawCross(position, size, thickness);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00007918 File Offset: 0x00005B18
		public static void DrawCross(Vector2 position, Vector2 size, float thickness)
		{
			GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00007983 File Offset: 0x00005B83
		public static void DrawDot(Vector2 position, Color color)
		{
			Render.Color = color;
			Render.DrawDot(position);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007991 File Offset: 0x00005B91
		public static void DrawDot(Vector2 position)
		{
			Render.DrawBox(position - Vector2.one, Vector2.one * 2f, 1f, true);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000079B8 File Offset: 0x00005BB8
		public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawString(position, label, centered);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000079C8 File Offset: 0x00005BC8
		public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			GUIContent guicontent = new GUIContent(label);
			Vector2 vector = Render.StringStyle.CalcSize(guicontent);
			GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), guicontent);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007A0B File Offset: 0x00005C0B
		public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
		{
			Render.DrawCircle(position, radius, numSides, Color.white, centered, thickness);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00007A20 File Offset: 0x00005C20
		public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
		{
			Render.RingArray ringArray;
			if (Render.ringDict.ContainsKey(numSides))
			{
				ringArray = Render.ringDict[numSides];
			}
			else
			{
				ringArray = (Render.ringDict[numSides] = new Render.RingArray(numSides));
			}
			Vector2 vector = centered ? position : (position + Vector2.one * radius);
			for (int i = 0; i < numSides - 1; i++)
			{
				Render.DrawLine(vector + ringArray.Positions[i] * radius, vector + ringArray.Positions[i + 1] * radius, thickness, color);
			}
			Render.DrawLine(vector + ringArray.Positions[0] * radius, vector + ringArray.Positions[ringArray.Positions.Length - 1] * radius, thickness, color);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00007B00 File Offset: 0x00005D00
		public static void DrawSnapline(Vector3 worldpos, Color color)
		{
			Vector3 vector = Main.MainCamera.WorldToScreenPoint(worldpos);
			vector.y = (float)Screen.height - vector.y;
			GL.PushMatrix();
			GL.Begin(1);
			Render.DrawMaterial.SetPass(0);
			GL.Color(color);
			GL.Vertex3((float)(Screen.width / 2), (float)Screen.height, 0f);
			GL.Vertex3(vector.x, vector.y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x0400005B RID: 91
		public static Material DrawMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));

		// Token: 0x0400005D RID: 93
		private static Dictionary<int, Render.RingArray> ringDict = new Dictionary<int, Render.RingArray>();

		// Token: 0x02000023 RID: 35
		private class RingArray
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000EC RID: 236 RVA: 0x00034908 File Offset: 0x00032B08
			// (set) Token: 0x060000ED RID: 237 RVA: 0x00034910 File Offset: 0x00032B10
			public Vector2[] Positions { get; private set; }

			// Token: 0x060000EE RID: 238 RVA: 0x0003491C File Offset: 0x00032B1C
			public RingArray(int numSegments)
			{
				this.Positions = new Vector2[numSegments];
				float num = 360f / (float)numSegments;
				for (int i = 0; i < numSegments; i++)
				{
					float num2 = 0.017453292f * num * (float)i;
					this.Positions[i] = new Vector2(Mathf.Sin(num2), Mathf.Cos(num2));
				}
			}
		}
	}
}
