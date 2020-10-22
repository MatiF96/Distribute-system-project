PGDMP                     	    x           dsp    12.0    12.0     &           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            '           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            (           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            )           1262    32768    dsp    DATABASE     �   CREATE DATABASE dsp WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Polish_Poland.1250' LC_CTYPE = 'Polish_Poland.1250';
    DROP DATABASE dsp;
                postgres    false            �            1259    32777    hales    TABLE     P   CREATE TABLE public.hales (
    hall_id integer NOT NULL,
    hall_name text
);
    DROP TABLE public.hales;
       public         heap    postgres    false            �            1259    32769    movies    TABLE     �   CREATE TABLE public.movies (
    movie_id integer NOT NULL,
    movie_title text NOT NULL,
    movie_duration interval[] NOT NULL
);
    DROP TABLE public.movies;
       public         heap    postgres    false            �            1259    32815    reservations    TABLE     �   CREATE TABLE public.reservations (
    reservation_id integer NOT NULL,
    reservation_showing_id integer NOT NULL,
    reservation_user_id integer NOT NULL,
    reservation_seat integer NOT NULL
);
     DROP TABLE public.reservations;
       public         heap    postgres    false            �            1259    32785    showings    TABLE     �   CREATE TABLE public.showings (
    showing_id integer NOT NULL,
    showing_movie_id integer NOT NULL,
    showing_hall_id integer NOT NULL,
    showing_date timestamp with time zone NOT NULL
);
    DROP TABLE public.showings;
       public         heap    postgres    false            �            1259    32807    users    TABLE     �   CREATE TABLE public.users (
    user_id integer NOT NULL,
    user_login text NOT NULL,
    user_password text NOT NULL,
    user_type text NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false                       0    32777    hales 
   TABLE DATA           3   COPY public.hales (hall_id, hall_name) FROM stdin;
    public          postgres    false    203   �                 0    32769    movies 
   TABLE DATA           G   COPY public.movies (movie_id, movie_title, movie_duration) FROM stdin;
    public          postgres    false    202   �       #          0    32815    reservations 
   TABLE DATA           u   COPY public.reservations (reservation_id, reservation_showing_id, reservation_user_id, reservation_seat) FROM stdin;
    public          postgres    false    206   �       !          0    32785    showings 
   TABLE DATA           _   COPY public.showings (showing_id, showing_movie_id, showing_hall_id, showing_date) FROM stdin;
    public          postgres    false    204   �       "          0    32807    users 
   TABLE DATA           N   COPY public.users (user_id, user_login, user_password, user_type) FROM stdin;
    public          postgres    false    205          �
           2606    32784    hales hales_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.hales
    ADD CONSTRAINT hales_pkey PRIMARY KEY (hall_id);
 :   ALTER TABLE ONLY public.hales DROP CONSTRAINT hales_pkey;
       public            postgres    false    203            �
           2606    32776    movies movies_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.movies
    ADD CONSTRAINT movies_pkey PRIMARY KEY (movie_id);
 <   ALTER TABLE ONLY public.movies DROP CONSTRAINT movies_pkey;
       public            postgres    false    202            �
           2606    32819    reservations reservations_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT reservations_pkey PRIMARY KEY (reservation_id);
 H   ALTER TABLE ONLY public.reservations DROP CONSTRAINT reservations_pkey;
       public            postgres    false    206            �
           2606    32789    showings showings_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT showings_pkey PRIMARY KEY (showing_id);
 @   ALTER TABLE ONLY public.showings DROP CONSTRAINT showings_pkey;
       public            postgres    false    204            �
           2606    32814    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    205            �
           1259    32806    fki_fk_showings_hall_id    INDEX     W   CREATE INDEX fki_fk_showings_hall_id ON public.showings USING btree (showing_hall_id);
 +   DROP INDEX public.fki_fk_showings_hall_id;
       public            postgres    false    204            �
           1259    32800    fki_fk_showings_movie_id    INDEX     Y   CREATE INDEX fki_fk_showings_movie_id ON public.showings USING btree (showing_movie_id);
 ,   DROP INDEX public.fki_fk_showings_movie_id;
       public            postgres    false    204            �
           1259    32835    fki_reservations_showing_id    INDEX     f   CREATE INDEX fki_reservations_showing_id ON public.reservations USING btree (reservation_showing_id);
 /   DROP INDEX public.fki_reservations_showing_id;
       public            postgres    false    206            �
           2606    32830 '   reservations fk_reservations_showing_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT fk_reservations_showing_id FOREIGN KEY (reservation_showing_id) REFERENCES public.reservations(reservation_id) NOT VALID;
 Q   ALTER TABLE ONLY public.reservations DROP CONSTRAINT fk_reservations_showing_id;
       public          postgres    false    206    206    2716            �
           2606    32825 $   reservations fk_reservations_user_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.reservations
    ADD CONSTRAINT fk_reservations_user_id FOREIGN KEY (reservation_user_id) REFERENCES public.users(user_id);
 N   ALTER TABLE ONLY public.reservations DROP CONSTRAINT fk_reservations_user_id;
       public          postgres    false    205    2713    206            �
           2606    32801    showings fk_showings_hall_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT fk_showings_hall_id FOREIGN KEY (showing_hall_id) REFERENCES public.hales(hall_id) NOT VALID;
 F   ALTER TABLE ONLY public.showings DROP CONSTRAINT fk_showings_hall_id;
       public          postgres    false    204    203    2707            �
           2606    32795    showings fk_showings_movie_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.showings
    ADD CONSTRAINT fk_showings_movie_id FOREIGN KEY (showing_movie_id) REFERENCES public.movies(movie_id) NOT VALID;
 G   ALTER TABLE ONLY public.showings DROP CONSTRAINT fk_showings_movie_id;
       public          postgres    false    2705    202    204                   x������ � �            x������ � �      #      x������ � �      !      x������ � �      "      x������ � �     