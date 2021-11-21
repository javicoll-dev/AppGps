-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-11-2021 a las 00:26:42
-- Versión del servidor: 10.4.21-MariaDB
-- Versión de PHP: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `parqueaderoec`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `parqueaderos`
--

CREATE TABLE `parqueaderos` (
  `id` int(11) NOT NULL,
  `establecimiento` varchar(100) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `latitud` double NOT NULL,
  `longitud` double NOT NULL,
  `Horario` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `parqueaderos`
--

INSERT INTO `parqueaderos` (`id`, `establecimiento`, `direccion`, `latitud`, `longitud`, `Horario`) VALUES
(1, 'Parqueadero Publico', 'Chile Oe9-78, Quito 170401', -0.21635, -78.51624, 'Lunes a Domingo / Monday to Sunday - 24 Horas / 24 Hours'),
(2, 'La Merced', 'Imbabura Oe8-133', -2.21724, -78.51471, 'Lunes a Domingo / Monday to Sunday - 7h00 - 18h00'),
(3, 'Imbabura', 'Imbabura N3-43 ', -0.21884, -78.51621, 'Lunes a Domingo / Monday to Sunday - 7h00 - 20h00'),
(4, 'Chile', 'Chile Oe6-78', -2.21887, -78.51328, 'Lunes a Domingo / Monday to Sunday - 7h00 - 20h00'),
(5, 'Simon Bolivar', 'Simon Bolivar Oe8-50', -0.21986, -78.51707, 'Lunes a Domingo / Monday to Sunday - 24 hours'),
(6, 'La Merced Cotopaxi', 'Manbic Cotopaxi', -0.21603, -78.51299, 'Lunes a Domingo / Monday to Sunday - 24 Horas / 24 Hours'),
(7, 'Jose J. Olmedo', 'Jose J.Olmedo N6-80', -0.21679, -78.5131, 'Lunes a Domingo / Monday to Sunday - 7h00 - 20h00'),
(8, 'Sebastián', 'Sebastián de Benalcazar', -0.21795, -78.51209, 'Lunes a Domingo / Monday to Sunday - 7h00 - 19h00'),
(9, 'Cdisan', 'Mejía', -0.21853, -78.51206, 'Lunes a Domingo / Monday to Sunday - 24 hours'),
(10, 'Montufar', 'Antonio Bustamante', -0.22031, -78.50879, 'Lunes a Domingo / Monday to Sunday - 7h00 - 19h00'),
(11, 'San Blas', 'Guayaquil y Francisco de Caldas', -0.21724, -78.50578, 'Lunes a Domingo / Monday to Sunday - 24 hours'),
(12, 'Sucre', 'Calle Sucre E1-122', -0.22446, -78.51017, 'Lunes a Domingo / Monday to Sunday - 7h00 - 20h00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nombres` varchar(40) NOT NULL,
  `apellidos` varchar(40) NOT NULL,
  `correo` varchar(50) NOT NULL,
  `usuario` varchar(40) NOT NULL,
  `contrasena` varchar(40) NOT NULL,
  `placa` varchar(10) DEFAULT NULL,
  `modelo` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `nombres`, `apellidos`, `correo`, `usuario`, `contrasena`, `placa`, `modelo`) VALUES
(1, 'Jorge Andres', 'Haro Rosales', 'andres.hr.1991@gmail.com', 'aharo', 'aharo', NULL, NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `parqueaderos`
--
ALTER TABLE `parqueaderos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
