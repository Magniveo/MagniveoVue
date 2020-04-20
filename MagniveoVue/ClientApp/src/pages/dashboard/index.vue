<template>
  <div class="dashboard-container">
    <el-row :gutter="12">
      <el-col :span="8" :xs="24">
        <chart-card :chart-data="dailySalesChart.data" :chart-options="dailySalesChart.options" :chart-type="dailySalesChart.type" backgroundColor="blue">
          <template slot="content">
            <h4 class="title">Daily Sales</h4>
            <p class="category">
              <span class="text-success"><i class="el-icon-top"></i> 55% </span>
              increase in today sales.
            </p>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              updated 4 minutes ago
            </div>
          </template>
        </chart-card>
      </el-col>
      <el-col :span="8" :xs="24">
        <chart-card :chart-data="dataCompletedTasksChart.data" :chart-options="dataCompletedTasksChart.options" :chart-type="dataCompletedTasksChart.type" backgroundColor="red">
          <template slot="content">
            <h4 class="title">Email Subscription</h4>
            <p class="category">
              Last Campaign Performance.
            </p>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              updated 10 days ago
            </div>
          </template>
        </chart-card>
      </el-col>
      <el-col :span="8" :xs="24">
        <chart-card :chart-data="emailsSubscriptionChart.data" :chart-options="emailsSubscriptionChart.options" backgroundColor="green">
          <template slot="content">
            <h4 class="title">Completed Tasks</h4>
            <p class="category">
              Last Campaign Performance.
            </p>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              campaign sent 26 minutes ago
            </div>
          </template>
        </chart-card>
      </el-col>
    </el-row>
    <el-row :gutter="12">
      <el-col :span="6" :xs="24">
        <stats-card backgroundColor="purple" elIcon="el-icon-star-on">
          <template slot="content">
            <p class="category">Star</p>
            <h3 class="title">
              {{ getGithubInfoData.stargazers_count || "-" }}
            </h3>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </el-col>
      <el-col :span="6" :xs="24">
        <stats-card backgroundColor="green" elIcon="el-icon-mobile">
          <template slot="content">
            <p class="category">Fork</p>
            <h3 class="title">{{ getGithubInfoData.forks_count || "-" }}</h3>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </el-col>
      <el-col :span="6" :xs="24">
        <stats-card backgroundColor="orange" elIcon="el-icon-stopwatch">
          <template slot="content">
            <p class="category">Watch</p>
            <h3 class="title">
              {{ getGithubInfoData.subscribers_count || "-" }}
            </h3>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </el-col>
      <el-col :span="6" :xs="24">
        <stats-card backgroundColor="red" elIcon="el-icon-info">
          <template slot="content">
            <p class="category">Issue</p>
            <h3 class="title">
              {{ getGithubInfoData.open_issues_count || "-" }}
            </h3>
          </template>
          <template slot="footer">
            <div class="stats">
              <i class="el-icon-time"></i>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </el-col>
    </el-row>
    <el-row :gutter="10">
      <el-col :span="16" :md="16" :xs="24" :sm="24">
        <el-row :gutter="10">
          <el-col :span="12" :xs="24">
            <el-card shadow="hover">
                <div slot="header">Ярлыки</div>
              <el-row class="lump-wrap" :gutter="10">
                <el-col :span="6" v-for="item of shortcutList" :key="item.Value">
                  <el-link @click="onPush(item.Url)" :underline="false"><i :class="[item.Icon ? item.Icon : 'el-icon-edit']"></i>{{ item.Text }}</el-link>
                </el-col>
                <el-col :span="6">
                    <el-link target="_blank" href="https://wtmdoc.walkingtec.cn/" :underline="false"><i class="el-icon-document"></i>Проектная документация</el-link>
                </el-col>
                <el-col :span="6">
                    <el-link target="_blank" href="/_codegen?ui=vue" :underline="false"><i class="el-icon-s-platform"></i>Генерация кода</el-link>
                </el-col>
              </el-row>
            </el-card>
          </el-col>
          <el-col :span="12" :xs="24">
            <el-card shadow="hover">
              <div slot="header"><span>WTM Открытый исходный код</span></div>
              <el-row class="lump-wrap cxt-left" :gutter="10">
                <el-col :span="12">
                  <div>
                    <h3>Star</h3>
                    <p>{{ getGithubInfoData.stargazers_count || "" }}</p>
                  </div>
                </el-col>
                <el-col :span="12">
                  <div>
                    <h3>Fork</h3>
                    <p>{{ getGithubInfoData.forks_count || "" }}</p>
                  </div>
                </el-col>
                <el-col :span="12">
                  <div>
                    <h3>Watch</h3>
                    <p>{{ getGithubInfoData.subscribers_count || "" }}</p>
                  </div>
                </el-col>
                <el-col :span="12">
                  <div>
                    <h3>Issue</h3>
                    <p>{{ getGithubInfoData.open_issues_count || "" }}</p>
                  </div>
                </el-col>
              </el-row>
            </el-card>
          </el-col>
          <el-col :span="24" :sm="24">
            <e-charts-module />
          </el-col>
        </el-row>
      </el-col>
      <el-col :span="8" :md="8" :xs="24" :sm="24">
        <el-col :span="24">
            <el-card shadow="hover">
                <div slot="header">Параметры границ</div>
                <i class="el-icon-check"></i>Один клик для создания проекта WTM<br />
                <i class="el-icon-check"></i>Генерация дополнений, удалений и изменений в один клик, импорт и экспорт, коды пакетных операций<br />
                <i class="el-icon-check"></i>Поддерживать идентификацию модели ассоциации «один ко многим, многие ко многим» и генерацию кода<br />
                <i class="el-icon-check"></i>Поддержка разделения (React + AntD, Vue + Element) и без разделения (LayUI) в двух режимах<br />
                <i class="el-icon-check"></i>Поддержка sqlserver, mysql, pgsql три базы данных<br />
                <i class="el-icon-check"></i>Инкапсулирует большинство элементов управления Layui, AntD, Element, писать на стойке легче<br />
                <i class="el-icon-check"></i>Предоставляет множество базовых классов, инкапсулирующих большинство распространенных фоновых операций.<br />
                <i class="el-icon-check"></i>Предоставляет общие модули, такие как пользователи, роли, группы пользователей, меню, журналы и т. Д.<br />
                <i class="el-icon-check"></i>Поддержка разработки и настройки разрешений для данных.<br />
                <i class="el-icon-check"></i>Поддержка чтения-записи разделения и базы данных библиотеки
            </el-card>
        </el-col>
        <el-col :span="24">
          <el-card shadow="hover">
              <div slot="header">Слова от автора</div>
              <p>
                  WTM framework, полное имя WalkingTec
                  MVVM (не первая буква «My Special»), WTM - это среда быстрого развития, как быстро? По крайней мере, для текущего проекта с открытым исходным кодом dotnetcore я не видел более обоснованной и быстрой среды разработки. Концепция дизайна WTM заключается в том, чтобы максимально ускорить разработку и снизить затраты на разработку.
              </p>
              <p>
                  Есть много причин для доминирования Java в Китае: демонстрационные эффекты BAT и ошибки собственной стратегии Microsoft. К счастью, Microsoft наконец-то захотела понять эти два года,
                  DotNet
                  Появление ядра и приобретение github - очень правильные направления. Конечно, для достижения той же экологии, что и в Java, еще далеко, поэтому я внесу небольшой вклад.
              </p>
              <p>
                  Поскольку WTM является открытым исходным кодом, его любят все больше и больше разработчиков. WTM определенно вернет вашу любовь более зрелым и стабильным отношением. Отдельное спасибо layui.com (layui.com), проект, разработанный авторизованным WTM, может бесплатно использовать свою платную версию LayuiAdmin. Совершенствуйте себя и приносите пользу другим, я не одинок!
              </p>
              <p>
                  —— Framework с открытым исходным кодом：<el-link href="https://github.com/dotnetcore/WTM" target="_blank" type="primary">https://github.com/dotnetcore/WTM</el-link>
              </p>
              <p>
                  —— Framework Online Document：<el-link href="https://wtmdoc.walkingtec.cn" target="_blank" type="primary">https://wtmdoc.walkingtec.cn</el-link>
              </p>
              <p>
                  —— Framework QQ Exchange Group：694148336
              </p>
          </el-card>
        </el-col>
      </el-col>
    </el-row>
    <el-row :gutter="20">
      <el-col :span="24">
        <el-calendar v-model="value" />
      </el-col>
    </el-row>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { RoutesModule } from "@/store/modules/routes";
import EChartsModule from "./views/echarts";
import ChartCard from "./views/chart-card";
import StatsCard from "./views/stats-card";
import { Action, State } from "vuex-class";
import store from "./store/index";
@Component({
    name: "dashboard",
    store,
    components: {
        EChartsModule,
        ChartCard,
        StatsCard
    }
})
export default class extends Vue {
    value: Date = new Date();
    shortcuts: any[] = [
        "Лог Менеджмент",
        "Управление группами пользователей",
        "Ролевое управление",
        "Управление пользователями",
        "Управление меню",
        "Разрешение данных"
    ];
    get shortcutList() {
        return RoutesModule.pageList.filter(item =>
            this.shortcuts.includes(item.Text)
        );
    }
    @Action
    getGithubInfo;
    @State
    getGithubInfoData;

    dailySalesChart: Object = {
        data: {
            labels: ["M", "T", "W", "T", "F", "S", "S"],
            series: [[12, 17, 7, 17, 23, 18, 38]]
        },
        options: {
            lineSmooth: this.$Chartist.Interpolation.cardinal({
                tension: 0
            }),
            low: 0,
            high: 50,
            chartPadding: {
                top: 0,
                right: 0,
                bottom: 0,
                left: 0
            }
        },
        type: "Line"
    };

    dataCompletedTasksChart: Object = {
        type: "Bar",
        data: {
            labels: ["12am", "3pm", "6pm", "9pm", "12pm", "3am", "6am", "9am"],
            series: [[230, 750, 450, 300, 280, 240, 200, 190]]
        },

        options: {
            lineSmooth: this.$Chartist.Interpolation.cardinal({
                tension: 0
            }),
            low: 0,
            high: 1000,
            chartPadding: {
                top: 0,
                right: 0,
                bottom: 0,
                left: 0
            }
        }
    };

    emailsSubscriptionChart: Object = {
        data: {
            labels: [
                "Ja",
                "Fe",
                "Ma",
                "Ap",
                "Mai",
                "Ju",
                "Jul",
                "Au",
                "Se",
                "Oc",
                "No",
                "De"
            ],
            series: [
                [542, 443, 320, 780, 553, 453, 326, 434, 568, 610, 756, 895]
            ]
        },
        options: {
            axisX: {
                showGrid: false
            },
            low: 0,
            high: 1000,
            chartPadding: {
                top: 0,
                right: 5,
                bottom: 0,
                left: 0
            }
        },
        responsiveOptions: [
            [
                "screen and (max-width: 640px)",
                {
                    seriesBarDistance: 5,
                    axisX: {
                        labelInterpolationFnc: function(value) {
                            return value[0];
                        }
                    }
                }
            ]
        ]
    };

    mounted() {
        this.getGithubInfo();
    }

    onPush(path) {
        this.$router.push(path);
    }
}
</script>
<style lang="less" rel="stylesheet/less" scoped>
@import "~@/assets/css/mixin.less";
.dashboard-container {
    padding: 10px;
    p {
        text-indent: 2em;
    }
    .title {
        margin-bottom: 5px;
        font-weight: 300;
        font-size: 16px;
    }
    .category {
        text-indent: 0;
        color: #999999;
        .text-success {
            color: red;
        }
    }
    .stats {
        color: #999999;
    }

    .el-row {
        margin-bottom: 20px;
    }
    .el-card__header {
        color: #333;
        font-size: 14px;
    }
    .el-card {
        font-size: 14px;
        color: #666;
    }
    .lump-wrap {
        margin-bottom: 0;
        min-height: 160px;
        text-align: center;
        &.cxt-left {
            .el-col {
                .flexalign(flex-start);
                box-sizing: border-box;
                padding-bottom: 10px;
                div {
                    background-color: #f8f8f8;
                    width: 100%;
                    box-sizing: border-box;
                    padding: 0 10px;
                }
            }
        }
        .el-col {
            .center(column);
            i {
                width: 100%;
                height: 60px;
                line-height: 60px;
                text-align: center;
                border-radius: 2px;
                font-size: 30px;
                background-color: #f8f8f8;
            }
            h3 {
                padding: 5px 0;
                font-size: 12px;
            }
            p {
                font-style: normal;
                font-size: 30px;
                font-weight: 300;
                color: #009688;
                text-indent: 0;
            }
            .link-a {
                color: #666;
                font-size: 14px;
                text-align: center;
            }
        }
    }
}
</style>
