interface ISettings {
  title: string; // Overrides the default title
  showSettings: boolean; // Controls settings panel display
  showTagsView: boolean; // Controls tagsview display
  showSidebarLogo: boolean; // Controls siderbar logo display
  fixedHeader: boolean; // If true, will fix the header component
  errorLog: string[]; // The env to enable the errorlog component, default 'production' only
  sidebarTextTheme: boolean; // If true, will change active text color for sidebar based on theme
  devServerPort: number; // Port number for webpack-dev-server
  mockServerPort: number; // Port number for mock server
  isDialog: boolean;
  menuBackgroundImg: any;
}

const settings: ISettings = {
  title: "WTM",
  showSettings: true,
  showTagsView: true,
  fixedHeader: false,
  showSidebarLogo: true,
  errorLog: ["production"],
  sidebarTextTheme: true,
  isDialog: true,
  devServerPort: 9527,
  mockServerPort: 9528,
  menuBackgroundImg: {
    image: require("static/img/sidebar-2.jpg"),
    key: "sidebar-2"
  }
};

export default settings;
