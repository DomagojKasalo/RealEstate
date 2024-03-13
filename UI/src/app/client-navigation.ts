export const clientNavigation: any[] = [
    {
      text: 'Home',
      path: '/home',
      icon: 'home'
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
  ];
  