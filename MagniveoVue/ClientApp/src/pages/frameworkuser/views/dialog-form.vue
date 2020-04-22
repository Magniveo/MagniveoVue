<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions"></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import { sexList } from "@/config/entity";
import UploadImg from "@/components/page/UploadImg.vue";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getFrameworkRoles;
    @Action
    getFrameworkGroups;
    @State
    getFrameworkRolesData;
    @State
    getFrameworkGroupsData;
    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
                "Entity.ITCode": {
                    type: "input",
                    label: "Номер счета",
                    rules: {
                        required: true,
                        message: "Пожалуйста, войдите в аккаунт",
                        trigger: "blur"
                    }
                },
                "Entity.Password": {
                    type: "input",
                    label: "Пароль",
                    rules: {
                        required: true,
                        message: "Пожалуйста, войдите в аккаунт",
                        trigger: "blur"
                    },
                    isHidden: (res, status) => status === "edit"
                },
                "Entity.Email": {
                    type: "input",
                    label: "Email"
                },
                "Entity.Name": {
                    type: "input",
                    label: "Имя",
                    rules: {
                        required: true,
                        message: "Пожалуйста, введите имя",
                        trigger: "blur"
                    }
                },
                "Entity.Sex": {
                    type: "select",
                    label: "Пол",
                    children: sexList
                },
                "Entity.CellPhone": {
                    type: "input",
                    label: "Телефон"
                },
                "Entity.HomePhone": {
                    type: "input",
                    label: "Домашний телефон"
                },
                "Entity.Address": {
                    type: "input",
                    label: "Адрес"
                },
                "Entity.ZipCode": {
                    type: "input",
                    label: "Почтовый код"
                },
                "Entity.PhotoId": {
                    type: "wtmUploadImg",
                    label: "Фото",
                    props: {
                        isHead: true,
                        imageStyle: { width: "100px", height: "100px" }
                    }
                },
                "Entity.IsValid": {
                    type: "switch",
                    label: "Действующий",
                    defaultValue: true
                },
                "Entity.UserRoles": {
                    type: "transfer",
                    label: "Роль",
                    mapKey: "RoleId",
                    props: {
                        data: this.getFrameworkRolesData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: ["Все", "Выбранный"],
                        filterable: true,
                        filterMethod: filterMethod,
                        "filter-placeholder": "Пожалуйста, введите роль"
                    },
                    span: 24,
                    defaultValue: []
                },
                "Entity.UserGroups": {
                    type: "transfer",
                    label: "Группа пользователей",
                    mapKey: "GroupId",
                    props: {
                        data: this.getFrameworkGroupsData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: ["Все", "Выбранный"],
                        filterable: true,
                        filterMethod: filterMethod,
                        "filter-placeholder": "Пожалуйста, введите группу пользователей"
                    },
                    span: 24,
                    defaultValue: []
                }
            }
        };
    }
    mounted() {
        this.getFrameworkRoles();
        this.getFrameworkGroups();
    }
}
</script>
