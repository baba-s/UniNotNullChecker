﻿using UnityEditor;
using UnityEngine;

namespace UniNotNullChecker
{
	/// <summary>
	/// Preferences における設定画面を管理するクラス
	/// </summary>
	internal sealed class NotNullCheckerSettingsProvider : SettingsProvider
	{
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NotNullCheckerSettingsProvider( string path, SettingsScope scope )
			: base( path, scope )
		{
		}

		/// <summary>
		/// GUI を描画する時に呼び出されます
		/// </summary>
		public override void OnGUI( string searchContext )
		{
			var settings = NotNullCheckerSettings.LoadFromEditorPrefs();

			using ( var checkScope = new EditorGUI.ChangeCheckScope() )
			{
				settings.IsEnable  = EditorGUILayout.Toggle( "Enabled", settings.IsEnable );
				settings.LogFormat = EditorGUILayout.TextField( "Log Format", settings.LogFormat );

				if ( checkScope.changed )
				{
					NotNullCheckerSettings.SaveToEditorPrefs( settings );
				}

				EditorGUILayout.HelpBox( "Log Format で使用できるタグ", MessageType.Info );

				EditorGUILayout.TextArea
				(
					@"[GameObjectName]
[GameObjectRootPath]
[ComponentName]
[FieldName]"
				);

				if ( GUILayout.Button( "Use Default" ) )
				{
					settings = new NotNullCheckerSettings();
					NotNullCheckerSettings.SaveToEditorPrefs( settings );
				}
			}
		}

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// Preferences にメニューを追加します
		/// </summary>
		[SettingsProvider]
		private static SettingsProvider Create()
		{
			var path     = "Preferences/UniNotNullChecker";
			var provider = new NotNullCheckerSettingsProvider( path, SettingsScope.User );

			return provider;
		}
	}
}