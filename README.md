# Property No Cost | 元数据老赖

清除跨存档的元数据消耗记录，但保留存档内的统计数据。这样可以让元数�?可用"，但不影响存档内的成就和统计�?
Clear cross-save Metadata consumption records while preserving in-save statistics. This makes Metadata available without affecting achievements and statistics within the save.

## 功能 Features

- **清除跨存档消�?*：清�?Property 文件夹中当前种子的消耗记�?- **保留存档统计**：存档内的元数据消耗统计保持不�?- **自动生效**：对已有存档也生效，无需重新开�?- **不影响成�?*：存档内的统计数据完整，成就系统正常工作

- **Clear cross-save consumption**: Clears Metadata consumption records in the Property folder for the current seed
- **Preserve save statistics**: In-save Metadata consumption statistics remain unchanged
- **Automatic effect**: Works on existing saves, no need to restart
- **Achievement safe**: In-save statistics intact, achievement system works normally

## 工作原理 How It Works

游戏中有两层元数据记录：
1. **Property 文件�?*（跨存档）：记录所有存档的累计生产和消�?2. **存档文件�?*：记录当前存档的生产和消�?
可用元数�?= 跨存档总生�?- 跨存档总消�?- 当前存档生产

�?mod 会定期清�?跨存档总消�?，使得所有元数据都可用，但存档内的消耗记录保持不变�?
The game has two layers of Metadata records:
1. **Property folder** (cross-save): Cumulative production and consumption across all saves
2. **Save file** (in-save): Production and consumption for current save

Available Metadata = Cross-save total production - Cross-save total consumption - Current save production

This mod periodically clears cross-save total consumption, making all Metadata available while keeping in-save consumption records intact.

## 使用方法 Usage

1. 安装 mod 后，进入游戏
2. mod 会自动每秒清理一次跨存档的消耗记�?3. 元数据变为可用状态，但存档内统计不变
4. 成就、统计等功能正常工作

1. Install mod and enter the game
2. Mod automatically clears cross-save consumption records every second
3. Metadata becomes available while in-save statistics remain unchanged
4. Achievements and statistics work normally

## 注意事项 Notes

- **对旧存档生效**：无需重新开档，加载旧存档即可使�?- **不影响其他存�?*：只清除当前种子的消耗记�?- **存档内统计完�?*：`GameHistoryData.propertyData` 保持不变
- **元数据文�?*：保存在 `Documents/Dyson Sphere Program/Property/` �?
- **Works on old saves**: No need to restart, works when loading old saves
- **Doesn't affect other saves**: Only clears consumption for current seed
- **In-save statistics complete**: `GameHistoryData.propertyData` remains unchanged
- **Property files**: Saved in `Documents/Dyson Sphere Program/Property/`

## 兼容�?Compatibility

- 游戏版本 Game Version: 0.10.31.24571+
- 与其�?mod 兼容 Compatible with other mods
- 可与 PropertyMultiplier 同时使用 Can be used with PropertyMultiplier
- 需要前�?YummiUIHarness：与 MetadataBoost 共用「元数据作弊」页，可随时开�?- Requires YummiUIHarness: shared Metadata Cheats page with MetadataBoost

## 更新日志 Changelog

### 1.1.0
- 依赖 YummiUIHarness，面板中新增「启用」复选框（配置项 `General/Enabled`�?- Depends on YummiUIHarness; adds an "Enabled" checkbox in the panel (config `General/Enabled`)

### 1.0.0
- 初始版本
- 清除跨存档消耗，保留存档内统�?- Initial release
- Clear cross-save consumption, preserve in-save statistics
