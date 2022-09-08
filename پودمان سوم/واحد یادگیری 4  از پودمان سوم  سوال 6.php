<?php

/**

 * سرایند پوسته درسنامه

 */

?><!DOCTYPE html>

<html <?php language_attributes(); ?>>

    <head>

        <meta charset="<?php bloginfo('charset'); ?>" />

        <meta http-equiv="Content-Type" content="<?php bloginfo('html_type');?>" />

        <meta name="description" content="<?php bloginfo("description"); ?>">

        <meta name="viewport" content="width=device-width">

        <title>

<title><?php  bloginfo('name');?> </title>

        <link rel="alternate" type="application/rss+xml" title="<?php bloginfo('name'); ?> RSS Feed"

              href="<?php bloginfo('rss2_url'); ?>" />

        <link rel="profile" href="http://gmpg.org/xfn/11" />

        <link rel="pingback" href="<?php bloginfo('pingback_url'); ?>" />

        <link rel="stylesheet" href="<?php bloginfo("template_directory"); ?>/style.css">

        <link rel="profile" href="http://gmpg.org/xfn/11" />

        <link rel="shortcut icon" href="<?php bloginfo('template_directory'); ?>/img/darsnameh.ico" />

        <?php wp_head(); ?>

    </head>

    <body <?php body_class(); ?>>

        <div id="primary">           

            <header id="header" >

                <nav role="navigation" class="">

                <?php wp_nav_menu(array('theme_location' => 'primary')); ?>

                </nav>                                                        

                <h1><a href="<?php bloginfo('url'); ?>" title="<?php bloginfo('name'); ?>" name="top"><?php bloginfo('name'); ?></a></h1>

                <h3>   <span><?php bloginfo('description'); ?></span></h3>                                                

            </header>       

            <div id="main">