import Main from '@/components/main'
import parentView from '@/components/parent-view'


export default [
  {
    path: '/login',
    name: 'login',
    meta: {
      title: 'Login - 登录',
      hideInMenu: true
    },
    component: () => import('@/view/login/login.vue')
  },
  {
    path: '/',
    name: '_home',
    redirect: '/home',
    component: Main,
    meta: {
      hideInMenu: true,
      notCache: true
    },
    children: [
      {
        path: '/home',
        name: 'home',
        meta: {
          hideInMenu: true,
          title: '首页',
          notCache: true,
          icon: 'md-home'
        },
        component: () => import('@/view/single-page/home')
      }
    ]
  },
  // Admin Center
  {
    path: '/admin-center',
    name: 'Admin Center',
    meta: {
      icon: 'md-menu',
      title: 'Admin Center'
    },
    component: Main,
    children: [
      {
        path: 'general',
        name: 'General',
        meta: {
          icon: 'md-funnel',
          showAlways: true,
          title: 'General'
        },
        component: parentView,
        children: [
          {
            path: 'company',
            name: 'Company',
            meta: {
              // access: ['AGC01'],
              icon: 'md-funnel',
              title: 'Company'
            },
            component: () => import('@/view/admin-center/general/company.vue')
          },
          {
            path: 'company-form',
            name: 'Form Company',
            meta: {
              // access: ['AGC01'],
              hideInMenu: true,
              icon: 'md-funnel',
              title: 'Form Company'
            },
            component: () => import('@/view/admin-center/general/company-form.vue')
          },
          {
            path: 'branch',
            name: 'Branch',
            meta: {
              // access: ['AGB01'],
              icon: 'md-funnel',
              title: 'Branch'
            },
            component: () => import('@/view/admin-center/general/branch.vue')
          },
          {
            path: 'branch-form',
            name: 'Form Branch',
            meta: {
              // access: ['AGB01'],
              hideInMenu: true,
              icon: 'md-funnel',
              title: 'Form Branch'
            },
            component: () => import('@/view/admin-center/general/branch-form.vue')
          },
          {
            path: 'useraccount-form',
            name: 'Form User Account',
            meta: {
              // access: ['AGU01'],
              hideInMenu: true,
              icon: 'md-funnel',
              title: 'Form User Account'
            },
            component: () => import('@/view/admin-center/general/useraccount-form.vue')
          },
          {
            path: 'useraccount',
            name: 'User Account',
            meta: {
              // access: ['AGU01'],
              icon: 'md-funnel',
              title: 'User Account'
            },
            component: () => import('@/view/admin-center/general/useraccount.vue')
          },
          {
            path: 'exchangerate',
            name: 'Exchange Rate',
            meta: {
              // access: ['AGB01'],
              icon: 'md-funnel',
              title: 'Currency'
            },
            component: () => import('@/view/admin-center/general/exchangerate.vue')
          },
          // {
          //   path: 'exchangerate',
          //   name: 'Exchange1 Rate',
          //   meta: {
          //     access: ['AGB01'],
          //     icon: 'md-funnel',
          //     title: 'Currency'
          //   },
          //   component: () => import('@/view/admin-center/general/exchangerate.vue')
          // },
        ]
      },
      // {
      //   path: 'inventory',
      //   name: 'Inventory',
      //   meta: {
      //     access: ['AGC01'],
      //     icon: 'md-funnel',
      //     showAlways: true,
      //     title: 'inventory'
      //   },
      //   component: parentView,
      //   children: [
      //     {
      //       path: 'warehouse',
      //       name: 'Warehouse3',
      //       meta: {
      //         icon: 'md-funnel',
      //         title: '三级'
      //       },
      //       component: () => import('@/view/admin-center/inventory/warehouse.vue')
      //     },
      //     {
      //       path: 'warehouse1',
      //       name: 'Warehouse1',
      //       meta: {
      //         icon: 'md-funnel',
      //         title: '三级'
      //       },
      //       component: () => import('@/view/admin-center/inventory/warehouse1.vue')
      //     },
      //     {
      //       path: 'warehouse1',
      //       name: 'Warehouse1',
      //       meta: {
      //         icon: 'md-funnel',
      //         title: '三级'
      //       },
      //       component: () => import('@/view/admin-center/inventory/warehouse1.vue')
      //     },
      //     {
      //       path: 'warehouse2',
      //       name: 'Warehouse2',
      //       meta: {
      //         icon: 'md-funnel',
      //         title: '三级'
      //       },
      //       component: () => import('@/view/admin-center/inventory/warehouse1.vue')
      //     },
      //     {
      //       path: 'level_2_2',
      //       name: 'level_2_2',
      //       meta: {
      //         access: ['super_admin'],
      //         icon: 'md-funnel',
      //         showAlways: true,
      //         title: '二级-2'
      //       },
      //       component: parentView,
      //       children: [
      //         {
      //           path: 'level_2_2_1',
      //           name: 'level_2_2_1',
      //           meta: {
      //             icon: 'md-funnel',
      //             title: '三级'
      //           },
      //           component: () => import('@/view/multilevel/level-2-2/level-2-2-1.vue')
      //         },
      //         {
      //           path: 'level_2_2_2',
      //           name: 'level_2_2_2',
      //           meta: {
      //             icon: 'md-funnel',
      //             title: '三级'
      //           },
      //           component: () => import('@/view/multilevel/level-2-2/level-2-2-2.vue')
      //         }
      //       ]
      //     },
      //     {
      //       path: 'level_2_2_2',
      //       name: 'level_2_2_2',
      //       meta: {
      //         icon: 'md-funnel',
      //         title: '三级'
      //       },
      //       component: () => import('@/view/multilevel/level-2-2/level-2-2-2.vue')
      //     }
      //   ]
      // },
    ]
  },
  // Business Partner
  {
    path: '/business-partner',
    name: 'Business Partner',
    meta: {
      icon: 'ios-stats',
      title: 'EXCEL导入导出'
    },
    component: Main,
    children: [
      {
        path: 'customer',
        name: 'Customer',
        meta: {
          access: ['AGB01'],
          icon: 'md-add',
          title: '导入EXCEL'
        },
        component: () => import('@/view/business-partner/customer.vue')
      },
      {
        path: 'customer-form',
        name: 'Form Customer',
        meta: {
          access: ['AGB01'],
          hideInMenu: true,
          icon: 'md-funnel',
          title: 'Form Branch'
        },
        component: () => import('@/view/business-partner/customer-form.vue')
      },
      {
        path: 'vendor',
        name: 'Vendor',
        meta: {
          access: ['AGB02'],
          icon: 'md-download',
          title: '导出EXCEL'
        },
        component: () => import('@/view/business-partner/vendor.vue')
      },
      {
        path: 'vendor-form',
        name: 'Form Vendor',
        meta: {
          access: ['AGB02'],
          hideInMenu: true,
          icon: 'md-funnel',
          title: 'Form Branch'
        },
        component: () => import('@/view/business-partner/vendor-form.vue')
      },
    ]
  },
  // Purchase
  // {
  //   path: '/purchase',
  //   name: 'Purchase',
  //   meta: {
  //     icon: 'ios-stats',
  //     title: 'EXCEL导入导出'
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'purchase',
  //       name: 'Purchase',
  //       meta: {
  //         icon: 'md-add',
  //         title: '导入EXCEL'
  //       },
  //       component: () => import('@/view/purchase/purchase-form.vue')
  //     },
  //   ]
  // },
  // {
  //   path: '',
  //   name: 'doc',
  //   meta: {
  //     title: '文档',
  //     href: '/#/',
  //     icon: 'ios-book'
  //   }
  // },
  // {
  //   path: '/join',
  //   name: 'join',
  //   component: Main,
  //   meta: {
  //     hideInBread: true
  //   },
  //   children: [
  //     {
  //       path: 'join_page',
  //       name: 'join_page',
  //       meta: {
  //         icon: '_qq',
  //         title: 'QQ群'
  //       },
  //       component: () => import('@/view/join-page.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/message',
  //   name: 'message',
  //   component: Main,
  //   meta: {
  //     hideInBread: true,
  //     hideInMenu: true
  //   },
  //   children: [
  //     {
  //       path: 'message_page',
  //       name: 'message_page',
  //       meta: {
  //         icon: 'md-notifications',
  //         title: '消息中心'
  //       },
  //       component: () => import('@/view/single-page/message/index.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/components',
  //   name: 'components',
  //   meta: {
  //     icon: 'logo-buffer',
  //     title: '组件'
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'tree_select_page',
  //       name: 'tree_select_page',
  //       meta: {
  //         icon: 'md-arrow-dropdown-circle',
  //         title: '树状下拉选择器'
  //       },
  //       component: () => import('@/view/components/tree-select/index.vue')
  //     },
  //     {
  //       path: 'count_to_page',
  //       name: 'count_to_page',
  //       meta: {
  //         icon: 'md-trending-up',
  //         title: '数字渐变'
  //       },
  //       component: () => import('@/view/components/count-to/count-to.vue')
  //     },
  //     {
  //       path: 'drag_list_page',
  //       name: 'drag_list_page',
  //       meta: {
  //         icon: 'ios-infinite',
  //         title: '拖拽列表'
  //       },
  //       component: () => import('@/view/components/drag-list/drag-list.vue')
  //     },
  //     {
  //       path: 'drag_drawer_page',
  //       name: 'drag_drawer_page',
  //       meta: {
  //         icon: 'md-list',
  //         title: '可拖拽抽屉'
  //       },
  //       component: () => import('@/view/components/drag-drawer')
  //     },
  //     {
  //       path: 'org_tree_page',
  //       name: 'org_tree_page',
  //       meta: {
  //         icon: 'ios-people',
  //         title: '组织结构树'
  //       },
  //       component: () => import('@/view/components/org-tree')
  //     },
  //     {
  //       path: 'tree_table_page',
  //       name: 'tree_table_page',
  //       meta: {
  //         icon: 'md-git-branch',
  //         title: '树状表格'
  //       },
  //       component: () => import('@/view/components/tree-table/index.vue')
  //     },
  //     {
  //       path: 'cropper_page',
  //       name: 'cropper_page',
  //       meta: {
  //         icon: 'md-crop',
  //         title: '图片裁剪'
  //       },
  //       component: () => import('@/view/components/cropper/cropper.vue')
  //     },
  //     {
  //       path: 'tables_page',
  //       name: 'tables_page',
  //       meta: {
  //         icon: 'md-grid',
  //         title: '多功能表格'
  //       },
  //       component: () => import('@/view/components/tables/tables.vue')
  //     },
  //     {
  //       path: 'split_pane_page',
  //       name: 'split_pane_page',
  //       meta: {
  //         icon: 'md-pause',
  //         title: '分割窗口'
  //       },
  //       component: () => import('@/view/components/split-pane/split-pane.vue')
  //     },
  //     {
  //       path: 'markdown_page',
  //       name: 'markdown_page',
  //       meta: {
  //         icon: 'logo-markdown',
  //         title: 'Markdown编辑器'
  //       },
  //       component: () => import('@/view/components/markdown/markdown.vue')
  //     },
  //     {
  //       path: 'editor_page',
  //       name: 'editor_page',
  //       meta: {
  //         icon: 'ios-create',
  //         title: '富文本编辑器'
  //       },
  //       component: () => import('@/view/components/editor/editor.vue')
  //     },
  //     {
  //       path: 'icons_page',
  //       name: 'icons_page',
  //       meta: {
  //         icon: '_bear',
  //         title: '自定义图标'
  //       },
  //       component: () => import('@/view/components/icons/icons.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/update',
  //   name: 'update',
  //   meta: {
  //     icon: 'md-cloud-upload',
  //     title: '数据上传'
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'update_table_page',
  //       name: 'update_table_page',
  //       meta: {
  //         icon: 'ios-document',
  //         title: '上传Csv'
  //       },
  //       component: () => import('@/view/update/update-table.vue')
  //     },
  //     {
  //       path: 'update_paste_page',
  //       name: 'update_paste_page',
  //       meta: {
  //         icon: 'md-clipboard',
  //         title: '粘贴表格数据'
  //       },
  //       component: () => import('@/view/update/update-paste.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/excel',
  //   name: 'excel',
  //   meta: {
  //     icon: 'ios-stats',
  //     title: 'EXCEL导入导出'
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'upload-excel',
  //       name: 'upload-excel',
  //       meta: {
  //         icon: 'md-add',
  //         title: '导入EXCEL'
  //       },
  //       component: () => import('@/view/excel/upload-excel.vue')
  //     },
  //     {
  //       path: 'export-excel',
  //       name: 'export-excel',
  //       meta: {
  //         icon: 'md-download',
  //         title: '导出EXCEL'
  //       },
  //       component: () => import('@/view/excel/export-excel.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/tools_methods',
  //   name: 'tools_methods',
  //   meta: {
  //     hideInBread: true
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'tools_methods_page',
  //       name: 'tools_methods_page',
  //       meta: {
  //         icon: 'ios-hammer',
  //         title: '工具方法',
  //         beforeCloseName: 'before_close_normal'
  //       },
  //       component: () => import('@/view/tools-methods/tools-methods.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/error_store',
  //   name: 'error_store',
  //   meta: {
  //     hideInBread: true
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'error_store_page',
  //       name: 'error_store_page',
  //       meta: {
  //         icon: 'ios-bug',
  //         title: '错误收集'
  //       },
  //       component: () => import('@/view/error-store/error-store.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/error_logger',
  //   name: 'error_logger',
  //   meta: {
  //     hideInBread: true,
  //     hideInMenu: true
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'error_logger_page',
  //       name: 'error_logger_page',
  //       meta: {
  //         icon: 'ios-bug',
  //         title: '错误收集'
  //       },
  //       component: () => import('@/view/single-page/error-logger.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/argu',
  //   name: 'argu',
  //   meta: {
  //     hideInMenu: true
  //   },
  //   component: Main,
  //   children: [
  //     {
  //       path: 'params/:id',
  //       name: 'params',
  //       meta: {
  //         icon: 'md-flower',
  //         title: route => `{{ params }}-${route.params.id}`,
  //         notCache: true,
  //         beforeCloseName: 'before_close_normal'
  //       },
  //       component: () => import('@/view/argu-page/params.vue')
  //     },
  //     {
  //       path: 'query',
  //       name: 'query',
  //       meta: {
  //         icon: 'md-flower',
  //         title: route => `{{ query }}-${route.query.id}`,
  //         notCache: true
  //       },
  //       component: () => import('@/view/argu-page/query.vue')
  //     }
  //   ]
  // },
  // {
  //   path: '/401',
  //   name: 'error_401',
  //   meta: {
  //     hideInMenu: true
  //   },
  //   component: () => import('@/view/error-page/401.vue')
  // },
  // {
  //   path: '/500',
  //   name: 'error_500',
  //   meta: {
  //     hideInMenu: true
  //   },
  //   component: () => import('@/view/error-page/500.vue')
  // },
  // {
  //   path: '*',
  //   name: 'error_404',
  //   meta: {
  //     hideInMenu: true
  //   },
  //   component: () => import('@/view/error-page/404.vue')
  // }
]
