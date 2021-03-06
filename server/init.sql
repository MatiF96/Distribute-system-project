PGDMP                     	    x            cinemadb    13.0    13.0 &    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16395    cinemadb    DATABASE     d   CREATE DATABASE cinemadb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Polish_Poland.1250';
    DROP DATABASE cinemadb;
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                postgres    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   postgres    false    3            �            1259    16396    hales    TABLE     P   CREATE TABLE public.hales (
    hall_id integer NOT NULL,
    hall_name text
);
    DROP TABLE public.hales;
       public         heap    postgres    false    3            �            1259    16402    hales_hall_id_seq    SEQUENCE     �   ALTER TABLE public.hales ALTER COLUMN hall_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.hales_hall_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000
    CACHE 1
);
            public          postgres    false    3    200            �            1259    16404    movies    TABLE     �   CREATE TABLE public.movies (
    movie_id integer NOT NULL,
    movie_title text NOT NULL,
    movie_duration interval[] NOT NULL
);
    DROP TABLE public.movies;
       public         heap    postgres    false    3            �            1259    16410    movies_movie_id_seq    SEQUENCE     �   ALTER TABLE public.movies ALTER COLUMN movie_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.movies_movie_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000
    CACHE 1
);
            public          postgres    false    3    202            �            1259    16412    reservations    TABLE     �   CREATE TABLE public.reservations (
    reservation_id integer NOT NULL,
    reservation_showing_id integer NOT NULL,
    reservation_user_id integer NOT NULL,
    reservation_seat integer NOT NULL
);
     DROP TABLE public.reservations;
       public         heap    postgres    false    3            �            1259    16415    reservations_reservation_id_seq    SEQUENCE     �   ALTER TABLE public.reservations ALTER COLUMN reservation_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.reservations_reservation_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000
    CACHE 1
);
            public          postgres    false    3    204            �            1259    16417    showings    TABLE     �   CREATE TABLE public.showings (
    showing_id integer NOT NULL,
    showing_movie_id integer NOT NULL,
    showing_hall_id integer NOT NULL,
    showing_date timestamp with time zone NOT NULL
);
    DROP TABLE public.showings;
       public         heap    postgres    false    3            �            1259    16420    showings_showing_id_seq    SEQUENCE     �   ALTER TABLE public.showings ALTER COLUMN showing_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.showings_showing_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000
    CACHE 1
);
            public          postgres    false    206    3            �            1259    16422    users    TABLE     �   CREATE TABLE public.users (
    user_id integer NOT NULL,
    user_login text NOT NULL,
    user_password text NOT NULL,
    user_type text NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false    3            �            1259    16428    users_user_id_seq    SEQUENCE     �   ALTER TABLE public.users ALTER COLUMN user_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.users_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000
    CACHE 1
);
            public          postgres    false    208    3            �          0    16396    hales 
   TABLE DATA           3   COPY public.hales (hall_id, hall_name) FROM stdin;
    public          postgres    false    200   �*       �          0    16404    movies 
   TABLE DATA           G   COPY public.movies (movie_id, movie_title, movie_duration) FROM stdin;
    public          postgres    false    202   �*       �          0    16412    reservations 
   TABLE DATA           u   COPY public.reservations (reservation_id, reservation_showing_id, reservation_user_id, reservation_seat) FROM stdin;
    public          postgres    false    204   �*       �          0    16417    showings 
   TABLE DATA           _   COPY public.showings (showing_id, showing_movie_id, showing_hall_id, showing_date) FROM stdin;
    public          postgres    false    206   +       �          0    16422    users 
   TABLE DATA           N   COPY public.users (user_id, user_login, user_password, user_type) FROM stdin;
    public          postgres    false    208   -+       �           0    0    hales_hall_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.hales_hall_id_seq', 1, false);
          public          postgres    false    201            �           0    0    movies_movie_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.movies_movie_id_seq', 1, false);
          public          postgres    false    203            �           0    0    reservations_reservation_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.reservations_reservation_id_seq', 1, false);
          public          postgres    false    205            �           0    0    showings_showing_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.showings_showing_id_seq', 1, false);
          public          postgres    false    207            �           0    0    users_user_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.users_user_id_seq', 7, true);
          public          postgres    false    209            >           2606    16431    hales hales_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.hales
    ADD CONSTRAINT hales_pkey PRIMARY KEY (hall_id);
 :   ALTER TABLE ONLY public.hales DROP CONSTRAINT hales_pkey;
       public            postgres    false    200            @           2606    16433    movies movies_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.movies
    ADD CONSTRAINT movies_pkey PRIMARY KEY (movie_id);
 <   ALTER TABLE ONLY public.movies DROP CONSTRAINT movies_pkey;
       public            postgres    false    202            C           2606    16435    reservations reservations_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_pkey PRIMARY KEY (reservation_id);
 H   ALTER TABLE ONLY public.reservations DROP CONSTRAINT reservations_pkey;
       public            postgres    false    204            G           2606    16437    showings showings_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT showings_pkey PRIMARY KEY (showing_id);
 @   ALTER TABLE ONLY public.showings DROP CONSTRAINT showings_pkey;
       public            postgres    false    206            I           2606    16439    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    208            D           1259    16440    fki_fk_showings_hall_id    INDEX     W   CREATE INDEX fki_fk_showings_hall_id ON public.showings USING btree (showing_hall_id);
 +   DROP INDEX public.fki_fk_showings_hall_id;
       public            postgres    false    206            E           1259    16441    fki_fk_showings_movie_id    INDEX     Y   CREATE INDEX fki_fk_showings_movie_id ON public.showings USING btree (showing_movie_id);
 ,   DROP INDEX public.fki_fk_showings_movie_id;
       public            postgres    false    206            A           1259    16442    fki_reservations_showing_id    INDEX     f   CREATE INDEX fki_reservations_showing_id ON public.reservations USING btree (reservation_showing_id);
 /   DROP INDEX public.fki_reservations_showing_id;
       public            postgres    false    204            J           2606    16443 '   reservations fk_reservations_showing_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT fk_reservations_showing_id FOREIGN KEY (reservation_showing_id) REFERENCES public.reservations(reservation_id) NOT VALID;
 Q   ALTER TABLE ONLY public.reservations DROP CONSTRAINT fk_reservations_showing_id;
       public          postgres    false    204    2883    204            K           2606    16448 $   reservations fk_reservations_user_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT fk_reservations_user_id FOREIGN KEY (reservation_user_id) REFERENCES public.users(user_id);
 N   ALTER TABLE ONLY public.reservations DROP CONSTRAINT fk_reservations_user_id;
       public          postgres    false    204    2889    208            L           2606    16453    showings fk_showings_hall_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT fk_showings_hall_id FOREIGN KEY (showing_hall_id) REFERENCES public.hales(hall_id) NOT VALID;
 F   ALTER TABLE ONLY public.showings DROP CONSTRAINT fk_showings_hall_id;
       public          postgres    false    200    2878    206            M           2606    16458    showings fk_showings_movie_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT fk_showings_movie_id FOREIGN KEY (showing_movie_id) REFERENCES public.movies(movie_id) NOT VALID;
 G   ALTER TABLE ONLY public.showings DROP CONSTRAINT fk_showings_movie_id;
       public          postgres    false    2880    202    206            �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �   �   x���B@  �g~�L�2#=�!LV��N/�.KQ$_�92G������BZ0��89�� `ie[e�q���W�������:��mn�(Zt)S$}�C�^��[�[�꿨^�����>�a����"E�+�j�b:�{N{�u^ѹP��Ք����~;�<Xp��Ԑ�����-�?B     