using System;
using UnityEditor;
using UnityEngine;

namespace UniNotNullChecker
{
	/// <summary>
	/// 設定を管理するクラス
	/// </summary>
	[Serializable]
	internal sealed class NotNullCheckerSettings
	{
		//================================================================================
		// 定数
		//================================================================================
		private const string KEY = "UniNotNullChecker";

		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private bool   m_isEnable  = false;
		[SerializeField] private string m_logFormat = "参照が設定されていません：[GameObjectRootPath], [ComponentName], [FieldName]";

		//================================================================================
		// プロパティ
		//================================================================================
		public bool IsEnable
		{
			get => m_isEnable;
			set => m_isEnable = value;
		}

		public string LogFormat
		{
			get => m_logFormat;
			set => m_logFormat = value;
		}

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// EditorPrefs から読み込みます
		/// </summary>
		public static NotNullCheckerSettings LoadFromEditorPrefs()
		{
			var json = EditorPrefs.GetString( KEY );
			var settings = JsonUtility.FromJson<NotNullCheckerSettings>( json ) ??
			               new NotNullCheckerSettings();

			return settings;
		}

		/// <summary>
		/// EditorPrefs に保存します
		/// </summary>
		public static void SaveToEditorPrefs( NotNullCheckerSettings setting )
		{
			var json = JsonUtility.ToJson( setting );

			EditorPrefs.SetString( KEY, json );
		}
	}
}