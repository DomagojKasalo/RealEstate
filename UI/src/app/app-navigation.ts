export const navigation : any[] = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'User',
    icon: 'user',
    items: [
      {
        text: 'User',
        path: '/user'
      }
    ]
  },
  {
    text: 'Company',
    icon: 'folder',
    items: [
      {
        text: 'All Companies',
        path: '/companies'
      },
    ]
  },
  {
    text: 'Catalogs',
    icon: 'folder',
    items: [
      {
        text: 'All Catalogs',
        path: '/catalogs'
      },
      {
        text: 'All Catalog Items',
        path: '/catalogItems'
      }
    ]
  },
  {
    text: 'Email',
    icon: 'folder',
    items: [
      {
        text: 'Invitation mail',
        path: '/invitation'
      },
    ]
  },
  {
    text: 'Azure',
    icon: 'folder',
    items: [
      {
        text: 'Upload file',
        path: '/file-upload'
      },
    ]
  },
];
