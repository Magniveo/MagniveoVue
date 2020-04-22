<template>
  <wtm-dialog-box :is-show="isShow" title="Импорт" width="40%" @close="onClose">
    <div>
        <span>Инструкции по импорту: пожалуйста, скачайте шаблон, а затем введите информацию в шаблон</span>
      <el-divider direction="vertical" />
      <el-button type="primary" icon="el-icon-download" size="small" @click="onDownload">
          Скачать шаблон
      </el-button>
    </div>
    <el-divider />
    <el-upload class="upload-box" drag :action="uploadApi" :show-file-list="false" :on-success="handleAvatarSuccess" :on-error="onError" multiple>
      <i class="el-icon-upload" />
      <div class="el-upload__text">
          Перетащите файл сюда или<em>Нажмите, чтобы загрузить</em>
      </div>
    </el-upload>
  </wtm-dialog-box>
</template>
<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { upload } from "@/service/modules/upload";

@Component
export default class Upload extends Vue {
    @Prop({ type: Boolean, default: false })
    isShow;
    uploadApi:string = upload.url;
    onClose() {
        this.$emit("update:isShow", false);
    }
    handleAvatarSuccess(res) {
        if (res.Id) {
            this.$emit("onImport", res);
            this.onClose();
        } else {
            this["$message"].error("Загрузка не удалась!");
        }
    }
    onDownload() {
        this.$emit("onDownload");
    }
    /**
     * 导出错误
     */
    onError(err) {
        this["$message"].error(`Загрузка не удалась,${err}`);
    }
}
</script>
<style lang="less" >
.upload-box {
    width: 100%;
    .el-upload {
        width: 100%;
    }
    .el-upload-dragger {
        width: 100%;
    }
}
</style>
