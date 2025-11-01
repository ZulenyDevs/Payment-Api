--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5
-- Dumped by pg_dump version 17.5

-- Started on 2025-10-31 00:06:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 41168)
-- Name: category; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.category (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    description text
);


ALTER TABLE public.category OWNER TO dev_user;

--
-- TOC entry 222 (class 1259 OID 41176)
-- Name: customer; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.customer (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    document_id character varying(50),
    external_id character varying(100),
    channel character varying(100)
);


ALTER TABLE public.customer OWNER TO dev_user;

--
-- TOC entry 219 (class 1259 OID 41165)
-- Name: financial_account; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.financial_account (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    number character varying(100) NOT NULL,
    currency character varying(10) NOT NULL,
    provider_id uuid NOT NULL,
    financial_institution_id uuid NOT NULL
);


ALTER TABLE public.financial_account OWNER TO dev_user;

--
-- TOC entry 217 (class 1259 OID 41155)
-- Name: financial_institution; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.financial_institution (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    type character varying(100) NOT NULL,
    code character varying(50) NOT NULL,
    country character varying(100) NOT NULL
);


ALTER TABLE public.financial_institution OWNER TO dev_user;

--
-- TOC entry 224 (class 1259 OID 41232)
-- Name: payment; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.payment (
    id uuid NOT NULL,
    code character varying(100) NOT NULL,
    total_amount numeric(15,2) NOT NULL,
    currency character varying(10) NOT NULL,
    status character varying(50) NOT NULL,
    method character varying(100),
    channel character varying(100),
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    customer_id uuid NOT NULL
);


ALTER TABLE public.payment OWNER TO dev_user;

--
-- TOC entry 223 (class 1259 OID 41229)
-- Name: payment_service; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.payment_service (
    id uuid NOT NULL,
    billing_period character varying(50),
    amount numeric(15,2) NOT NULL,
    payment_id uuid NOT NULL,
    service_id uuid NOT NULL
);


ALTER TABLE public.payment_service OWNER TO dev_user;

--
-- TOC entry 218 (class 1259 OID 41160)
-- Name: provider; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.provider (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    nit character varying(50),
    address character varying(500),
    phone_number character varying(50)
);


ALTER TABLE public.provider OWNER TO dev_user;

--
-- TOC entry 221 (class 1259 OID 41173)
-- Name: service; Type: TABLE; Schema: public; Owner: dev_user
--

CREATE TABLE public.service (
    id uuid NOT NULL,
    name character varying(255) NOT NULL,
    category_id uuid NOT NULL,
    provider_id uuid NOT NULL
);


ALTER TABLE public.service OWNER TO dev_user;

--
-- TOC entry 4840 (class 0 OID 41168)
-- Dependencies: 220
-- Data for Name: category; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.category (id, name, description) FROM stdin;
d0e1f2a3-b4c5-4d5e-7f8a-9b0c1d2e3f4a	Utilities	Basic utility services including water, electricity, and gas
e1f2a3b4-c5d6-4e5f-8a9b-0c1d2e3f4a5b	Telecommunications	Phone, internet, and cable TV services
f2a3b4c5-d6e7-4f5a-9b0c-1d2e3f4a5b6c	Financial Services	Banking, loans, and insurance services
\.


--
-- TOC entry 4842 (class 0 OID 41176)
-- Dependencies: 222
-- Data for Name: customer; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.customer (id, name, document_id, external_id, channel) FROM stdin;
d6e7f8a9-b0c1-4d5e-3f4a-5b6c7d8e9f0a	Juan Pérez García	1234567 SC	CUST-001	Web Portal
e7f8a9b0-c1d2-4e5f-4a5b-6c7d8e9f0a1b	María López Fernández	7654321 SC	CUST-002	Mobile App
f8a9b0c1-d2e3-4f5a-5b6c-7d8e9f0a1b2c	Carlos Rodríguez Méndez	9876543 SC	CUST-003	Call Center
\.


--
-- TOC entry 4839 (class 0 OID 41165)
-- Dependencies: 219
-- Data for Name: financial_account; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.financial_account (id, name, number, currency, provider_id, financial_institution_id) FROM stdin;
a7b8c9d0-e1f2-4a5b-4c5d-6e7f8a9b0c1d	Cuenta Principal CRE	40012345678	BOB	d4e5f6a7-b8c9-4d5e-1f2a-3b4c5d6e7f8a	a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d
b8c9d0e1-f2a3-4b5c-5d6e-7f8a9b0c1d2e	Cuenta Servicios SAGUAPAC	50098765432	BOB	e5f6a7b8-c9d0-4e5f-2a3b-4c5d6e7f8a9b	b2c3d4e5-f6a7-4b5c-9d0e-1f2a3b4c5d6e
c9d0e1f2-a3b4-4c5d-6e7f-8a9b0c1d2e3f	Cuenta Recaudación Entel	60011223344	BOB	f6a7b8c9-d0e1-4f5a-3b4c-5d6e7f8a9b0c	c3d4e5f6-a7b8-4c5d-0e1f-2a3b4c5d6e7f
\.


--
-- TOC entry 4837 (class 0 OID 41155)
-- Dependencies: 217
-- Data for Name: financial_institution; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.financial_institution (id, name, type, code, country) FROM stdin;
a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d	Banco Nacional de Bolivia	Commercial Bank	BNB001	Bolivia
b2c3d4e5-f6a7-4b5c-9d0e-1f2a3b4c5d6e	Banco Mercantil Santa Cruz	Commercial Bank	BMSC002	Bolivia
c3d4e5f6-a7b8-4c5d-0e1f-2a3b4c5d6e7f	Banco BISA	Commercial Bank	BISA003	Bolivia
\.


--
-- TOC entry 4844 (class 0 OID 41232)
-- Dependencies: 224
-- Data for Name: payment; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.payment (id, code, total_amount, currency, status, method, channel, created_at, customer_id) FROM stdin;
a9b0c1d2-e3f4-4a5b-6c7d-8e9f0a1b2c3d	PAY-2024-001	450.00	BOB	Completed	Credit Card	Web Portal	2024-10-15 14:30:00-04	d6e7f8a9-b0c1-4d5e-3f4a-5b6c7d8e9f0a
b0c1d2e3-f4a5-4b5c-7d8e-9f0a1b2c3d4e	PAY-2024-002	120.50	BOB	Completed	Debit Card	Mobile App	2024-10-18 09:15:00-04	e7f8a9b0-c1d2-4e5f-4a5b-6c7d8e9f0a1b
c1d2e3f4-a5b6-4c5d-8e9f-0a1b2c3d4e5f	PAY-2024-003	250.75	BOB	Pending	Bank Transfer	Call Center	2024-10-25 16:45:00-04	f8a9b0c1-d2e3-4f5a-5b6c-7d8e9f0a1b2c
\.


--
-- TOC entry 4843 (class 0 OID 41229)
-- Dependencies: 223
-- Data for Name: payment_service; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.payment_service (id, billing_period, amount, payment_id, service_id) FROM stdin;
11111111-1111-1111-1111-111111111111	2024-10	450.00	a9b0c1d2-e3f4-4a5b-6c7d-8e9f0a1b2c3d	a3b4c5d6-e7f8-4a5b-0c1d-2e3f4a5b6c7d
22222222-2222-2222-2222-222222222222	2024-10	120.50	b0c1d2e3-f4a5-4b5c-7d8e-9f0a1b2c3d4e	b4c5d6e7-f8a9-4b5c-1d2e-3f4a5b6c7d8e
33333333-3333-3333-3333-333333333333	2024-10	250.75	c1d2e3f4-a5b6-4c5d-8e9f-0a1b2c3d4e5f	c5d6e7f8-a9b0-4c5d-2e3f-4a5b6c7d8e9f
\.


--
-- TOC entry 4838 (class 0 OID 41160)
-- Dependencies: 218
-- Data for Name: provider; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.provider (id, name, nit, address, phone_number) FROM stdin;
d4e5f6a7-b8c9-4d5e-1f2a-3b4c5d6e7f8a	Cooperativa de Electricidad CRE	1234567890	Av. Cristo Redentor #500	+591-3-3636000
e5f6a7b8-c9d0-4e5f-2a3b-4c5d6e7f8a9b	SAGUAPAC - Agua Potable	0987654321	Av. Roca y Coronado	+591-3-3487000
f6a7b8c9-d0e1-4f5a-3b4c-5d6e7f8a9b0c	Entel Telecomunicaciones	1122334455	Calle Warnes #120	+591-800-10-2000
\.


--
-- TOC entry 4841 (class 0 OID 41173)
-- Dependencies: 221
-- Data for Name: service; Type: TABLE DATA; Schema: public; Owner: dev_user
--

COPY public.service (id, name, category_id, provider_id) FROM stdin;
a3b4c5d6-e7f8-4a5b-0c1d-2e3f4a5b6c7d	Electricity Billing	d0e1f2a3-b4c5-4d5e-7f8a-9b0c1d2e3f4a	d4e5f6a7-b8c9-4d5e-1f2a-3b4c5d6e7f8a
b4c5d6e7-f8a9-4b5c-1d2e-3f4a5b6c7d8e	Water Supply	d0e1f2a3-b4c5-4d5e-7f8a-9b0c1d2e3f4a	e5f6a7b8-c9d0-4e5f-2a3b-4c5d6e7f8a9b
c5d6e7f8-a9b0-4c5d-2e3f-4a5b6c7d8e9f	Mobile Phone Plan	e1f2a3b4-c5d6-4e5f-8a9b-0c1d2e3f4a5b	f6a7b8c9-d0e1-4f5a-3b4c-5d6e7f8a9b0c
\.


--
-- TOC entry 4676 (class 2606 OID 41192)
-- Name: category category_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);


--
-- TOC entry 4680 (class 2606 OID 41196)
-- Name: customer customer_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_pkey PRIMARY KEY (id);


--
-- TOC entry 4674 (class 2606 OID 41190)
-- Name: financial_account financial_account_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.financial_account
    ADD CONSTRAINT financial_account_pkey PRIMARY KEY (id);


--
-- TOC entry 4670 (class 2606 OID 41186)
-- Name: financial_institution financial_institution_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.financial_institution
    ADD CONSTRAINT financial_institution_pkey PRIMARY KEY (id);


--
-- TOC entry 4684 (class 2606 OID 41239)
-- Name: payment payment_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_pkey PRIMARY KEY (id);


--
-- TOC entry 4682 (class 2606 OID 41237)
-- Name: payment_service payment_service_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.payment_service
    ADD CONSTRAINT payment_service_pkey PRIMARY KEY (id);


--
-- TOC entry 4672 (class 2606 OID 41188)
-- Name: provider provider_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.provider
    ADD CONSTRAINT provider_pkey PRIMARY KEY (id);


--
-- TOC entry 4678 (class 2606 OID 41194)
-- Name: service service_pkey; Type: CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.service
    ADD CONSTRAINT service_pkey PRIMARY KEY (id);


--
-- TOC entry 4685 (class 2606 OID 41204)
-- Name: financial_account fk_financial_account_institution; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.financial_account
    ADD CONSTRAINT fk_financial_account_institution FOREIGN KEY (financial_institution_id) REFERENCES public.financial_institution(id) ON DELETE RESTRICT;


--
-- TOC entry 4686 (class 2606 OID 41199)
-- Name: financial_account fk_financial_account_provider; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.financial_account
    ADD CONSTRAINT fk_financial_account_provider FOREIGN KEY (provider_id) REFERENCES public.provider(id) ON DELETE RESTRICT;


--
-- TOC entry 4691 (class 2606 OID 41250)
-- Name: payment fk_payment_customer; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT fk_payment_customer FOREIGN KEY (customer_id) REFERENCES public.customer(id) ON DELETE RESTRICT;


--
-- TOC entry 4689 (class 2606 OID 41240)
-- Name: payment_service fk_payment_service_payment; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.payment_service
    ADD CONSTRAINT fk_payment_service_payment FOREIGN KEY (payment_id) REFERENCES public.payment(id) ON DELETE CASCADE;


--
-- TOC entry 4690 (class 2606 OID 41245)
-- Name: payment_service fk_payment_service_service; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.payment_service
    ADD CONSTRAINT fk_payment_service_service FOREIGN KEY (service_id) REFERENCES public.service(id) ON DELETE RESTRICT;


--
-- TOC entry 4687 (class 2606 OID 41209)
-- Name: service fk_service_category; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.service
    ADD CONSTRAINT fk_service_category FOREIGN KEY (category_id) REFERENCES public.category(id) ON DELETE RESTRICT;


--
-- TOC entry 4688 (class 2606 OID 41214)
-- Name: service fk_service_provider; Type: FK CONSTRAINT; Schema: public; Owner: dev_user
--

ALTER TABLE ONLY public.service
    ADD CONSTRAINT fk_service_provider FOREIGN KEY (provider_id) REFERENCES public.provider(id) ON DELETE RESTRICT;


-- Completed on 2025-10-31 00:06:19

--
-- PostgreSQL database dump complete
--

