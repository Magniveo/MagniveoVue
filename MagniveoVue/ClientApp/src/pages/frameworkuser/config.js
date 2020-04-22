"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// 页面中，需要展示的动作按钮；增，改，删，导入，导出
exports.ASSEMBLIES = [
    "add",
    "edit",
    "delete",
    "export",
    "imported"
];
// 列表
exports.TABLE_HEADER = [
    { key: "ITCode", sortable: true, label: "Номер счета" },
    { key: "Name", sortable: true, label: "Полное имя" },
    { key: "Sex", sortable: true, label: "Пол" },
    { key: "PhotoId", label: "Фото", isSlot: true },
    { key: "IsValid", label: "Действующий", isSlot: true },
    { key: "RoleName_view", label: "Роль" },
    { key: "GroupName_view", label: "Группа пользователей" },
    { isOperate: true, label: "Операционная", actions: ["detail", "edit", "deleted"] } //操作列
];
//# sourceMappingURL=config.js.map