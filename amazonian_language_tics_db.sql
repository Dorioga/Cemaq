/*
 Navicat Premium Data Transfer

 Source Server         : BD_Localhost
 Source Server Type    : MySQL
 Source Server Version : 80016
 Source Host           : localhost:3306
 Source Schema         : amazonian_language_tics_db

 Target Server Type    : MySQL
 Target Server Version : 80016
 File Encoding         : 65001

 Date: 31/07/2019 11:52:10
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for actividad
-- ----------------------------
DROP TABLE IF EXISTS `actividad`;
CREATE TABLE `actividad`  (
  `id_actividad` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_actividad` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_actividad` varchar(500) CHARACTER SET utf8mb4  NULL DEFAULT NULL,
  `estado_actividad` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Tipo_Actividadid_tipo_actividad` int(10) NOT NULL,
  `Unidadid_unidad` int(10) NOT NULL,
  PRIMARY KEY (`id_actividad`) USING BTREE,
  INDEX `FKActividad835998`(`Tipo_Actividadid_tipo_actividad`) USING BTREE,
  INDEX `FKActividad901382`(`Unidadid_unidad`) USING BTREE,
  CONSTRAINT `FKActividad835998` FOREIGN KEY (`Tipo_Actividadid_tipo_actividad`) REFERENCES `tipo_actividad` (`id_tipo_actividad`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKActividad901382` FOREIGN KEY (`Unidadid_unidad`) REFERENCES `unidad` (`id_unidad`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of actividad
-- ----------------------------
INSERT INTO `actividad` VALUES (1, 'Pronombres subjeto', 'Subject pronouns may refer to people, animals or things.', 'Y', 1, 1);
INSERT INTO `actividad` VALUES (2, 'Pronombre objeto', 'Object pronouns have the function of replacing a noun in a sentence. ', 'Y', 1, 1);
INSERT INTO `actividad` VALUES (3, 'Pronombre posesivo', 'The possessive pronouns indicate possession and are invariable. They are never preceded by an article.', 'Y', 1, 1);
INSERT INTO `actividad` VALUES (4, 'Pronombre reflexivo', 'We use a reflexive pronoun when we want to refer back to the subject of the sentence or clause.', 'Y', 1, 1);
INSERT INTO `actividad` VALUES (5, 'Verbo to be', 'The verb to be is an irregular verb and it is one of the most important and useful verb in language english.\r\nThe verb to be in spanish means (ser/estar).\r\nThe verb to be has the following forms: \r\n', 'Y', 1, 2);
INSERT INTO `actividad` VALUES (6, 'Verbos (to have, to go , to want, todo)', 'sdasdsafsdgsdgsdf', 'Y', 1, 2);
INSERT INTO `actividad` VALUES (7, 'Articulo determinado', 'asdasfsdkjdfalskj', 'Y', 1, 3);
INSERT INTO `actividad` VALUES (8, 'Articulo indeterminado', 'asdasdasdajsdh', 'Y', 1, 3);
INSERT INTO `actividad` VALUES (9, 'Preposiciones de lugar', 'asdailfkjsdhfsdjkfh', 'Y', 1, 4);
INSERT INTO `actividad` VALUES (10, 'Preposiciones de tiempo', 'djaskdajsdl', 'Y', 1, 4);
INSERT INTO `actividad` VALUES (11, 'Preposiciones de movimiento o direccion', 'sdf9sdjqlskdj', 'Y', 1, 4);
INSERT INTO `actividad` VALUES (12, 'Sustantivos', 'aqeqweq', 'Y', 1, 5);
INSERT INTO `actividad` VALUES (13, 'Adjetivos', 'kdjjdjdjdjdj', 'Y', 1, 5);

-- ----------------------------
-- Table structure for clasificacion
-- ----------------------------
DROP TABLE IF EXISTS `clasificacion`;
CREATE TABLE `clasificacion`  (
  `id_clasificacion` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_clasificacion` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_clasificacion` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_clasificacion`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of clasificacion
-- ----------------------------
INSERT INTO `clasificacion` VALUES (1, 'Infantil', 'nn');
INSERT INTO `clasificacion` VALUES (2, 'Jovenes', 'nn');
INSERT INTO `clasificacion` VALUES (3, 'Adultos', 'nn');
INSERT INTO `clasificacion` VALUES (4, 'Todos', 'nn');

-- ----------------------------
-- Table structure for contrato
-- ----------------------------
DROP TABLE IF EXISTS `contrato`;
CREATE TABLE `contrato`  (
  `id_contrato` int(10) NOT NULL,
  `nombre_contrato` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_contrato` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `salario_contrato` double NOT NULL,
  `url_contrato` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `fecha_inicio_contrato` date NOT NULL,
  `fecha_fin_contrato` date NOT NULL,
  `estado_contrato` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Tipo_Contratoid_tipo_contrato` int(10) NOT NULL,
  `Horarioid_horario` int(10) NOT NULL,
  PRIMARY KEY (`id_contrato`) USING BTREE,
  INDEX `FKContrato170894`(`Horarioid_horario`) USING BTREE,
  INDEX `FKContrato771757`(`Tipo_Contratoid_tipo_contrato`) USING BTREE,
  CONSTRAINT `FKContrato170894` FOREIGN KEY (`Horarioid_horario`) REFERENCES `horario` (`id_horario`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKContrato771757` FOREIGN KEY (`Tipo_Contratoid_tipo_contrato`) REFERENCES `tipo_contrato` (`id_tipo_contrato`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of contrato
-- ----------------------------
INSERT INTO `contrato` VALUES (1534, 'Contrato 1 ', 'nn', 45000000, 'https:/ c1.com(c1', '2019-07-24', '2019-09-01', 'Y', 1, 2);

-- ----------------------------
-- Table structure for contrato_empresa
-- ----------------------------
DROP TABLE IF EXISTS `contrato_empresa`;
CREATE TABLE `contrato_empresa`  (
  `Contratoid_contrato` int(10) NOT NULL,
  `Empresaid_empresa` int(10) NOT NULL,
  `estado_pago_empresa_contrato` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`Contratoid_contrato`, `Empresaid_empresa`) USING BTREE,
  INDEX `FKContrato_E79152`(`Empresaid_empresa`) USING BTREE,
  CONSTRAINT `FKContrato_E778616` FOREIGN KEY (`Contratoid_contrato`) REFERENCES `contrato` (`id_contrato`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKContrato_E79152` FOREIGN KEY (`Empresaid_empresa`) REFERENCES `empresa` (`id_empresa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of contrato_empresa
-- ----------------------------
INSERT INTO `contrato_empresa` VALUES (1534, 25478, 'Y');

-- ----------------------------
-- Table structure for curso
-- ----------------------------
DROP TABLE IF EXISTS `curso`;
CREATE TABLE `curso`  (
  `id_curso` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_curso` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_curso` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_curso` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Tematica_Cursoid_tematica_curso` int(10) NOT NULL,
  PRIMARY KEY (`id_curso`) USING BTREE,
  INDEX `FKCurso226657`(`Tematica_Cursoid_tematica_curso`) USING BTREE,
  CONSTRAINT `FKCurso226657` FOREIGN KEY (`Tematica_Cursoid_tematica_curso`) REFERENCES `tematica_curso` (`id_tematica_curso`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of curso
-- ----------------------------
INSERT INTO `curso` VALUES (1, 'Ingles', 'nn', 'Y', 1);
INSERT INTO `curso` VALUES (2, 'Matematicas', 'nn', 'Y', 2);

-- ----------------------------
-- Table structure for curso_nivel
-- ----------------------------
DROP TABLE IF EXISTS `curso_nivel`;
CREATE TABLE `curso_nivel`  (
  `Id_curso_nivel` int(11) NOT NULL AUTO_INCREMENT,
  `Cursoid_curso` int(10) NOT NULL,
  `Nivelid_nivel` int(10) NOT NULL,
  `fecha_inicio_curso_nivel` date NOT NULL,
  PRIMARY KEY (`Cursoid_curso`, `Nivelid_nivel`, `Id_curso_nivel`) USING BTREE,
  INDEX `FKCurso_Nive440242`(`Nivelid_nivel`) USING BTREE,
  INDEX `Id_curso_nivel`(`Id_curso_nivel`) USING BTREE,
  CONSTRAINT `FKCurso_Nive440242` FOREIGN KEY (`Nivelid_nivel`) REFERENCES `nivel` (`id_nivel`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKCurso_Nive737156` FOREIGN KEY (`Cursoid_curso`) REFERENCES `curso` (`id_curso`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of curso_nivel
-- ----------------------------
INSERT INTO `curso_nivel` VALUES (4, 1, 1, '2019-07-25');
INSERT INTO `curso_nivel` VALUES (5, 1, 2, '2019-07-25');
INSERT INTO `curso_nivel` VALUES (6, 2, 1, '2019-07-25');
INSERT INTO `curso_nivel` VALUES (7, 2, 3, '2019-07-25');

-- ----------------------------
-- Table structure for curso_usuario
-- ----------------------------
DROP TABLE IF EXISTS `curso_usuario`;
CREATE TABLE `curso_usuario`  (
  `Cursoid_curso` int(10) NOT NULL,
  `Usuarioid_usuario` int(10) NOT NULL,
  `estado_usuario_curso` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `fecha_usuario_curso` date NOT NULL,
  PRIMARY KEY (`Cursoid_curso`, `Usuarioid_usuario`) USING BTREE,
  INDEX `FKCurso_Usua435223`(`Usuarioid_usuario`) USING BTREE,
  CONSTRAINT `FKCurso_Usua435223` FOREIGN KEY (`Usuarioid_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKCurso_Usua68207` FOREIGN KEY (`Cursoid_curso`) REFERENCES `curso` (`id_curso`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of curso_usuario
-- ----------------------------
INSERT INTO `curso_usuario` VALUES (1, 1, 'Y', '2019-07-22');
INSERT INTO `curso_usuario` VALUES (2, 1, 'Y', '2019-07-22');

-- ----------------------------
-- Table structure for departamento
-- ----------------------------
DROP TABLE IF EXISTS `departamento`;
CREATE TABLE `departamento`  (
  `id_departamento` int(10) NOT NULL,
  `nombre_departamento` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `Paisid_pais` int(10) NOT NULL,
  PRIMARY KEY (`id_departamento`) USING BTREE,
  INDEX `FKDepartamen330841`(`Paisid_pais`) USING BTREE,
  CONSTRAINT `FKDepartamen330841` FOREIGN KEY (`Paisid_pais`) REFERENCES `pais` (`id_pais`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of departamento
-- ----------------------------
INSERT INTO `departamento` VALUES (5, 'ANTIOQUIA', 57);
INSERT INTO `departamento` VALUES (8, 'ATLÁNTICO', 57);
INSERT INTO `departamento` VALUES (11, 'BOGOTÁ, D.C.', 57);
INSERT INTO `departamento` VALUES (13, 'BOLÍVAR', 57);
INSERT INTO `departamento` VALUES (15, 'BOYACÁ', 57);
INSERT INTO `departamento` VALUES (17, 'CALDAS', 57);
INSERT INTO `departamento` VALUES (18, 'CAQUETÁ', 57);
INSERT INTO `departamento` VALUES (19, 'CAUCA', 57);
INSERT INTO `departamento` VALUES (20, 'CESAR', 57);
INSERT INTO `departamento` VALUES (23, 'CÓRDOBA', 57);
INSERT INTO `departamento` VALUES (25, 'CUNDINAMARCA', 57);
INSERT INTO `departamento` VALUES (27, 'CHOCÓ', 57);
INSERT INTO `departamento` VALUES (41, 'HUILA', 57);
INSERT INTO `departamento` VALUES (44, 'LA GUAJIRA', 57);
INSERT INTO `departamento` VALUES (47, 'MAGDALENA', 57);
INSERT INTO `departamento` VALUES (50, 'META', 57);
INSERT INTO `departamento` VALUES (52, 'NARIÑO', 57);
INSERT INTO `departamento` VALUES (54, 'NORTE DE SANTANDER', 57);
INSERT INTO `departamento` VALUES (63, 'QUINDIO', 57);
INSERT INTO `departamento` VALUES (66, 'RISARALDA', 57);
INSERT INTO `departamento` VALUES (68, 'SANTANDER', 57);
INSERT INTO `departamento` VALUES (70, 'SUCRE', 57);
INSERT INTO `departamento` VALUES (73, 'TOLIMA', 57);
INSERT INTO `departamento` VALUES (76, 'VALLE DEL CAUCA', 57);
INSERT INTO `departamento` VALUES (81, 'ARAUCA', 57);
INSERT INTO `departamento` VALUES (85, 'CASANARE', 57);
INSERT INTO `departamento` VALUES (86, 'PUTUMAYO', 57);
INSERT INTO `departamento` VALUES (88, 'ARCHIPIÉLAGO DE SAN ANDRÉS, PROVIDENCIA Y SANTA CATALINA', 57);
INSERT INTO `departamento` VALUES (91, 'AMAZONAS', 57);
INSERT INTO `departamento` VALUES (94, 'GUAINÍA', 57);
INSERT INTO `departamento` VALUES (95, 'GUAVIARE', 57);
INSERT INTO `departamento` VALUES (97, 'VAUPÉS', 57);
INSERT INTO `departamento` VALUES (99, 'VICHADA', 57);

-- ----------------------------
-- Table structure for empleado
-- ----------------------------
DROP TABLE IF EXISTS `empleado`;
CREATE TABLE `empleado`  (
  `PersonaId_Persona` int(10) NOT NULL,
  `id_empleado` int(10) NOT NULL AUTO_INCREMENT,
  `estado_empleado` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_empleado`) USING BTREE,
  INDEX `FKEmpleado361843`(`PersonaId_Persona`) USING BTREE,
  CONSTRAINT `FKEmpleado361843` FOREIGN KEY (`PersonaId_Persona`) REFERENCES `persona` (`id_persona`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of empleado
-- ----------------------------
INSERT INTO `empleado` VALUES (1117528719, 1, 'Y');

-- ----------------------------
-- Table structure for empleado_contrato
-- ----------------------------
DROP TABLE IF EXISTS `empleado_contrato`;
CREATE TABLE `empleado_contrato`  (
  `Empleadoid_empleado` int(10) NOT NULL,
  `Contratoid_contrato` int(10) NOT NULL,
  `estado_empleado_contrato` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`Empleadoid_empleado`, `Contratoid_contrato`) USING BTREE,
  INDEX `FKEmpleado_C523998`(`Contratoid_contrato`) USING BTREE,
  CONSTRAINT `FKEmpleado_C100423` FOREIGN KEY (`Empleadoid_empleado`) REFERENCES `empleado` (`id_empleado`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKEmpleado_C523998` FOREIGN KEY (`Contratoid_contrato`) REFERENCES `contrato` (`id_contrato`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of empleado_contrato
-- ----------------------------
INSERT INTO `empleado_contrato` VALUES (1, 1534, 'Y');

-- ----------------------------
-- Table structure for empresa
-- ----------------------------
DROP TABLE IF EXISTS `empresa`;
CREATE TABLE `empresa`  (
  `id_empresa` int(10) NOT NULL,
  `nombre_empresa` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  `email_empresa` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  `telefono_empresa` int(10) NOT NULL,
  `estado_empresa` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Tipo_Empresaid_tipo_empresa` int(10) NOT NULL,
  PRIMARY KEY (`id_empresa`) USING BTREE,
  INDEX `FKEmpresa317744`(`Tipo_Empresaid_tipo_empresa`) USING BTREE,
  CONSTRAINT `FKEmpresa317744` FOREIGN KEY (`Tipo_Empresaid_tipo_empresa`) REFERENCES `tipo_empresa` (`id_tipo_empresa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of empresa
-- ----------------------------
INSERT INTO `empresa` VALUES (25478, 'pepito corp', 'p@pepito.org', 123456789, 'Y', 2);

-- ----------------------------
-- Table structure for empresa_municipio
-- ----------------------------
DROP TABLE IF EXISTS `empresa_municipio`;
CREATE TABLE `empresa_municipio`  (
  `Empresaid_empresa` int(10) NOT NULL,
  `Municipioid_municipio` int(10) NOT NULL,
  `seccional_empresa_municipio` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`Empresaid_empresa`, `Municipioid_municipio`) USING BTREE,
  INDEX `FKEmpresa_Mu711492`(`Municipioid_municipio`) USING BTREE,
  CONSTRAINT `FKEmpresa_Mu711492` FOREIGN KEY (`Municipioid_municipio`) REFERENCES `municipio` (`id_municipio`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKEmpresa_Mu869642` FOREIGN KEY (`Empresaid_empresa`) REFERENCES `empresa` (`id_empresa`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of empresa_municipio
-- ----------------------------
INSERT INTO `empresa_municipio` VALUES (25478, 2, 'Principal');

-- ----------------------------
-- Table structure for examen
-- ----------------------------
DROP TABLE IF EXISTS `examen`;
CREATE TABLE `examen`  (
  `id_examen` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_examen` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_examen` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `nota_examen` float NULL DEFAULT NULL,
  `Tipo_Examenid_tipo_examen` int(10) NOT NULL,
  PRIMARY KEY (`id_examen`) USING BTREE,
  INDEX `FKExamen20461`(`Tipo_Examenid_tipo_examen`) USING BTREE,
  CONSTRAINT `FKExamen20461` FOREIGN KEY (`Tipo_Examenid_tipo_examen`) REFERENCES `tipo_examen` (`id_tipo_examen`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of examen
-- ----------------------------
INSERT INTO `examen` VALUES (1, 'Examen 1', 'nn', NULL, 1);

-- ----------------------------
-- Table structure for horario
-- ----------------------------
DROP TABLE IF EXISTS `horario`;
CREATE TABLE `horario`  (
  `id_horario` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_horario` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_horario` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_horario` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_horario`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of horario
-- ----------------------------
INSERT INTO `horario` VALUES (1, 'Mañana', 'Horario encargado de 8:00 am hasta las 12:00m', 'Y');
INSERT INTO `horario` VALUES (2, 'Tarde', 'Horario encargadado de 2:00 pm hasta las 6:00 pm', 'Y');

-- ----------------------------
-- Table structure for multimedia
-- ----------------------------
DROP TABLE IF EXISTS `multimedia`;
CREATE TABLE `multimedia`  (
  `id_multimedia` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_multimedia` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `url_multimedia` varchar(255) CHARACTER SET utf8mb4  NULL DEFAULT NULL,
  `estado_multimedia` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Clasificacionid_clasificacion` int(10) NOT NULL,
  `Tipo_Multimediaid_tipo_multimedia` int(10) NOT NULL,
  `Seccionid_seccion` int(10) NOT NULL,
  PRIMARY KEY (`id_multimedia`) USING BTREE,
  INDEX `FKMultimedia902131`(`Clasificacionid_clasificacion`) USING BTREE,
  INDEX `FKMultimedia557723`(`Tipo_Multimediaid_tipo_multimedia`) USING BTREE,
  INDEX `FKMultimedia60114`(`Seccionid_seccion`) USING BTREE,
  CONSTRAINT `FKMultimedia557723` FOREIGN KEY (`Tipo_Multimediaid_tipo_multimedia`) REFERENCES `tipo_multimedia` (`id_tipo_multimedia`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKMultimedia60114` FOREIGN KEY (`Seccionid_seccion`) REFERENCES `seccion` (`id_seccion`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKMultimedia902131` FOREIGN KEY (`Clasificacionid_clasificacion`) REFERENCES `clasificacion` (`id_clasificacion`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of multimedia
-- ----------------------------
INSERT INTO `multimedia` VALUES (1, 'Img_p_sub', 'nn,.com', 'Y', 4, 2, 1);
INSERT INTO `multimedia` VALUES (2, 'Text_example', '', 'Y', 4, 3, 2);
INSERT INTO `multimedia` VALUES (3, 'Imagen_p_obj', 'nnsdasd.com', 'Y', 4, 2, 3);
INSERT INTO `multimedia` VALUES (4, 'Text_example', NULL, 'Y', 4, 3, 4);
INSERT INTO `multimedia` VALUES (5, 'Img_p_pos', 'asdas.com', 'Y', 4, 2, 5);
INSERT INTO `multimedia` VALUES (6, 'Text_example', NULL, 'Y', 4, 3, 6);
INSERT INTO `multimedia` VALUES (7, 'Img_p_refl', 'asda.com', 'Y', 4, 2, 7);
INSERT INTO `multimedia` VALUES (8, 'Text_Example', NULL, 'Y', 4, 3, 8);

-- ----------------------------
-- Table structure for municipio
-- ----------------------------
DROP TABLE IF EXISTS `municipio`;
CREATE TABLE `municipio`  (
  `id_municipio` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_municipio` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `Departamentoid_departamento` int(10) NOT NULL,
  PRIMARY KEY (`id_municipio`) USING BTREE,
  INDEX `FKMunicipio88017`(`Departamentoid_departamento`) USING BTREE,
  CONSTRAINT `FKMunicipio88017` FOREIGN KEY (`Departamentoid_departamento`) REFERENCES `departamento` (`id_departamento`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1101 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of municipio
-- ----------------------------
INSERT INTO `municipio` VALUES (1, 'Abriaquí', 5);
INSERT INTO `municipio` VALUES (2, 'Acacías', 50);
INSERT INTO `municipio` VALUES (3, 'Acandí', 27);
INSERT INTO `municipio` VALUES (4, 'Acevedo', 41);
INSERT INTO `municipio` VALUES (5, 'Achí', 13);
INSERT INTO `municipio` VALUES (6, 'Agrado', 41);
INSERT INTO `municipio` VALUES (7, 'Agua de Dios', 25);
INSERT INTO `municipio` VALUES (8, 'Aguachica', 20);
INSERT INTO `municipio` VALUES (9, 'Aguada', 68);
INSERT INTO `municipio` VALUES (10, 'Aguadas', 17);
INSERT INTO `municipio` VALUES (11, 'Aguazul', 85);
INSERT INTO `municipio` VALUES (12, 'Agustín Codazzi', 20);
INSERT INTO `municipio` VALUES (13, 'Aipe', 41);
INSERT INTO `municipio` VALUES (14, 'Albania', 18);
INSERT INTO `municipio` VALUES (15, 'Albania', 44);
INSERT INTO `municipio` VALUES (16, 'Albania', 68);
INSERT INTO `municipio` VALUES (17, 'Albán', 25);
INSERT INTO `municipio` VALUES (18, 'Albán (San José)', 52);
INSERT INTO `municipio` VALUES (19, 'Alcalá', 76);
INSERT INTO `municipio` VALUES (20, 'Alejandria', 5);
INSERT INTO `municipio` VALUES (21, 'Algarrobo', 47);
INSERT INTO `municipio` VALUES (22, 'Algeciras', 41);
INSERT INTO `municipio` VALUES (23, 'Almaguer', 19);
INSERT INTO `municipio` VALUES (24, 'Almeida', 15);
INSERT INTO `municipio` VALUES (25, 'Alpujarra', 73);
INSERT INTO `municipio` VALUES (26, 'Altamira', 41);
INSERT INTO `municipio` VALUES (27, 'Alto Baudó (Pie de Pato)', 27);
INSERT INTO `municipio` VALUES (28, 'Altos del Rosario', 13);
INSERT INTO `municipio` VALUES (29, 'Alvarado', 73);
INSERT INTO `municipio` VALUES (30, 'Amagá', 5);
INSERT INTO `municipio` VALUES (31, 'Amalfi', 5);
INSERT INTO `municipio` VALUES (32, 'Ambalema', 73);
INSERT INTO `municipio` VALUES (33, 'Anapoima', 25);
INSERT INTO `municipio` VALUES (34, 'Ancuya', 52);
INSERT INTO `municipio` VALUES (35, 'Andalucía', 76);
INSERT INTO `municipio` VALUES (36, 'Andes', 5);
INSERT INTO `municipio` VALUES (37, 'Angelópolis', 5);
INSERT INTO `municipio` VALUES (38, 'Angostura', 5);
INSERT INTO `municipio` VALUES (39, 'Anolaima', 25);
INSERT INTO `municipio` VALUES (40, 'Anorí', 5);
INSERT INTO `municipio` VALUES (41, 'Anserma', 17);
INSERT INTO `municipio` VALUES (42, 'Ansermanuevo', 76);
INSERT INTO `municipio` VALUES (43, 'Anzoátegui', 73);
INSERT INTO `municipio` VALUES (44, 'Anzá', 5);
INSERT INTO `municipio` VALUES (45, 'Apartadó', 5);
INSERT INTO `municipio` VALUES (46, 'Apulo', 25);
INSERT INTO `municipio` VALUES (47, 'Apía', 66);
INSERT INTO `municipio` VALUES (48, 'Aquitania', 15);
INSERT INTO `municipio` VALUES (49, 'Aracataca', 47);
INSERT INTO `municipio` VALUES (50, 'Aranzazu', 17);
INSERT INTO `municipio` VALUES (51, 'Aratoca', 68);
INSERT INTO `municipio` VALUES (52, 'Arauca', 81);
INSERT INTO `municipio` VALUES (53, 'Arauquita', 81);
INSERT INTO `municipio` VALUES (54, 'Arbeláez', 25);
INSERT INTO `municipio` VALUES (55, 'Arboleda (Berruecos)', 52);
INSERT INTO `municipio` VALUES (56, 'Arboledas', 54);
INSERT INTO `municipio` VALUES (57, 'Arboletes', 5);
INSERT INTO `municipio` VALUES (58, 'Arcabuco', 15);
INSERT INTO `municipio` VALUES (59, 'Arenal', 13);
INSERT INTO `municipio` VALUES (60, 'Argelia', 5);
INSERT INTO `municipio` VALUES (61, 'Argelia', 19);
INSERT INTO `municipio` VALUES (62, 'Argelia', 76);
INSERT INTO `municipio` VALUES (63, 'Ariguaní (El Difícil)', 47);
INSERT INTO `municipio` VALUES (64, 'Arjona', 13);
INSERT INTO `municipio` VALUES (65, 'Armenia', 5);
INSERT INTO `municipio` VALUES (66, 'Armenia', 63);
INSERT INTO `municipio` VALUES (67, 'Armero (Guayabal)', 73);
INSERT INTO `municipio` VALUES (68, 'Arroyohondo', 13);
INSERT INTO `municipio` VALUES (69, 'Astrea', 20);
INSERT INTO `municipio` VALUES (70, 'Ataco', 73);
INSERT INTO `municipio` VALUES (71, 'Atrato (Yuto)', 27);
INSERT INTO `municipio` VALUES (72, 'Ayapel', 23);
INSERT INTO `municipio` VALUES (73, 'Bagadó', 27);
INSERT INTO `municipio` VALUES (74, 'Bahía Solano (Mútis)', 27);
INSERT INTO `municipio` VALUES (75, 'Bajo Baudó (Pizarro)', 27);
INSERT INTO `municipio` VALUES (76, 'Balboa', 19);
INSERT INTO `municipio` VALUES (77, 'Balboa', 66);
INSERT INTO `municipio` VALUES (78, 'Baranoa', 8);
INSERT INTO `municipio` VALUES (79, 'Baraya', 41);
INSERT INTO `municipio` VALUES (80, 'Barbacoas', 52);
INSERT INTO `municipio` VALUES (81, 'Barbosa', 5);
INSERT INTO `municipio` VALUES (82, 'Barbosa', 68);
INSERT INTO `municipio` VALUES (83, 'Barichara', 68);
INSERT INTO `municipio` VALUES (84, 'Barranca de Upía', 50);
INSERT INTO `municipio` VALUES (85, 'Barrancabermeja', 68);
INSERT INTO `municipio` VALUES (86, 'Barrancas', 44);
INSERT INTO `municipio` VALUES (87, 'Barranco de Loba', 13);
INSERT INTO `municipio` VALUES (88, 'Barranquilla', 8);
INSERT INTO `municipio` VALUES (89, 'Becerríl', 20);
INSERT INTO `municipio` VALUES (90, 'Belalcázar', 17);
INSERT INTO `municipio` VALUES (91, 'Bello', 5);
INSERT INTO `municipio` VALUES (92, 'Belmira', 5);
INSERT INTO `municipio` VALUES (93, 'Beltrán', 25);
INSERT INTO `municipio` VALUES (94, 'Belén', 15);
INSERT INTO `municipio` VALUES (95, 'Belén', 52);
INSERT INTO `municipio` VALUES (96, 'Belén de Bajirá', 27);
INSERT INTO `municipio` VALUES (97, 'Belén de Umbría', 66);
INSERT INTO `municipio` VALUES (98, 'Belén de los Andaquíes', 18);
INSERT INTO `municipio` VALUES (99, 'Berbeo', 15);
INSERT INTO `municipio` VALUES (100, 'Betania', 5);
INSERT INTO `municipio` VALUES (101, 'Beteitiva', 15);
INSERT INTO `municipio` VALUES (102, 'Betulia', 5);
INSERT INTO `municipio` VALUES (103, 'Betulia', 68);
INSERT INTO `municipio` VALUES (104, 'Bituima', 25);
INSERT INTO `municipio` VALUES (105, 'Boavita', 15);
INSERT INTO `municipio` VALUES (106, 'Bochalema', 54);
INSERT INTO `municipio` VALUES (107, 'Bogotá D.C.', 11);
INSERT INTO `municipio` VALUES (108, 'Bojacá', 25);
INSERT INTO `municipio` VALUES (109, 'Bojayá (Bellavista)', 27);
INSERT INTO `municipio` VALUES (110, 'Bolívar', 5);
INSERT INTO `municipio` VALUES (111, 'Bolívar', 19);
INSERT INTO `municipio` VALUES (112, 'Bolívar', 68);
INSERT INTO `municipio` VALUES (113, 'Bolívar', 76);
INSERT INTO `municipio` VALUES (114, 'Bosconia', 20);
INSERT INTO `municipio` VALUES (115, 'Boyacá', 15);
INSERT INTO `municipio` VALUES (116, 'Briceño', 5);
INSERT INTO `municipio` VALUES (117, 'Briceño', 15);
INSERT INTO `municipio` VALUES (118, 'Bucaramanga', 68);
INSERT INTO `municipio` VALUES (119, 'Bucarasica', 54);
INSERT INTO `municipio` VALUES (120, 'Buenaventura', 76);
INSERT INTO `municipio` VALUES (121, 'Buenavista', 15);
INSERT INTO `municipio` VALUES (122, 'Buenavista', 23);
INSERT INTO `municipio` VALUES (123, 'Buenavista', 63);
INSERT INTO `municipio` VALUES (124, 'Buenavista', 70);
INSERT INTO `municipio` VALUES (125, 'Buenos Aires', 19);
INSERT INTO `municipio` VALUES (126, 'Buesaco', 52);
INSERT INTO `municipio` VALUES (127, 'Buga', 76);
INSERT INTO `municipio` VALUES (128, 'Bugalagrande', 76);
INSERT INTO `municipio` VALUES (129, 'Burítica', 5);
INSERT INTO `municipio` VALUES (130, 'Busbanza', 15);
INSERT INTO `municipio` VALUES (131, 'Cabrera', 25);
INSERT INTO `municipio` VALUES (132, 'Cabrera', 68);
INSERT INTO `municipio` VALUES (133, 'Cabuyaro', 50);
INSERT INTO `municipio` VALUES (134, 'Cachipay', 25);
INSERT INTO `municipio` VALUES (135, 'Caicedo', 5);
INSERT INTO `municipio` VALUES (136, 'Caicedonia', 76);
INSERT INTO `municipio` VALUES (137, 'Caimito', 70);
INSERT INTO `municipio` VALUES (138, 'Cajamarca', 73);
INSERT INTO `municipio` VALUES (139, 'Cajibío', 19);
INSERT INTO `municipio` VALUES (140, 'Cajicá', 25);
INSERT INTO `municipio` VALUES (141, 'Calamar', 13);
INSERT INTO `municipio` VALUES (142, 'Calamar', 95);
INSERT INTO `municipio` VALUES (143, 'Calarcá', 63);
INSERT INTO `municipio` VALUES (144, 'Caldas', 5);
INSERT INTO `municipio` VALUES (145, 'Caldas', 15);
INSERT INTO `municipio` VALUES (146, 'Caldono', 19);
INSERT INTO `municipio` VALUES (147, 'California', 68);
INSERT INTO `municipio` VALUES (148, 'Calima (Darién)', 76);
INSERT INTO `municipio` VALUES (149, 'Caloto', 19);
INSERT INTO `municipio` VALUES (150, 'Calí', 76);
INSERT INTO `municipio` VALUES (151, 'Campamento', 5);
INSERT INTO `municipio` VALUES (152, 'Campo de la Cruz', 8);
INSERT INTO `municipio` VALUES (153, 'Campoalegre', 41);
INSERT INTO `municipio` VALUES (154, 'Campohermoso', 15);
INSERT INTO `municipio` VALUES (155, 'Canalete', 23);
INSERT INTO `municipio` VALUES (156, 'Candelaria', 8);
INSERT INTO `municipio` VALUES (157, 'Candelaria', 76);
INSERT INTO `municipio` VALUES (158, 'Cantagallo', 13);
INSERT INTO `municipio` VALUES (159, 'Cantón de San Pablo', 27);
INSERT INTO `municipio` VALUES (160, 'Caparrapí', 25);
INSERT INTO `municipio` VALUES (161, 'Capitanejo', 68);
INSERT INTO `municipio` VALUES (162, 'Caracolí', 5);
INSERT INTO `municipio` VALUES (163, 'Caramanta', 5);
INSERT INTO `municipio` VALUES (164, 'Carcasí', 68);
INSERT INTO `municipio` VALUES (165, 'Carepa', 5);
INSERT INTO `municipio` VALUES (166, 'Carmen de Apicalá', 73);
INSERT INTO `municipio` VALUES (167, 'Carmen de Carupa', 25);
INSERT INTO `municipio` VALUES (168, 'Carmen de Viboral', 5);
INSERT INTO `municipio` VALUES (169, 'Carmen del Darién (CURBARADÓ)', 27);
INSERT INTO `municipio` VALUES (170, 'Carolina', 5);
INSERT INTO `municipio` VALUES (171, 'Cartagena', 13);
INSERT INTO `municipio` VALUES (172, 'Cartagena del Chairá', 18);
INSERT INTO `municipio` VALUES (173, 'Cartago', 76);
INSERT INTO `municipio` VALUES (174, 'Carurú', 97);
INSERT INTO `municipio` VALUES (175, 'Casabianca', 73);
INSERT INTO `municipio` VALUES (176, 'Castilla la Nueva', 50);
INSERT INTO `municipio` VALUES (177, 'Caucasia', 5);
INSERT INTO `municipio` VALUES (178, 'Cañasgordas', 5);
INSERT INTO `municipio` VALUES (179, 'Cepita', 68);
INSERT INTO `municipio` VALUES (180, 'Cereté', 23);
INSERT INTO `municipio` VALUES (181, 'Cerinza', 15);
INSERT INTO `municipio` VALUES (182, 'Cerrito', 68);
INSERT INTO `municipio` VALUES (183, 'Cerro San Antonio', 47);
INSERT INTO `municipio` VALUES (184, 'Chachaguí', 52);
INSERT INTO `municipio` VALUES (185, 'Chaguaní', 25);
INSERT INTO `municipio` VALUES (186, 'Chalán', 70);
INSERT INTO `municipio` VALUES (187, 'Chaparral', 73);
INSERT INTO `municipio` VALUES (188, 'Charalá', 68);
INSERT INTO `municipio` VALUES (189, 'Charta', 68);
INSERT INTO `municipio` VALUES (190, 'Chigorodó', 5);
INSERT INTO `municipio` VALUES (191, 'Chima', 68);
INSERT INTO `municipio` VALUES (192, 'Chimichagua', 20);
INSERT INTO `municipio` VALUES (193, 'Chimá', 23);
INSERT INTO `municipio` VALUES (194, 'Chinavita', 15);
INSERT INTO `municipio` VALUES (195, 'Chinchiná', 17);
INSERT INTO `municipio` VALUES (196, 'Chinácota', 54);
INSERT INTO `municipio` VALUES (197, 'Chinú', 23);
INSERT INTO `municipio` VALUES (198, 'Chipaque', 25);
INSERT INTO `municipio` VALUES (199, 'Chipatá', 68);
INSERT INTO `municipio` VALUES (200, 'Chiquinquirá', 15);
INSERT INTO `municipio` VALUES (201, 'Chiriguaná', 20);
INSERT INTO `municipio` VALUES (202, 'Chiscas', 15);
INSERT INTO `municipio` VALUES (203, 'Chita', 15);
INSERT INTO `municipio` VALUES (204, 'Chitagá', 54);
INSERT INTO `municipio` VALUES (205, 'Chitaraque', 15);
INSERT INTO `municipio` VALUES (206, 'Chivatá', 15);
INSERT INTO `municipio` VALUES (207, 'Chivolo', 47);
INSERT INTO `municipio` VALUES (208, 'Choachí', 25);
INSERT INTO `municipio` VALUES (209, 'Chocontá', 25);
INSERT INTO `municipio` VALUES (210, 'Chámeza', 85);
INSERT INTO `municipio` VALUES (211, 'Chía', 25);
INSERT INTO `municipio` VALUES (212, 'Chíquiza', 15);
INSERT INTO `municipio` VALUES (213, 'Chívor', 15);
INSERT INTO `municipio` VALUES (214, 'Cicuco', 13);
INSERT INTO `municipio` VALUES (215, 'Cimitarra', 68);
INSERT INTO `municipio` VALUES (216, 'Circasia', 63);
INSERT INTO `municipio` VALUES (217, 'Cisneros', 5);
INSERT INTO `municipio` VALUES (218, 'Ciénaga', 15);
INSERT INTO `municipio` VALUES (219, 'Ciénaga', 47);
INSERT INTO `municipio` VALUES (220, 'Ciénaga de Oro', 23);
INSERT INTO `municipio` VALUES (221, 'Clemencia', 13);
INSERT INTO `municipio` VALUES (222, 'Cocorná', 5);
INSERT INTO `municipio` VALUES (223, 'Coello', 73);
INSERT INTO `municipio` VALUES (224, 'Cogua', 25);
INSERT INTO `municipio` VALUES (225, 'Colombia', 41);
INSERT INTO `municipio` VALUES (226, 'Colosó (Ricaurte)', 70);
INSERT INTO `municipio` VALUES (227, 'Colón', 86);
INSERT INTO `municipio` VALUES (228, 'Colón (Génova)', 52);
INSERT INTO `municipio` VALUES (229, 'Concepción', 5);
INSERT INTO `municipio` VALUES (230, 'Concepción', 68);
INSERT INTO `municipio` VALUES (231, 'Concordia', 5);
INSERT INTO `municipio` VALUES (232, 'Concordia', 47);
INSERT INTO `municipio` VALUES (233, 'Condoto', 27);
INSERT INTO `municipio` VALUES (234, 'Confines', 68);
INSERT INTO `municipio` VALUES (235, 'Consaca', 52);
INSERT INTO `municipio` VALUES (236, 'Contadero', 52);
INSERT INTO `municipio` VALUES (237, 'Contratación', 68);
INSERT INTO `municipio` VALUES (238, 'Convención', 54);
INSERT INTO `municipio` VALUES (239, 'Copacabana', 5);
INSERT INTO `municipio` VALUES (240, 'Coper', 15);
INSERT INTO `municipio` VALUES (241, 'Cordobá', 63);
INSERT INTO `municipio` VALUES (242, 'Corinto', 19);
INSERT INTO `municipio` VALUES (243, 'Coromoro', 68);
INSERT INTO `municipio` VALUES (244, 'Corozal', 70);
INSERT INTO `municipio` VALUES (245, 'Corrales', 15);
INSERT INTO `municipio` VALUES (246, 'Cota', 25);
INSERT INTO `municipio` VALUES (247, 'Cotorra', 23);
INSERT INTO `municipio` VALUES (248, 'Covarachía', 15);
INSERT INTO `municipio` VALUES (249, 'Coveñas', 70);
INSERT INTO `municipio` VALUES (250, 'Coyaima', 73);
INSERT INTO `municipio` VALUES (251, 'Cravo Norte', 81);
INSERT INTO `municipio` VALUES (252, 'Cuaspud (Carlosama)', 52);
INSERT INTO `municipio` VALUES (253, 'Cubarral', 50);
INSERT INTO `municipio` VALUES (254, 'Cubará', 15);
INSERT INTO `municipio` VALUES (255, 'Cucaita', 15);
INSERT INTO `municipio` VALUES (256, 'Cucunubá', 25);
INSERT INTO `municipio` VALUES (257, 'Cucutilla', 54);
INSERT INTO `municipio` VALUES (258, 'Cuitiva', 15);
INSERT INTO `municipio` VALUES (259, 'Cumaral', 50);
INSERT INTO `municipio` VALUES (260, 'Cumaribo', 99);
INSERT INTO `municipio` VALUES (261, 'Cumbal', 52);
INSERT INTO `municipio` VALUES (262, 'Cumbitara', 52);
INSERT INTO `municipio` VALUES (263, 'Cunday', 73);
INSERT INTO `municipio` VALUES (264, 'Curillo', 18);
INSERT INTO `municipio` VALUES (265, 'Curití', 68);
INSERT INTO `municipio` VALUES (266, 'Curumaní', 20);
INSERT INTO `municipio` VALUES (267, 'Cáceres', 5);
INSERT INTO `municipio` VALUES (268, 'Cáchira', 54);
INSERT INTO `municipio` VALUES (269, 'Cácota', 54);
INSERT INTO `municipio` VALUES (270, 'Cáqueza', 25);
INSERT INTO `municipio` VALUES (271, 'Cértegui', 27);
INSERT INTO `municipio` VALUES (272, 'Cómbita', 15);
INSERT INTO `municipio` VALUES (273, 'Córdoba', 13);
INSERT INTO `municipio` VALUES (274, 'Córdoba', 52);
INSERT INTO `municipio` VALUES (275, 'Cúcuta', 54);
INSERT INTO `municipio` VALUES (276, 'Dabeiba', 5);
INSERT INTO `municipio` VALUES (277, 'Dagua', 76);
INSERT INTO `municipio` VALUES (278, 'Dibulla', 44);
INSERT INTO `municipio` VALUES (279, 'Distracción', 44);
INSERT INTO `municipio` VALUES (280, 'Dolores', 73);
INSERT INTO `municipio` VALUES (281, 'Don Matías', 5);
INSERT INTO `municipio` VALUES (282, 'Dos Quebradas', 66);
INSERT INTO `municipio` VALUES (283, 'Duitama', 15);
INSERT INTO `municipio` VALUES (284, 'Durania', 54);
INSERT INTO `municipio` VALUES (285, 'Ebéjico', 5);
INSERT INTO `municipio` VALUES (286, 'El Bagre', 5);
INSERT INTO `municipio` VALUES (287, 'El Banco', 47);
INSERT INTO `municipio` VALUES (288, 'El Cairo', 76);
INSERT INTO `municipio` VALUES (289, 'El Calvario', 50);
INSERT INTO `municipio` VALUES (290, 'El Carmen', 54);
INSERT INTO `municipio` VALUES (291, 'El Carmen', 68);
INSERT INTO `municipio` VALUES (292, 'El Carmen de Atrato', 27);
INSERT INTO `municipio` VALUES (293, 'El Carmen de Bolívar', 13);
INSERT INTO `municipio` VALUES (294, 'El Castillo', 50);
INSERT INTO `municipio` VALUES (295, 'El Cerrito', 76);
INSERT INTO `municipio` VALUES (296, 'El Charco', 52);
INSERT INTO `municipio` VALUES (297, 'El Cocuy', 15);
INSERT INTO `municipio` VALUES (298, 'El Colegio', 25);
INSERT INTO `municipio` VALUES (299, 'El Copey', 20);
INSERT INTO `municipio` VALUES (300, 'El Doncello', 18);
INSERT INTO `municipio` VALUES (301, 'El Dorado', 50);
INSERT INTO `municipio` VALUES (302, 'El Dovio', 76);
INSERT INTO `municipio` VALUES (303, 'El Espino', 15);
INSERT INTO `municipio` VALUES (304, 'El Guacamayo', 68);
INSERT INTO `municipio` VALUES (305, 'El Guamo', 13);
INSERT INTO `municipio` VALUES (306, 'El Molino', 44);
INSERT INTO `municipio` VALUES (307, 'El Paso', 20);
INSERT INTO `municipio` VALUES (308, 'El Paujil', 18);
INSERT INTO `municipio` VALUES (309, 'El Peñol', 52);
INSERT INTO `municipio` VALUES (310, 'El Peñon', 13);
INSERT INTO `municipio` VALUES (311, 'El Peñon', 68);
INSERT INTO `municipio` VALUES (312, 'El Peñón', 25);
INSERT INTO `municipio` VALUES (313, 'El Piñon', 47);
INSERT INTO `municipio` VALUES (314, 'El Playón', 68);
INSERT INTO `municipio` VALUES (315, 'El Retorno', 95);
INSERT INTO `municipio` VALUES (316, 'El Retén', 47);
INSERT INTO `municipio` VALUES (317, 'El Roble', 70);
INSERT INTO `municipio` VALUES (318, 'El Rosal', 25);
INSERT INTO `municipio` VALUES (319, 'El Rosario', 52);
INSERT INTO `municipio` VALUES (320, 'El Tablón de Gómez', 52);
INSERT INTO `municipio` VALUES (321, 'El Tambo', 19);
INSERT INTO `municipio` VALUES (322, 'El Tambo', 52);
INSERT INTO `municipio` VALUES (323, 'El Tarra', 54);
INSERT INTO `municipio` VALUES (324, 'El Zulia', 54);
INSERT INTO `municipio` VALUES (325, 'El Águila', 76);
INSERT INTO `municipio` VALUES (326, 'Elías', 41);
INSERT INTO `municipio` VALUES (327, 'Encino', 68);
INSERT INTO `municipio` VALUES (328, 'Enciso', 68);
INSERT INTO `municipio` VALUES (329, 'Entrerríos', 5);
INSERT INTO `municipio` VALUES (330, 'Envigado', 5);
INSERT INTO `municipio` VALUES (331, 'Espinal', 73);
INSERT INTO `municipio` VALUES (332, 'Facatativá', 25);
INSERT INTO `municipio` VALUES (333, 'Falan', 73);
INSERT INTO `municipio` VALUES (334, 'Filadelfia', 17);
INSERT INTO `municipio` VALUES (335, 'Filandia', 63);
INSERT INTO `municipio` VALUES (336, 'Firavitoba', 15);
INSERT INTO `municipio` VALUES (337, 'Flandes', 73);
INSERT INTO `municipio` VALUES (338, 'Florencia', 18);
INSERT INTO `municipio` VALUES (339, 'Florencia', 19);
INSERT INTO `municipio` VALUES (340, 'Floresta', 15);
INSERT INTO `municipio` VALUES (341, 'Florida', 76);
INSERT INTO `municipio` VALUES (342, 'Floridablanca', 68);
INSERT INTO `municipio` VALUES (343, 'Florián', 68);
INSERT INTO `municipio` VALUES (344, 'Fonseca', 44);
INSERT INTO `municipio` VALUES (345, 'Fortúl', 81);
INSERT INTO `municipio` VALUES (346, 'Fosca', 25);
INSERT INTO `municipio` VALUES (347, 'Francisco Pizarro', 52);
INSERT INTO `municipio` VALUES (348, 'Fredonia', 5);
INSERT INTO `municipio` VALUES (349, 'Fresno', 73);
INSERT INTO `municipio` VALUES (350, 'Frontino', 5);
INSERT INTO `municipio` VALUES (351, 'Fuente de Oro', 50);
INSERT INTO `municipio` VALUES (352, 'Fundación', 47);
INSERT INTO `municipio` VALUES (353, 'Funes', 52);
INSERT INTO `municipio` VALUES (354, 'Funza', 25);
INSERT INTO `municipio` VALUES (355, 'Fusagasugá', 25);
INSERT INTO `municipio` VALUES (356, 'Fómeque', 25);
INSERT INTO `municipio` VALUES (357, 'Fúquene', 25);
INSERT INTO `municipio` VALUES (358, 'Gachalá', 25);
INSERT INTO `municipio` VALUES (359, 'Gachancipá', 25);
INSERT INTO `municipio` VALUES (360, 'Gachantivá', 15);
INSERT INTO `municipio` VALUES (361, 'Gachetá', 25);
INSERT INTO `municipio` VALUES (362, 'Galapa', 8);
INSERT INTO `municipio` VALUES (363, 'Galeras (Nueva Granada)', 70);
INSERT INTO `municipio` VALUES (364, 'Galán', 68);
INSERT INTO `municipio` VALUES (365, 'Gama', 25);
INSERT INTO `municipio` VALUES (366, 'Gamarra', 20);
INSERT INTO `municipio` VALUES (367, 'Garagoa', 15);
INSERT INTO `municipio` VALUES (368, 'Garzón', 41);
INSERT INTO `municipio` VALUES (369, 'Gigante', 41);
INSERT INTO `municipio` VALUES (370, 'Ginebra', 76);
INSERT INTO `municipio` VALUES (371, 'Giraldo', 5);
INSERT INTO `municipio` VALUES (372, 'Girardot', 25);
INSERT INTO `municipio` VALUES (373, 'Girardota', 5);
INSERT INTO `municipio` VALUES (374, 'Girón', 68);
INSERT INTO `municipio` VALUES (375, 'Gonzalez', 20);
INSERT INTO `municipio` VALUES (376, 'Gramalote', 54);
INSERT INTO `municipio` VALUES (377, 'Granada', 5);
INSERT INTO `municipio` VALUES (378, 'Granada', 25);
INSERT INTO `municipio` VALUES (379, 'Granada', 50);
INSERT INTO `municipio` VALUES (380, 'Guaca', 68);
INSERT INTO `municipio` VALUES (381, 'Guacamayas', 15);
INSERT INTO `municipio` VALUES (382, 'Guacarí', 76);
INSERT INTO `municipio` VALUES (383, 'Guachavés', 52);
INSERT INTO `municipio` VALUES (384, 'Guachené', 19);
INSERT INTO `municipio` VALUES (385, 'Guachetá', 25);
INSERT INTO `municipio` VALUES (386, 'Guachucal', 52);
INSERT INTO `municipio` VALUES (387, 'Guadalupe', 5);
INSERT INTO `municipio` VALUES (388, 'Guadalupe', 41);
INSERT INTO `municipio` VALUES (389, 'Guadalupe', 68);
INSERT INTO `municipio` VALUES (390, 'Guaduas', 25);
INSERT INTO `municipio` VALUES (391, 'Guaitarilla', 52);
INSERT INTO `municipio` VALUES (392, 'Gualmatán', 52);
INSERT INTO `municipio` VALUES (393, 'Guamal', 47);
INSERT INTO `municipio` VALUES (394, 'Guamal', 50);
INSERT INTO `municipio` VALUES (395, 'Guamo', 73);
INSERT INTO `municipio` VALUES (396, 'Guapota', 68);
INSERT INTO `municipio` VALUES (397, 'Guapí', 19);
INSERT INTO `municipio` VALUES (398, 'Guaranda', 70);
INSERT INTO `municipio` VALUES (399, 'Guarne', 5);
INSERT INTO `municipio` VALUES (400, 'Guasca', 25);
INSERT INTO `municipio` VALUES (401, 'Guatapé', 5);
INSERT INTO `municipio` VALUES (402, 'Guataquí', 25);
INSERT INTO `municipio` VALUES (403, 'Guatavita', 25);
INSERT INTO `municipio` VALUES (404, 'Guateque', 15);
INSERT INTO `municipio` VALUES (405, 'Guavatá', 68);
INSERT INTO `municipio` VALUES (406, 'Guayabal de Siquima', 25);
INSERT INTO `municipio` VALUES (407, 'Guayabetal', 25);
INSERT INTO `municipio` VALUES (408, 'Guayatá', 15);
INSERT INTO `municipio` VALUES (409, 'Guepsa', 68);
INSERT INTO `municipio` VALUES (410, 'Guicán', 15);
INSERT INTO `municipio` VALUES (411, 'Gutiérrez', 25);
INSERT INTO `municipio` VALUES (412, 'Guática', 66);
INSERT INTO `municipio` VALUES (413, 'Gámbita', 68);
INSERT INTO `municipio` VALUES (414, 'Gámeza', 15);
INSERT INTO `municipio` VALUES (415, 'Génova', 63);
INSERT INTO `municipio` VALUES (416, 'Gómez Plata', 5);
INSERT INTO `municipio` VALUES (417, 'Hacarí', 54);
INSERT INTO `municipio` VALUES (418, 'Hatillo de Loba', 13);
INSERT INTO `municipio` VALUES (419, 'Hato', 68);
INSERT INTO `municipio` VALUES (420, 'Hato Corozal', 85);
INSERT INTO `municipio` VALUES (421, 'Hatonuevo', 44);
INSERT INTO `municipio` VALUES (422, 'Heliconia', 5);
INSERT INTO `municipio` VALUES (423, 'Herrán', 54);
INSERT INTO `municipio` VALUES (424, 'Herveo', 73);
INSERT INTO `municipio` VALUES (425, 'Hispania', 5);
INSERT INTO `municipio` VALUES (426, 'Hobo', 41);
INSERT INTO `municipio` VALUES (427, 'Honda', 73);
INSERT INTO `municipio` VALUES (428, 'Ibagué', 73);
INSERT INTO `municipio` VALUES (429, 'Icononzo', 73);
INSERT INTO `municipio` VALUES (430, 'Iles', 52);
INSERT INTO `municipio` VALUES (431, 'Imúes', 52);
INSERT INTO `municipio` VALUES (432, 'Inzá', 19);
INSERT INTO `municipio` VALUES (433, 'Inírida', 94);
INSERT INTO `municipio` VALUES (434, 'Ipiales', 52);
INSERT INTO `municipio` VALUES (435, 'Isnos', 41);
INSERT INTO `municipio` VALUES (436, 'Istmina', 27);
INSERT INTO `municipio` VALUES (437, 'Itagüí', 5);
INSERT INTO `municipio` VALUES (438, 'Ituango', 5);
INSERT INTO `municipio` VALUES (439, 'Izá', 15);
INSERT INTO `municipio` VALUES (440, 'Jambaló', 19);
INSERT INTO `municipio` VALUES (441, 'Jamundí', 76);
INSERT INTO `municipio` VALUES (442, 'Jardín', 5);
INSERT INTO `municipio` VALUES (443, 'Jenesano', 15);
INSERT INTO `municipio` VALUES (444, 'Jericó', 5);
INSERT INTO `municipio` VALUES (445, 'Jericó', 15);
INSERT INTO `municipio` VALUES (446, 'Jerusalén', 25);
INSERT INTO `municipio` VALUES (447, 'Jesús María', 68);
INSERT INTO `municipio` VALUES (448, 'Jordán', 68);
INSERT INTO `municipio` VALUES (449, 'Juan de Acosta', 8);
INSERT INTO `municipio` VALUES (450, 'Junín', 25);
INSERT INTO `municipio` VALUES (451, 'Juradó', 27);
INSERT INTO `municipio` VALUES (452, 'La Apartada y La Frontera', 23);
INSERT INTO `municipio` VALUES (453, 'La Argentina', 41);
INSERT INTO `municipio` VALUES (454, 'La Belleza', 68);
INSERT INTO `municipio` VALUES (455, 'La Calera', 25);
INSERT INTO `municipio` VALUES (456, 'La Capilla', 15);
INSERT INTO `municipio` VALUES (457, 'La Ceja', 5);
INSERT INTO `municipio` VALUES (458, 'La Celia', 66);
INSERT INTO `municipio` VALUES (459, 'La Cruz', 52);
INSERT INTO `municipio` VALUES (460, 'La Cumbre', 76);
INSERT INTO `municipio` VALUES (461, 'La Dorada', 17);
INSERT INTO `municipio` VALUES (462, 'La Esperanza', 54);
INSERT INTO `municipio` VALUES (463, 'La Estrella', 5);
INSERT INTO `municipio` VALUES (464, 'La Florida', 52);
INSERT INTO `municipio` VALUES (465, 'La Gloria', 20);
INSERT INTO `municipio` VALUES (466, 'La Jagua de Ibirico', 20);
INSERT INTO `municipio` VALUES (467, 'La Jagua del Pilar', 44);
INSERT INTO `municipio` VALUES (468, 'La Llanada', 52);
INSERT INTO `municipio` VALUES (469, 'La Macarena', 50);
INSERT INTO `municipio` VALUES (470, 'La Merced', 17);
INSERT INTO `municipio` VALUES (471, 'La Mesa', 25);
INSERT INTO `municipio` VALUES (472, 'La Montañita', 18);
INSERT INTO `municipio` VALUES (473, 'La Palma', 25);
INSERT INTO `municipio` VALUES (474, 'La Paz', 68);
INSERT INTO `municipio` VALUES (475, 'La Paz (Robles)', 20);
INSERT INTO `municipio` VALUES (476, 'La Peña', 25);
INSERT INTO `municipio` VALUES (477, 'La Pintada', 5);
INSERT INTO `municipio` VALUES (478, 'La Plata', 41);
INSERT INTO `municipio` VALUES (479, 'La Playa', 54);
INSERT INTO `municipio` VALUES (480, 'La Primavera', 99);
INSERT INTO `municipio` VALUES (481, 'La Salina', 85);
INSERT INTO `municipio` VALUES (482, 'La Sierra', 19);
INSERT INTO `municipio` VALUES (483, 'La Tebaida', 63);
INSERT INTO `municipio` VALUES (484, 'La Tola', 52);
INSERT INTO `municipio` VALUES (485, 'La Unión', 5);
INSERT INTO `municipio` VALUES (486, 'La Unión', 52);
INSERT INTO `municipio` VALUES (487, 'La Unión', 70);
INSERT INTO `municipio` VALUES (488, 'La Unión', 76);
INSERT INTO `municipio` VALUES (489, 'La Uvita', 15);
INSERT INTO `municipio` VALUES (490, 'La Vega', 19);
INSERT INTO `municipio` VALUES (491, 'La Vega', 25);
INSERT INTO `municipio` VALUES (492, 'La Victoria', 15);
INSERT INTO `municipio` VALUES (493, 'La Victoria', 17);
INSERT INTO `municipio` VALUES (494, 'La Victoria', 76);
INSERT INTO `municipio` VALUES (495, 'La Virginia', 66);
INSERT INTO `municipio` VALUES (496, 'Labateca', 54);
INSERT INTO `municipio` VALUES (497, 'Labranzagrande', 15);
INSERT INTO `municipio` VALUES (498, 'Landázuri', 68);
INSERT INTO `municipio` VALUES (499, 'Lebrija', 68);
INSERT INTO `municipio` VALUES (500, 'Leiva', 52);
INSERT INTO `municipio` VALUES (501, 'Lejanías', 50);
INSERT INTO `municipio` VALUES (502, 'Lenguazaque', 25);
INSERT INTO `municipio` VALUES (503, 'Leticia', 91);
INSERT INTO `municipio` VALUES (504, 'Liborina', 5);
INSERT INTO `municipio` VALUES (505, 'Linares', 52);
INSERT INTO `municipio` VALUES (506, 'Lloró', 27);
INSERT INTO `municipio` VALUES (507, 'Lorica', 23);
INSERT INTO `municipio` VALUES (508, 'Los Córdobas', 23);
INSERT INTO `municipio` VALUES (509, 'Los Palmitos', 70);
INSERT INTO `municipio` VALUES (510, 'Los Patios', 54);
INSERT INTO `municipio` VALUES (511, 'Los Santos', 68);
INSERT INTO `municipio` VALUES (512, 'Lourdes', 54);
INSERT INTO `municipio` VALUES (513, 'Luruaco', 8);
INSERT INTO `municipio` VALUES (514, 'Lérida', 73);
INSERT INTO `municipio` VALUES (515, 'Líbano', 73);
INSERT INTO `municipio` VALUES (516, 'López (Micay)', 19);
INSERT INTO `municipio` VALUES (517, 'Macanal', 15);
INSERT INTO `municipio` VALUES (518, 'Macaravita', 68);
INSERT INTO `municipio` VALUES (519, 'Maceo', 5);
INSERT INTO `municipio` VALUES (520, 'Machetá', 25);
INSERT INTO `municipio` VALUES (521, 'Madrid', 25);
INSERT INTO `municipio` VALUES (522, 'Magangué', 13);
INSERT INTO `municipio` VALUES (523, 'Magüi (Payán)', 52);
INSERT INTO `municipio` VALUES (524, 'Mahates', 13);
INSERT INTO `municipio` VALUES (525, 'Maicao', 44);
INSERT INTO `municipio` VALUES (526, 'Majagual', 70);
INSERT INTO `municipio` VALUES (527, 'Malambo', 8);
INSERT INTO `municipio` VALUES (528, 'Mallama (Piedrancha)', 52);
INSERT INTO `municipio` VALUES (529, 'Manatí', 8);
INSERT INTO `municipio` VALUES (530, 'Manaure', 44);
INSERT INTO `municipio` VALUES (531, 'Manaure Balcón del Cesar', 20);
INSERT INTO `municipio` VALUES (532, 'Manizales', 17);
INSERT INTO `municipio` VALUES (533, 'Manta', 25);
INSERT INTO `municipio` VALUES (534, 'Manzanares', 17);
INSERT INTO `municipio` VALUES (535, 'Maní', 85);
INSERT INTO `municipio` VALUES (536, 'Mapiripan', 50);
INSERT INTO `municipio` VALUES (537, 'Margarita', 13);
INSERT INTO `municipio` VALUES (538, 'Marinilla', 5);
INSERT INTO `municipio` VALUES (539, 'Maripí', 15);
INSERT INTO `municipio` VALUES (540, 'Mariquita', 73);
INSERT INTO `municipio` VALUES (541, 'Marmato', 17);
INSERT INTO `municipio` VALUES (542, 'Marquetalia', 17);
INSERT INTO `municipio` VALUES (543, 'Marsella', 66);
INSERT INTO `municipio` VALUES (544, 'Marulanda', 17);
INSERT INTO `municipio` VALUES (545, 'María la Baja', 13);
INSERT INTO `municipio` VALUES (546, 'Matanza', 68);
INSERT INTO `municipio` VALUES (547, 'Medellín', 5);
INSERT INTO `municipio` VALUES (548, 'Medina', 25);
INSERT INTO `municipio` VALUES (549, 'Medio Atrato', 27);
INSERT INTO `municipio` VALUES (550, 'Medio Baudó', 27);
INSERT INTO `municipio` VALUES (551, 'Medio San Juan (ANDAGOYA)', 27);
INSERT INTO `municipio` VALUES (552, 'Melgar', 73);
INSERT INTO `municipio` VALUES (553, 'Mercaderes', 19);
INSERT INTO `municipio` VALUES (554, 'Mesetas', 50);
INSERT INTO `municipio` VALUES (555, 'Milán', 18);
INSERT INTO `municipio` VALUES (556, 'Miraflores', 15);
INSERT INTO `municipio` VALUES (557, 'Miraflores', 95);
INSERT INTO `municipio` VALUES (558, 'Miranda', 19);
INSERT INTO `municipio` VALUES (559, 'Mistrató', 66);
INSERT INTO `municipio` VALUES (560, 'Mitú', 97);
INSERT INTO `municipio` VALUES (561, 'Mocoa', 86);
INSERT INTO `municipio` VALUES (562, 'Mogotes', 68);
INSERT INTO `municipio` VALUES (563, 'Molagavita', 68);
INSERT INTO `municipio` VALUES (564, 'Momil', 23);
INSERT INTO `municipio` VALUES (565, 'Mompós', 13);
INSERT INTO `municipio` VALUES (566, 'Mongua', 15);
INSERT INTO `municipio` VALUES (567, 'Monguí', 15);
INSERT INTO `municipio` VALUES (568, 'Moniquirá', 15);
INSERT INTO `municipio` VALUES (569, 'Montebello', 5);
INSERT INTO `municipio` VALUES (570, 'Montecristo', 13);
INSERT INTO `municipio` VALUES (571, 'Montelíbano', 23);
INSERT INTO `municipio` VALUES (572, 'Montenegro', 63);
INSERT INTO `municipio` VALUES (573, 'Monteria', 23);
INSERT INTO `municipio` VALUES (574, 'Monterrey', 85);
INSERT INTO `municipio` VALUES (575, 'Morales', 13);
INSERT INTO `municipio` VALUES (576, 'Morales', 19);
INSERT INTO `municipio` VALUES (577, 'Morelia', 18);
INSERT INTO `municipio` VALUES (578, 'Morroa', 70);
INSERT INTO `municipio` VALUES (579, 'Mosquera', 25);
INSERT INTO `municipio` VALUES (580, 'Mosquera', 52);
INSERT INTO `municipio` VALUES (581, 'Motavita', 15);
INSERT INTO `municipio` VALUES (582, 'Moñitos', 23);
INSERT INTO `municipio` VALUES (583, 'Murillo', 73);
INSERT INTO `municipio` VALUES (584, 'Murindó', 5);
INSERT INTO `municipio` VALUES (585, 'Mutatá', 5);
INSERT INTO `municipio` VALUES (586, 'Mutiscua', 54);
INSERT INTO `municipio` VALUES (587, 'Muzo', 15);
INSERT INTO `municipio` VALUES (588, 'Málaga', 68);
INSERT INTO `municipio` VALUES (589, 'Nariño', 5);
INSERT INTO `municipio` VALUES (590, 'Nariño', 25);
INSERT INTO `municipio` VALUES (591, 'Nariño', 52);
INSERT INTO `municipio` VALUES (592, 'Natagaima', 73);
INSERT INTO `municipio` VALUES (593, 'Nechí', 5);
INSERT INTO `municipio` VALUES (594, 'Necoclí', 5);
INSERT INTO `municipio` VALUES (595, 'Neira', 17);
INSERT INTO `municipio` VALUES (596, 'Neiva', 41);
INSERT INTO `municipio` VALUES (597, 'Nemocón', 25);
INSERT INTO `municipio` VALUES (598, 'Nilo', 25);
INSERT INTO `municipio` VALUES (599, 'Nimaima', 25);
INSERT INTO `municipio` VALUES (600, 'Nobsa', 15);
INSERT INTO `municipio` VALUES (601, 'Nocaima', 25);
INSERT INTO `municipio` VALUES (602, 'Norcasia', 17);
INSERT INTO `municipio` VALUES (603, 'Norosí', 13);
INSERT INTO `municipio` VALUES (604, 'Novita', 27);
INSERT INTO `municipio` VALUES (605, 'Nueva Granada', 47);
INSERT INTO `municipio` VALUES (606, 'Nuevo Colón', 15);
INSERT INTO `municipio` VALUES (607, 'Nunchía', 85);
INSERT INTO `municipio` VALUES (608, 'Nuquí', 27);
INSERT INTO `municipio` VALUES (609, 'Nátaga', 41);
INSERT INTO `municipio` VALUES (610, 'Obando', 76);
INSERT INTO `municipio` VALUES (611, 'Ocamonte', 68);
INSERT INTO `municipio` VALUES (612, 'Ocaña', 54);
INSERT INTO `municipio` VALUES (613, 'Oiba', 68);
INSERT INTO `municipio` VALUES (614, 'Oicatá', 15);
INSERT INTO `municipio` VALUES (615, 'Olaya', 5);
INSERT INTO `municipio` VALUES (616, 'Olaya Herrera', 52);
INSERT INTO `municipio` VALUES (617, 'Onzaga', 68);
INSERT INTO `municipio` VALUES (618, 'Oporapa', 41);
INSERT INTO `municipio` VALUES (619, 'Orito', 86);
INSERT INTO `municipio` VALUES (620, 'Orocué', 85);
INSERT INTO `municipio` VALUES (621, 'Ortega', 73);
INSERT INTO `municipio` VALUES (622, 'Ospina', 52);
INSERT INTO `municipio` VALUES (623, 'Otanche', 15);
INSERT INTO `municipio` VALUES (624, 'Ovejas', 70);
INSERT INTO `municipio` VALUES (625, 'Pachavita', 15);
INSERT INTO `municipio` VALUES (626, 'Pacho', 25);
INSERT INTO `municipio` VALUES (627, 'Padilla', 19);
INSERT INTO `municipio` VALUES (628, 'Paicol', 41);
INSERT INTO `municipio` VALUES (629, 'Pailitas', 20);
INSERT INTO `municipio` VALUES (630, 'Paime', 25);
INSERT INTO `municipio` VALUES (631, 'Paipa', 15);
INSERT INTO `municipio` VALUES (632, 'Pajarito', 15);
INSERT INTO `municipio` VALUES (633, 'Palermo', 41);
INSERT INTO `municipio` VALUES (634, 'Palestina', 17);
INSERT INTO `municipio` VALUES (635, 'Palestina', 41);
INSERT INTO `municipio` VALUES (636, 'Palmar', 68);
INSERT INTO `municipio` VALUES (637, 'Palmar de Varela', 8);
INSERT INTO `municipio` VALUES (638, 'Palmas del Socorro', 68);
INSERT INTO `municipio` VALUES (639, 'Palmira', 76);
INSERT INTO `municipio` VALUES (640, 'Palmito', 70);
INSERT INTO `municipio` VALUES (641, 'Palocabildo', 73);
INSERT INTO `municipio` VALUES (642, 'Pamplona', 54);
INSERT INTO `municipio` VALUES (643, 'Pamplonita', 54);
INSERT INTO `municipio` VALUES (644, 'Pandi', 25);
INSERT INTO `municipio` VALUES (645, 'Panqueba', 15);
INSERT INTO `municipio` VALUES (646, 'Paratebueno', 25);
INSERT INTO `municipio` VALUES (647, 'Pasca', 25);
INSERT INTO `municipio` VALUES (648, 'Patía (El Bordo)', 19);
INSERT INTO `municipio` VALUES (649, 'Pauna', 15);
INSERT INTO `municipio` VALUES (650, 'Paya', 15);
INSERT INTO `municipio` VALUES (651, 'Paz de Ariporo', 85);
INSERT INTO `municipio` VALUES (652, 'Paz de Río', 15);
INSERT INTO `municipio` VALUES (653, 'Pedraza', 47);
INSERT INTO `municipio` VALUES (654, 'Pelaya', 20);
INSERT INTO `municipio` VALUES (655, 'Pensilvania', 17);
INSERT INTO `municipio` VALUES (656, 'Peque', 5);
INSERT INTO `municipio` VALUES (657, 'Pereira', 66);
INSERT INTO `municipio` VALUES (658, 'Pesca', 15);
INSERT INTO `municipio` VALUES (659, 'Peñol', 5);
INSERT INTO `municipio` VALUES (660, 'Piamonte', 19);
INSERT INTO `municipio` VALUES (661, 'Pie de Cuesta', 68);
INSERT INTO `municipio` VALUES (662, 'Piedras', 73);
INSERT INTO `municipio` VALUES (663, 'Piendamó', 19);
INSERT INTO `municipio` VALUES (664, 'Pijao', 63);
INSERT INTO `municipio` VALUES (665, 'Pijiño', 47);
INSERT INTO `municipio` VALUES (666, 'Pinchote', 68);
INSERT INTO `municipio` VALUES (667, 'Pinillos', 13);
INSERT INTO `municipio` VALUES (668, 'Piojo', 8);
INSERT INTO `municipio` VALUES (669, 'Pisva', 15);
INSERT INTO `municipio` VALUES (670, 'Pital', 41);
INSERT INTO `municipio` VALUES (671, 'Pitalito', 41);
INSERT INTO `municipio` VALUES (672, 'Pivijay', 47);
INSERT INTO `municipio` VALUES (673, 'Planadas', 73);
INSERT INTO `municipio` VALUES (674, 'Planeta Rica', 23);
INSERT INTO `municipio` VALUES (675, 'Plato', 47);
INSERT INTO `municipio` VALUES (676, 'Policarpa', 52);
INSERT INTO `municipio` VALUES (677, 'Polonuevo', 8);
INSERT INTO `municipio` VALUES (678, 'Ponedera', 8);
INSERT INTO `municipio` VALUES (679, 'Popayán', 19);
INSERT INTO `municipio` VALUES (680, 'Pore', 85);
INSERT INTO `municipio` VALUES (681, 'Potosí', 52);
INSERT INTO `municipio` VALUES (682, 'Pradera', 76);
INSERT INTO `municipio` VALUES (683, 'Prado', 73);
INSERT INTO `municipio` VALUES (684, 'Providencia', 52);
INSERT INTO `municipio` VALUES (685, 'Providencia', 88);
INSERT INTO `municipio` VALUES (686, 'Pueblo Bello', 20);
INSERT INTO `municipio` VALUES (687, 'Pueblo Nuevo', 23);
INSERT INTO `municipio` VALUES (688, 'Pueblo Rico', 66);
INSERT INTO `municipio` VALUES (689, 'Pueblorrico', 5);
INSERT INTO `municipio` VALUES (690, 'Puebloviejo', 47);
INSERT INTO `municipio` VALUES (691, 'Puente Nacional', 68);
INSERT INTO `municipio` VALUES (692, 'Puerres', 52);
INSERT INTO `municipio` VALUES (693, 'Puerto Asís', 86);
INSERT INTO `municipio` VALUES (694, 'Puerto Berrío', 5);
INSERT INTO `municipio` VALUES (695, 'Puerto Boyacá', 15);
INSERT INTO `municipio` VALUES (696, 'Puerto Caicedo', 86);
INSERT INTO `municipio` VALUES (697, 'Puerto Carreño', 99);
INSERT INTO `municipio` VALUES (698, 'Puerto Colombia', 8);
INSERT INTO `municipio` VALUES (699, 'Puerto Concordia', 50);
INSERT INTO `municipio` VALUES (700, 'Puerto Escondido', 23);
INSERT INTO `municipio` VALUES (701, 'Puerto Gaitán', 50);
INSERT INTO `municipio` VALUES (702, 'Puerto Guzmán', 86);
INSERT INTO `municipio` VALUES (703, 'Puerto Leguízamo', 86);
INSERT INTO `municipio` VALUES (704, 'Puerto Libertador', 23);
INSERT INTO `municipio` VALUES (705, 'Puerto Lleras', 50);
INSERT INTO `municipio` VALUES (706, 'Puerto López', 50);
INSERT INTO `municipio` VALUES (707, 'Puerto Nare', 5);
INSERT INTO `municipio` VALUES (708, 'Puerto Nariño', 91);
INSERT INTO `municipio` VALUES (709, 'Puerto Parra', 68);
INSERT INTO `municipio` VALUES (710, 'Puerto Rico', 18);
INSERT INTO `municipio` VALUES (711, 'Puerto Rico', 50);
INSERT INTO `municipio` VALUES (712, 'Puerto Rondón', 81);
INSERT INTO `municipio` VALUES (713, 'Puerto Salgar', 25);
INSERT INTO `municipio` VALUES (714, 'Puerto Santander', 54);
INSERT INTO `municipio` VALUES (715, 'Puerto Tejada', 19);
INSERT INTO `municipio` VALUES (716, 'Puerto Triunfo', 5);
INSERT INTO `municipio` VALUES (717, 'Puerto Wilches', 68);
INSERT INTO `municipio` VALUES (718, 'Pulí', 25);
INSERT INTO `municipio` VALUES (719, 'Pupiales', 52);
INSERT INTO `municipio` VALUES (720, 'Puracé (Coconuco)', 19);
INSERT INTO `municipio` VALUES (721, 'Purificación', 73);
INSERT INTO `municipio` VALUES (722, 'Purísima', 23);
INSERT INTO `municipio` VALUES (723, 'Pácora', 17);
INSERT INTO `municipio` VALUES (724, 'Páez', 15);
INSERT INTO `municipio` VALUES (725, 'Páez (Belalcazar)', 19);
INSERT INTO `municipio` VALUES (726, 'Páramo', 68);
INSERT INTO `municipio` VALUES (727, 'Quebradanegra', 25);
INSERT INTO `municipio` VALUES (728, 'Quetame', 25);
INSERT INTO `municipio` VALUES (729, 'Quibdó', 27);
INSERT INTO `municipio` VALUES (730, 'Quimbaya', 63);
INSERT INTO `municipio` VALUES (731, 'Quinchía', 66);
INSERT INTO `municipio` VALUES (732, 'Quipama', 15);
INSERT INTO `municipio` VALUES (733, 'Quipile', 25);
INSERT INTO `municipio` VALUES (734, 'Ragonvalia', 54);
INSERT INTO `municipio` VALUES (735, 'Ramiriquí', 15);
INSERT INTO `municipio` VALUES (736, 'Recetor', 85);
INSERT INTO `municipio` VALUES (737, 'Regidor', 13);
INSERT INTO `municipio` VALUES (738, 'Remedios', 5);
INSERT INTO `municipio` VALUES (739, 'Remolino', 47);
INSERT INTO `municipio` VALUES (740, 'Repelón', 8);
INSERT INTO `municipio` VALUES (741, 'Restrepo', 50);
INSERT INTO `municipio` VALUES (742, 'Restrepo', 76);
INSERT INTO `municipio` VALUES (743, 'Retiro', 5);
INSERT INTO `municipio` VALUES (744, 'Ricaurte', 25);
INSERT INTO `municipio` VALUES (745, 'Ricaurte', 52);
INSERT INTO `municipio` VALUES (746, 'Rio Negro', 68);
INSERT INTO `municipio` VALUES (747, 'Rioblanco', 73);
INSERT INTO `municipio` VALUES (748, 'Riofrío', 76);
INSERT INTO `municipio` VALUES (749, 'Riohacha', 44);
INSERT INTO `municipio` VALUES (750, 'Risaralda', 17);
INSERT INTO `municipio` VALUES (751, 'Rivera', 41);
INSERT INTO `municipio` VALUES (752, 'Roberto Payán (San José)', 52);
INSERT INTO `municipio` VALUES (753, 'Roldanillo', 76);
INSERT INTO `municipio` VALUES (754, 'Roncesvalles', 73);
INSERT INTO `municipio` VALUES (755, 'Rondón', 15);
INSERT INTO `municipio` VALUES (756, 'Rosas', 19);
INSERT INTO `municipio` VALUES (757, 'Rovira', 73);
INSERT INTO `municipio` VALUES (758, 'Ráquira', 15);
INSERT INTO `municipio` VALUES (759, 'Río Iró', 27);
INSERT INTO `municipio` VALUES (760, 'Río Quito', 27);
INSERT INTO `municipio` VALUES (761, 'Río Sucio', 17);
INSERT INTO `municipio` VALUES (762, 'Río Viejo', 13);
INSERT INTO `municipio` VALUES (763, 'Río de oro', 20);
INSERT INTO `municipio` VALUES (764, 'Ríonegro', 5);
INSERT INTO `municipio` VALUES (765, 'Ríosucio', 27);
INSERT INTO `municipio` VALUES (766, 'Sabana de Torres', 68);
INSERT INTO `municipio` VALUES (767, 'Sabanagrande', 8);
INSERT INTO `municipio` VALUES (768, 'Sabanalarga', 5);
INSERT INTO `municipio` VALUES (769, 'Sabanalarga', 8);
INSERT INTO `municipio` VALUES (770, 'Sabanalarga', 85);
INSERT INTO `municipio` VALUES (771, 'Sabanas de San Angel (SAN ANGEL)', 47);
INSERT INTO `municipio` VALUES (772, 'Sabaneta', 5);
INSERT INTO `municipio` VALUES (773, 'Saboyá', 15);
INSERT INTO `municipio` VALUES (774, 'Sahagún', 23);
INSERT INTO `municipio` VALUES (775, 'Saladoblanco', 41);
INSERT INTO `municipio` VALUES (776, 'Salamina', 17);
INSERT INTO `municipio` VALUES (777, 'Salamina', 47);
INSERT INTO `municipio` VALUES (778, 'Salazar', 54);
INSERT INTO `municipio` VALUES (779, 'Saldaña', 73);
INSERT INTO `municipio` VALUES (780, 'Salento', 63);
INSERT INTO `municipio` VALUES (781, 'Salgar', 5);
INSERT INTO `municipio` VALUES (782, 'Samacá', 15);
INSERT INTO `municipio` VALUES (783, 'Samaniego', 52);
INSERT INTO `municipio` VALUES (784, 'Samaná', 17);
INSERT INTO `municipio` VALUES (785, 'Sampués', 70);
INSERT INTO `municipio` VALUES (786, 'San Agustín', 41);
INSERT INTO `municipio` VALUES (787, 'San Alberto', 20);
INSERT INTO `municipio` VALUES (788, 'San Andrés', 68);
INSERT INTO `municipio` VALUES (789, 'San Andrés Sotavento', 23);
INSERT INTO `municipio` VALUES (790, 'San Andrés de Cuerquía', 5);
INSERT INTO `municipio` VALUES (791, 'San Antero', 23);
INSERT INTO `municipio` VALUES (792, 'San Antonio', 73);
INSERT INTO `municipio` VALUES (793, 'San Antonio de Tequendama', 25);
INSERT INTO `municipio` VALUES (794, 'San Benito', 68);
INSERT INTO `municipio` VALUES (795, 'San Benito Abad', 70);
INSERT INTO `municipio` VALUES (796, 'San Bernardo', 25);
INSERT INTO `municipio` VALUES (797, 'San Bernardo', 52);
INSERT INTO `municipio` VALUES (798, 'San Bernardo del Viento', 23);
INSERT INTO `municipio` VALUES (799, 'San Calixto', 54);
INSERT INTO `municipio` VALUES (800, 'San Carlos', 5);
INSERT INTO `municipio` VALUES (801, 'San Carlos', 23);
INSERT INTO `municipio` VALUES (802, 'San Carlos de Guaroa', 50);
INSERT INTO `municipio` VALUES (803, 'San Cayetano', 25);
INSERT INTO `municipio` VALUES (804, 'San Cayetano', 54);
INSERT INTO `municipio` VALUES (805, 'San Cristobal', 13);
INSERT INTO `municipio` VALUES (806, 'San Diego', 20);
INSERT INTO `municipio` VALUES (807, 'San Eduardo', 15);
INSERT INTO `municipio` VALUES (808, 'San Estanislao', 13);
INSERT INTO `municipio` VALUES (809, 'San Fernando', 13);
INSERT INTO `municipio` VALUES (810, 'San Francisco', 5);
INSERT INTO `municipio` VALUES (811, 'San Francisco', 25);
INSERT INTO `municipio` VALUES (812, 'San Francisco', 86);
INSERT INTO `municipio` VALUES (813, 'San Gíl', 68);
INSERT INTO `municipio` VALUES (814, 'San Jacinto', 13);
INSERT INTO `municipio` VALUES (815, 'San Jacinto del Cauca', 13);
INSERT INTO `municipio` VALUES (816, 'San Jerónimo', 5);
INSERT INTO `municipio` VALUES (817, 'San Joaquín', 68);
INSERT INTO `municipio` VALUES (818, 'San José', 17);
INSERT INTO `municipio` VALUES (819, 'San José de Miranda', 68);
INSERT INTO `municipio` VALUES (820, 'San José de Montaña', 5);
INSERT INTO `municipio` VALUES (821, 'San José de Pare', 15);
INSERT INTO `municipio` VALUES (822, 'San José de Uré', 23);
INSERT INTO `municipio` VALUES (823, 'San José del Fragua', 18);
INSERT INTO `municipio` VALUES (824, 'San José del Guaviare', 95);
INSERT INTO `municipio` VALUES (825, 'San José del Palmar', 27);
INSERT INTO `municipio` VALUES (826, 'San Juan de Arama', 50);
INSERT INTO `municipio` VALUES (827, 'San Juan de Betulia', 70);
INSERT INTO `municipio` VALUES (828, 'San Juan de Nepomuceno', 13);
INSERT INTO `municipio` VALUES (829, 'San Juan de Pasto', 52);
INSERT INTO `municipio` VALUES (830, 'San Juan de Río Seco', 25);
INSERT INTO `municipio` VALUES (831, 'San Juan de Urabá', 5);
INSERT INTO `municipio` VALUES (832, 'San Juan del Cesar', 44);
INSERT INTO `municipio` VALUES (833, 'San Juanito', 50);
INSERT INTO `municipio` VALUES (834, 'San Lorenzo', 52);
INSERT INTO `municipio` VALUES (835, 'San Luis', 73);
INSERT INTO `municipio` VALUES (836, 'San Luís', 5);
INSERT INTO `municipio` VALUES (837, 'San Luís de Gaceno', 15);
INSERT INTO `municipio` VALUES (838, 'San Luís de Palenque', 85);
INSERT INTO `municipio` VALUES (839, 'San Marcos', 70);
INSERT INTO `municipio` VALUES (840, 'San Martín', 20);
INSERT INTO `municipio` VALUES (841, 'San Martín', 50);
INSERT INTO `municipio` VALUES (842, 'San Martín de Loba', 13);
INSERT INTO `municipio` VALUES (843, 'San Mateo', 15);
INSERT INTO `municipio` VALUES (844, 'San Miguel', 68);
INSERT INTO `municipio` VALUES (845, 'San Miguel', 86);
INSERT INTO `municipio` VALUES (846, 'San Miguel de Sema', 15);
INSERT INTO `municipio` VALUES (847, 'San Onofre', 70);
INSERT INTO `municipio` VALUES (848, 'San Pablo', 13);
INSERT INTO `municipio` VALUES (849, 'San Pablo', 52);
INSERT INTO `municipio` VALUES (850, 'San Pablo de Borbur', 15);
INSERT INTO `municipio` VALUES (851, 'San Pedro', 5);
INSERT INTO `municipio` VALUES (852, 'San Pedro', 70);
INSERT INTO `municipio` VALUES (853, 'San Pedro', 76);
INSERT INTO `municipio` VALUES (854, 'San Pedro de Cartago', 52);
INSERT INTO `municipio` VALUES (855, 'San Pedro de Urabá', 5);
INSERT INTO `municipio` VALUES (856, 'San Pelayo', 23);
INSERT INTO `municipio` VALUES (857, 'San Rafael', 5);
INSERT INTO `municipio` VALUES (858, 'San Roque', 5);
INSERT INTO `municipio` VALUES (859, 'San Sebastián', 19);
INSERT INTO `municipio` VALUES (860, 'San Sebastián de Buenavista', 47);
INSERT INTO `municipio` VALUES (861, 'San Vicente', 5);
INSERT INTO `municipio` VALUES (862, 'San Vicente del Caguán', 18);
INSERT INTO `municipio` VALUES (863, 'San Vicente del Chucurí', 68);
INSERT INTO `municipio` VALUES (864, 'San Zenón', 47);
INSERT INTO `municipio` VALUES (865, 'Sandoná', 52);
INSERT INTO `municipio` VALUES (866, 'Santa Ana', 47);
INSERT INTO `municipio` VALUES (867, 'Santa Bárbara', 5);
INSERT INTO `municipio` VALUES (868, 'Santa Bárbara', 68);
INSERT INTO `municipio` VALUES (869, 'Santa Bárbara (Iscuandé)', 52);
INSERT INTO `municipio` VALUES (870, 'Santa Bárbara de Pinto', 47);
INSERT INTO `municipio` VALUES (871, 'Santa Catalina', 13);
INSERT INTO `municipio` VALUES (872, 'Santa Fé de Antioquia', 5);
INSERT INTO `municipio` VALUES (873, 'Santa Genoveva de Docorodó', 27);
INSERT INTO `municipio` VALUES (874, 'Santa Helena del Opón', 68);
INSERT INTO `municipio` VALUES (875, 'Santa Isabel', 73);
INSERT INTO `municipio` VALUES (876, 'Santa Lucía', 8);
INSERT INTO `municipio` VALUES (877, 'Santa Marta', 47);
INSERT INTO `municipio` VALUES (878, 'Santa María', 15);
INSERT INTO `municipio` VALUES (879, 'Santa María', 41);
INSERT INTO `municipio` VALUES (880, 'Santa Rosa', 13);
INSERT INTO `municipio` VALUES (881, 'Santa Rosa', 19);
INSERT INTO `municipio` VALUES (882, 'Santa Rosa de Cabal', 66);
INSERT INTO `municipio` VALUES (883, 'Santa Rosa de Osos', 5);
INSERT INTO `municipio` VALUES (884, 'Santa Rosa de Viterbo', 15);
INSERT INTO `municipio` VALUES (885, 'Santa Rosa del Sur', 13);
INSERT INTO `municipio` VALUES (886, 'Santa Rosalía', 99);
INSERT INTO `municipio` VALUES (887, 'Santa Sofía', 15);
INSERT INTO `municipio` VALUES (888, 'Santana', 15);
INSERT INTO `municipio` VALUES (889, 'Santander de Quilichao', 19);
INSERT INTO `municipio` VALUES (890, 'Santiago', 54);
INSERT INTO `municipio` VALUES (891, 'Santiago', 86);
INSERT INTO `municipio` VALUES (892, 'Santo Domingo', 5);
INSERT INTO `municipio` VALUES (893, 'Santo Tomás', 8);
INSERT INTO `municipio` VALUES (894, 'Santuario', 5);
INSERT INTO `municipio` VALUES (895, 'Santuario', 66);
INSERT INTO `municipio` VALUES (896, 'Sapuyes', 52);
INSERT INTO `municipio` VALUES (897, 'Saravena', 81);
INSERT INTO `municipio` VALUES (898, 'Sardinata', 54);
INSERT INTO `municipio` VALUES (899, 'Sasaima', 25);
INSERT INTO `municipio` VALUES (900, 'Sativanorte', 15);
INSERT INTO `municipio` VALUES (901, 'Sativasur', 15);
INSERT INTO `municipio` VALUES (902, 'Segovia', 5);
INSERT INTO `municipio` VALUES (903, 'Sesquilé', 25);
INSERT INTO `municipio` VALUES (904, 'Sevilla', 76);
INSERT INTO `municipio` VALUES (905, 'Siachoque', 15);
INSERT INTO `municipio` VALUES (906, 'Sibaté', 25);
INSERT INTO `municipio` VALUES (907, 'Sibundoy', 86);
INSERT INTO `municipio` VALUES (908, 'Silos', 54);
INSERT INTO `municipio` VALUES (909, 'Silvania', 25);
INSERT INTO `municipio` VALUES (910, 'Silvia', 19);
INSERT INTO `municipio` VALUES (911, 'Simacota', 68);
INSERT INTO `municipio` VALUES (912, 'Simijaca', 25);
INSERT INTO `municipio` VALUES (913, 'Simití', 13);
INSERT INTO `municipio` VALUES (914, 'Sincelejo', 70);
INSERT INTO `municipio` VALUES (915, 'Sincé', 70);
INSERT INTO `municipio` VALUES (916, 'Sipí', 27);
INSERT INTO `municipio` VALUES (917, 'Sitionuevo', 47);
INSERT INTO `municipio` VALUES (918, 'Soacha', 25);
INSERT INTO `municipio` VALUES (919, 'Soatá', 15);
INSERT INTO `municipio` VALUES (920, 'Socha', 15);
INSERT INTO `municipio` VALUES (921, 'Socorro', 68);
INSERT INTO `municipio` VALUES (922, 'Socotá', 15);
INSERT INTO `municipio` VALUES (923, 'Sogamoso', 15);
INSERT INTO `municipio` VALUES (924, 'Solano', 18);
INSERT INTO `municipio` VALUES (925, 'Soledad', 8);
INSERT INTO `municipio` VALUES (926, 'Solita', 18);
INSERT INTO `municipio` VALUES (927, 'Somondoco', 15);
INSERT INTO `municipio` VALUES (928, 'Sonsón', 5);
INSERT INTO `municipio` VALUES (929, 'Sopetrán', 5);
INSERT INTO `municipio` VALUES (930, 'Soplaviento', 13);
INSERT INTO `municipio` VALUES (931, 'Sopó', 25);
INSERT INTO `municipio` VALUES (932, 'Sora', 15);
INSERT INTO `municipio` VALUES (933, 'Soracá', 15);
INSERT INTO `municipio` VALUES (934, 'Sotaquirá', 15);
INSERT INTO `municipio` VALUES (935, 'Sotara (Paispamba)', 19);
INSERT INTO `municipio` VALUES (936, 'Sotomayor (Los Andes)', 52);
INSERT INTO `municipio` VALUES (937, 'Suaita', 68);
INSERT INTO `municipio` VALUES (938, 'Suan', 8);
INSERT INTO `municipio` VALUES (939, 'Suaza', 41);
INSERT INTO `municipio` VALUES (940, 'Subachoque', 25);
INSERT INTO `municipio` VALUES (941, 'Sucre', 19);
INSERT INTO `municipio` VALUES (942, 'Sucre', 68);
INSERT INTO `municipio` VALUES (943, 'Sucre', 70);
INSERT INTO `municipio` VALUES (944, 'Suesca', 25);
INSERT INTO `municipio` VALUES (945, 'Supatá', 25);
INSERT INTO `municipio` VALUES (946, 'Supía', 17);
INSERT INTO `municipio` VALUES (947, 'Suratá', 68);
INSERT INTO `municipio` VALUES (948, 'Susa', 25);
INSERT INTO `municipio` VALUES (949, 'Susacón', 15);
INSERT INTO `municipio` VALUES (950, 'Sutamarchán', 15);
INSERT INTO `municipio` VALUES (951, 'Sutatausa', 25);
INSERT INTO `municipio` VALUES (952, 'Sutatenza', 15);
INSERT INTO `municipio` VALUES (953, 'Suárez', 19);
INSERT INTO `municipio` VALUES (954, 'Suárez', 73);
INSERT INTO `municipio` VALUES (955, 'Sácama', 85);
INSERT INTO `municipio` VALUES (956, 'Sáchica', 15);
INSERT INTO `municipio` VALUES (957, 'Tabio', 25);
INSERT INTO `municipio` VALUES (958, 'Tadó', 27);
INSERT INTO `municipio` VALUES (959, 'Talaigua Nuevo', 13);
INSERT INTO `municipio` VALUES (960, 'Tamalameque', 20);
INSERT INTO `municipio` VALUES (961, 'Tame', 81);
INSERT INTO `municipio` VALUES (962, 'Taminango', 52);
INSERT INTO `municipio` VALUES (963, 'Tangua', 52);
INSERT INTO `municipio` VALUES (964, 'Taraira', 97);
INSERT INTO `municipio` VALUES (965, 'Tarazá', 5);
INSERT INTO `municipio` VALUES (966, 'Tarqui', 41);
INSERT INTO `municipio` VALUES (967, 'Tarso', 5);
INSERT INTO `municipio` VALUES (968, 'Tasco', 15);
INSERT INTO `municipio` VALUES (969, 'Tauramena', 85);
INSERT INTO `municipio` VALUES (970, 'Tausa', 25);
INSERT INTO `municipio` VALUES (971, 'Tello', 41);
INSERT INTO `municipio` VALUES (972, 'Tena', 25);
INSERT INTO `municipio` VALUES (973, 'Tenerife', 47);
INSERT INTO `municipio` VALUES (974, 'Tenjo', 25);
INSERT INTO `municipio` VALUES (975, 'Tenza', 15);
INSERT INTO `municipio` VALUES (976, 'Teorama', 54);
INSERT INTO `municipio` VALUES (977, 'Teruel', 41);
INSERT INTO `municipio` VALUES (978, 'Tesalia', 41);
INSERT INTO `municipio` VALUES (979, 'Tibacuy', 25);
INSERT INTO `municipio` VALUES (980, 'Tibaná', 15);
INSERT INTO `municipio` VALUES (981, 'Tibasosa', 15);
INSERT INTO `municipio` VALUES (982, 'Tibirita', 25);
INSERT INTO `municipio` VALUES (983, 'Tibú', 54);
INSERT INTO `municipio` VALUES (984, 'Tierralta', 23);
INSERT INTO `municipio` VALUES (985, 'Timaná', 41);
INSERT INTO `municipio` VALUES (986, 'Timbiquí', 19);
INSERT INTO `municipio` VALUES (987, 'Timbío', 19);
INSERT INTO `municipio` VALUES (988, 'Tinjacá', 15);
INSERT INTO `municipio` VALUES (989, 'Tipacoque', 15);
INSERT INTO `municipio` VALUES (990, 'Tiquisio (Puerto Rico)', 13);
INSERT INTO `municipio` VALUES (991, 'Titiribí', 5);
INSERT INTO `municipio` VALUES (992, 'Toca', 15);
INSERT INTO `municipio` VALUES (993, 'Tocaima', 25);
INSERT INTO `municipio` VALUES (994, 'Tocancipá', 25);
INSERT INTO `municipio` VALUES (995, 'Toguí', 15);
INSERT INTO `municipio` VALUES (996, 'Toledo', 5);
INSERT INTO `municipio` VALUES (997, 'Toledo', 54);
INSERT INTO `municipio` VALUES (998, 'Tolú', 70);
INSERT INTO `municipio` VALUES (999, 'Tolú Viejo', 70);
INSERT INTO `municipio` VALUES (1000, 'Tona', 68);
INSERT INTO `municipio` VALUES (1001, 'Topagá', 15);
INSERT INTO `municipio` VALUES (1002, 'Topaipí', 25);
INSERT INTO `municipio` VALUES (1003, 'Toribío', 19);
INSERT INTO `municipio` VALUES (1004, 'Toro', 76);
INSERT INTO `municipio` VALUES (1005, 'Tota', 15);
INSERT INTO `municipio` VALUES (1006, 'Totoró', 19);
INSERT INTO `municipio` VALUES (1007, 'Trinidad', 85);
INSERT INTO `municipio` VALUES (1008, 'Trujillo', 76);
INSERT INTO `municipio` VALUES (1009, 'Tubará', 8);
INSERT INTO `municipio` VALUES (1010, 'Tuchín', 23);
INSERT INTO `municipio` VALUES (1011, 'Tulúa', 76);
INSERT INTO `municipio` VALUES (1012, 'Tumaco', 52);
INSERT INTO `municipio` VALUES (1013, 'Tunja', 15);
INSERT INTO `municipio` VALUES (1014, 'Tunungua', 15);
INSERT INTO `municipio` VALUES (1015, 'Turbaco', 13);
INSERT INTO `municipio` VALUES (1016, 'Turbaná', 13);
INSERT INTO `municipio` VALUES (1017, 'Turbo', 5);
INSERT INTO `municipio` VALUES (1018, 'Turmequé', 15);
INSERT INTO `municipio` VALUES (1019, 'Tuta', 15);
INSERT INTO `municipio` VALUES (1020, 'Tutasá', 15);
INSERT INTO `municipio` VALUES (1021, 'Támara', 85);
INSERT INTO `municipio` VALUES (1022, 'Támesis', 5);
INSERT INTO `municipio` VALUES (1023, 'Túquerres', 52);
INSERT INTO `municipio` VALUES (1024, 'Ubalá', 25);
INSERT INTO `municipio` VALUES (1025, 'Ubaque', 25);
INSERT INTO `municipio` VALUES (1026, 'Ubaté', 25);
INSERT INTO `municipio` VALUES (1027, 'Ulloa', 76);
INSERT INTO `municipio` VALUES (1028, 'Une', 25);
INSERT INTO `municipio` VALUES (1029, 'Unguía', 27);
INSERT INTO `municipio` VALUES (1030, 'Unión Panamericana (ÁNIMAS)', 27);
INSERT INTO `municipio` VALUES (1031, 'Uramita', 5);
INSERT INTO `municipio` VALUES (1032, 'Uribe', 50);
INSERT INTO `municipio` VALUES (1033, 'Uribia', 44);
INSERT INTO `municipio` VALUES (1034, 'Urrao', 5);
INSERT INTO `municipio` VALUES (1035, 'Urumita', 44);
INSERT INTO `municipio` VALUES (1036, 'Usiacuri', 8);
INSERT INTO `municipio` VALUES (1037, 'Valdivia', 5);
INSERT INTO `municipio` VALUES (1038, 'Valencia', 23);
INSERT INTO `municipio` VALUES (1039, 'Valle de San José', 68);
INSERT INTO `municipio` VALUES (1040, 'Valle de San Juan', 73);
INSERT INTO `municipio` VALUES (1041, 'Valle del Guamuez', 86);
INSERT INTO `municipio` VALUES (1042, 'Valledupar', 20);
INSERT INTO `municipio` VALUES (1043, 'Valparaiso', 5);
INSERT INTO `municipio` VALUES (1044, 'Valparaiso', 18);
INSERT INTO `municipio` VALUES (1045, 'Vegachí', 5);
INSERT INTO `municipio` VALUES (1046, 'Venadillo', 73);
INSERT INTO `municipio` VALUES (1047, 'Venecia', 5);
INSERT INTO `municipio` VALUES (1048, 'Venecia (Ospina Pérez)', 25);
INSERT INTO `municipio` VALUES (1049, 'Ventaquemada', 15);
INSERT INTO `municipio` VALUES (1050, 'Vergara', 25);
INSERT INTO `municipio` VALUES (1051, 'Versalles', 76);
INSERT INTO `municipio` VALUES (1052, 'Vetas', 68);
INSERT INTO `municipio` VALUES (1053, 'Viani', 25);
INSERT INTO `municipio` VALUES (1054, 'Vigía del Fuerte', 5);
INSERT INTO `municipio` VALUES (1055, 'Vijes', 76);
INSERT INTO `municipio` VALUES (1056, 'Villa Caro', 54);
INSERT INTO `municipio` VALUES (1057, 'Villa Rica', 19);
INSERT INTO `municipio` VALUES (1058, 'Villa de Leiva', 15);
INSERT INTO `municipio` VALUES (1059, 'Villa del Rosario', 54);
INSERT INTO `municipio` VALUES (1060, 'Villagarzón', 86);
INSERT INTO `municipio` VALUES (1061, 'Villagómez', 25);
INSERT INTO `municipio` VALUES (1062, 'Villahermosa', 73);
INSERT INTO `municipio` VALUES (1063, 'Villamaría', 17);
INSERT INTO `municipio` VALUES (1064, 'Villanueva', 13);
INSERT INTO `municipio` VALUES (1065, 'Villanueva', 44);
INSERT INTO `municipio` VALUES (1066, 'Villanueva', 68);
INSERT INTO `municipio` VALUES (1067, 'Villanueva', 85);
INSERT INTO `municipio` VALUES (1068, 'Villapinzón', 25);
INSERT INTO `municipio` VALUES (1069, 'Villarrica', 73);
INSERT INTO `municipio` VALUES (1070, 'Villavicencio', 50);
INSERT INTO `municipio` VALUES (1071, 'Villavieja', 41);
INSERT INTO `municipio` VALUES (1072, 'Villeta', 25);
INSERT INTO `municipio` VALUES (1073, 'Viotá', 25);
INSERT INTO `municipio` VALUES (1074, 'Viracachá', 15);
INSERT INTO `municipio` VALUES (1075, 'Vista Hermosa', 50);
INSERT INTO `municipio` VALUES (1076, 'Viterbo', 17);
INSERT INTO `municipio` VALUES (1077, 'Vélez', 68);
INSERT INTO `municipio` VALUES (1078, 'Yacopí', 25);
INSERT INTO `municipio` VALUES (1079, 'Yacuanquer', 52);
INSERT INTO `municipio` VALUES (1080, 'Yaguará', 41);
INSERT INTO `municipio` VALUES (1081, 'Yalí', 5);
INSERT INTO `municipio` VALUES (1082, 'Yarumal', 5);
INSERT INTO `municipio` VALUES (1083, 'Yolombó', 5);
INSERT INTO `municipio` VALUES (1084, 'Yondó (Casabe)', 5);
INSERT INTO `municipio` VALUES (1085, 'Yopal', 85);
INSERT INTO `municipio` VALUES (1086, 'Yotoco', 76);
INSERT INTO `municipio` VALUES (1087, 'Yumbo', 76);
INSERT INTO `municipio` VALUES (1088, 'Zambrano', 13);
INSERT INTO `municipio` VALUES (1089, 'Zapatoca', 68);
INSERT INTO `municipio` VALUES (1090, 'Zapayán (PUNTA DE PIEDRAS)', 47);
INSERT INTO `municipio` VALUES (1091, 'Zaragoza', 5);
INSERT INTO `municipio` VALUES (1092, 'Zarzal', 76);
INSERT INTO `municipio` VALUES (1093, 'Zetaquirá', 15);
INSERT INTO `municipio` VALUES (1094, 'Zipacón', 25);
INSERT INTO `municipio` VALUES (1095, 'Zipaquirá', 25);
INSERT INTO `municipio` VALUES (1096, 'Zona Bananera (PRADO - SEVILLA)', 47);
INSERT INTO `municipio` VALUES (1097, 'Ábrego', 54);
INSERT INTO `municipio` VALUES (1098, 'Íquira', 41);
INSERT INTO `municipio` VALUES (1099, 'Úmbita', 15);
INSERT INTO `municipio` VALUES (1100, 'Útica', 25);

-- ----------------------------
-- Table structure for nivel
-- ----------------------------
DROP TABLE IF EXISTS `nivel`;
CREATE TABLE `nivel`  (
  `id_nivel` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_nivel` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_nivel` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_nivel` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_nivel`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of nivel
-- ----------------------------
INSERT INTO `nivel` VALUES (1, 'Basico', 'nn', 'Y');

-- ----------------------------
-- Table structure for pais
-- ----------------------------
DROP TABLE IF EXISTS `pais`;
CREATE TABLE `pais`  (
  `id_pais` int(10) NOT NULL,
  `nombre_pais` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_pais`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pais
-- ----------------------------
INSERT INTO `pais` VALUES (57, 'Colombia');

-- ----------------------------
-- Table structure for permiso
-- ----------------------------
DROP TABLE IF EXISTS `permiso`;
CREATE TABLE `permiso`  (
  `id_permiso` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_permiso` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `accion_permiso` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `controlador_permiso` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_permiso`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of permiso
-- ----------------------------
INSERT INTO `permiso` VALUES (1, 'Prueba', 'nn1', 'nn2');

-- ----------------------------
-- Table structure for persona
-- ----------------------------
DROP TABLE IF EXISTS `persona`;
CREATE TABLE `persona`  (
  `id_persona` int(10) NOT NULL,
  `nombre1_persona` varchar(30) CHARACTER SET utf8mb4  NOT NULL,
  `nombre2_persona` varchar(30) CHARACTER SET utf8mb4  NULL DEFAULT NULL,
  `apellido1_persona` varchar(30) CHARACTER SET utf8mb4  NOT NULL,
  `apellido2_persona` varchar(30) CHARACTER SET utf8mb4  NOT NULL,
  `fecha_nac_persona` date NOT NULL,
  `num_tel_persona` varchar(20) CHARACTER SET utf8mb4  NOT NULL,
  `email_persona` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `Tipo_Docid_tipo_documento` int(10) NOT NULL,
  `Tipo_Pobid_tipo_poblacion` int(10) NOT NULL,
  PRIMARY KEY (`id_persona`) USING BTREE,
  INDEX `FKPersona215047`(`Tipo_Pobid_tipo_poblacion`) USING BTREE,
  INDEX `FKPersona54846`(`Tipo_Docid_tipo_documento`) USING BTREE,
  CONSTRAINT `FKPersona215047` FOREIGN KEY (`Tipo_Pobid_tipo_poblacion`) REFERENCES `tipo_pob` (`id_tipo_poblacion`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKPersona54846` FOREIGN KEY (`Tipo_Docid_tipo_documento`) REFERENCES `tipo_doc` (`id_tipo_documento`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of persona
-- ----------------------------
INSERT INTO `persona` VALUES (1117528719, 'Diego', 'Hernan', 'Aguilar', 'Gomez', '1993-09-10', '3102664694', 'di.aguilar@udla.edu.co', 1, 1);

-- ----------------------------
-- Table structure for pregunta
-- ----------------------------
DROP TABLE IF EXISTS `pregunta`;
CREATE TABLE `pregunta`  (
  `id_pregunta` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_pregunta` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `contenido_pregunta` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_pregunta` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Examenid_examen` int(10) NOT NULL,
  `Tipo_Preguntaid_tipo_pregunta` int(10) NOT NULL,
  PRIMARY KEY (`id_pregunta`) USING BTREE,
  INDEX `FKPregunta825413`(`Examenid_examen`) USING BTREE,
  INDEX `FKPregunta991969`(`Tipo_Preguntaid_tipo_pregunta`) USING BTREE,
  CONSTRAINT `FKPregunta825413` FOREIGN KEY (`Examenid_examen`) REFERENCES `examen` (`id_examen`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKPregunta991969` FOREIGN KEY (`Tipo_Preguntaid_tipo_pregunta`) REFERENCES `tipo_pregunta` (`id_tipo_pregunta`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of pregunta
-- ----------------------------
INSERT INTO `pregunta` VALUES (1, 'p1', 'El Verbo To be es ', 'Y', 1, 1);

-- ----------------------------
-- Table structure for respuesta
-- ----------------------------
DROP TABLE IF EXISTS `respuesta`;
CREATE TABLE `respuesta`  (
  `id_respuesta` int(10) NOT NULL AUTO_INCREMENT,
  `contenido_respuesta` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_respuesta` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `condicion_respuesta` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Preguntaid_pregunta` int(10) NOT NULL,
  PRIMARY KEY (`id_respuesta`) USING BTREE,
  INDEX `FKRespuesta991375`(`Preguntaid_pregunta`) USING BTREE,
  CONSTRAINT `FKRespuesta991375` FOREIGN KEY (`Preguntaid_pregunta`) REFERENCES `pregunta` (`id_pregunta`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of respuesta
-- ----------------------------
INSERT INTO `respuesta` VALUES (1, 'una opcion', 'Y', 'N', 1);
INSERT INTO `respuesta` VALUES (2, 'Primer tema de la unicad', 'Y', 'Y', 1);
INSERT INTO `respuesta` VALUES (3, 'opcion 2', 'Y', 'N', 1);

-- ----------------------------
-- Table structure for rol
-- ----------------------------
DROP TABLE IF EXISTS `rol`;
CREATE TABLE `rol`  (
  `id_rol` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_rol` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_rol` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_rol`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of rol
-- ----------------------------
INSERT INTO `rol` VALUES (1, 'Administrador', 'nn');
INSERT INTO `rol` VALUES (2, 'Coordinador Academico', 'nn');
INSERT INTO `rol` VALUES (3, 'Tutor', 'nn');
INSERT INTO `rol` VALUES (4, 'Estudiante', 'nn');
INSERT INTO `rol` VALUES (5, 'Independiente Profesional', 'nn');
INSERT INTO `rol` VALUES (6, 'Independiente Infantil', 'nn');
INSERT INTO `rol` VALUES (7, 'Docente', 'nn');

-- ----------------------------
-- Table structure for rol_permiso
-- ----------------------------
DROP TABLE IF EXISTS `rol_permiso`;
CREATE TABLE `rol_permiso`  (
  `Rolid_rol` int(10) NOT NULL,
  `Permisoid_permiso` int(10) NOT NULL,
  `estado_rol_permiso` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`Rolid_rol`, `Permisoid_permiso`) USING BTREE,
  INDEX `FKRol_Permis979785`(`Permisoid_permiso`) USING BTREE,
  CONSTRAINT `FKRol_Permis399315` FOREIGN KEY (`Rolid_rol`) REFERENCES `rol` (`id_rol`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKRol_Permis979785` FOREIGN KEY (`Permisoid_permiso`) REFERENCES `permiso` (`id_permiso`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of rol_permiso
-- ----------------------------
INSERT INTO `rol_permiso` VALUES (2, 1, 'Y');

-- ----------------------------
-- Table structure for rol_usuario
-- ----------------------------
DROP TABLE IF EXISTS `rol_usuario`;
CREATE TABLE `rol_usuario`  (
  `Rolid_rol` int(10) NOT NULL,
  `Usuarioid_usuario` int(10) NOT NULL,
  `fecha_activacion_rol_usuario` date NOT NULL,
  PRIMARY KEY (`Rolid_rol`, `Usuarioid_usuario`) USING BTREE,
  INDEX `FKRol_Usuari142277`(`Usuarioid_usuario`) USING BTREE,
  CONSTRAINT `FKRol_Usuari142277` FOREIGN KEY (`Usuarioid_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKRol_Usuari180494` FOREIGN KEY (`Rolid_rol`) REFERENCES `rol` (`id_rol`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of rol_usuario
-- ----------------------------
INSERT INTO `rol_usuario` VALUES (3, 1, '2019-07-19');

-- ----------------------------
-- Table structure for seccion
-- ----------------------------
DROP TABLE IF EXISTS `seccion`;
CREATE TABLE `seccion`  (
  `id_seccion` int(10) NOT NULL AUTO_INCREMENT,
  `titulo_seccion` varchar(255) CHARACTER SET utf8mb4  NULL DEFAULT NULL,
  `contenido_seccion` varchar(2000) CHARACTER SET utf8mb4  NULL DEFAULT NULL,
  `estado_seccion` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Actividadid_actividad` int(10) NOT NULL,
  PRIMARY KEY (`id_seccion`) USING BTREE,
  INDEX `FKSeccion378840`(`Actividadid_actividad`) USING BTREE,
  CONSTRAINT `FKSeccion378840` FOREIGN KEY (`Actividadid_actividad`) REFERENCES `actividad` (`id_actividad`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of seccion
-- ----------------------------
INSERT INTO `seccion` VALUES (1, '', '', 'Y', 1);
INSERT INTO `seccion` VALUES (2, 'Examples:', 'I live in Florencia                        yo vivo en Florencia \r\nYou work in a bank                    tú trabajas en un banco / usted trabaja en un banco\r\nHe is tall                                       él es alto\r\nShe is a secretary                       ella es una secretaria\r\nIt is raining                                  está lloviendo\r\nWe are in the same team         nosotros estamos en el mismo equipo\r\nThey eat every day                     ellos comen todos los días \r\n', 'Y', 1);
INSERT INTO `seccion` VALUES (3, '', '', 'Y', 2);
INSERT INTO `seccion` VALUES (4, 'Examples', 'Give the letter to me.                                                   Dame la carta.\r\nThe police wants to talk to you.                                 El policía quiere hablarte. \r\nJuan took him to work Wednesday.                          Juan lo llevó a trabajar el miércoles. \r\nGerónimo bought lunch for her.                                Gerónimo compró el almuerzo para ella.\r\nShe have it.                                                                    Ella lo tiene.  \r\nThey always play soccer with us.                               Ellos siempre juegan futbol con nosotros\r\nYou have to sing with them.                                       Tú tienes que cantar con ellos.\r\n', 'Y', 2);
INSERT INTO `seccion` VALUES (5, '', '', 'Y', 3);
INSERT INTO `seccion` VALUES (6, 'Examples', 'Juana is a friend of mine.                                  Juana es una amiga mía.\r\nThese are not yours.                                          Estos no son tuyos. \r\nThis is his house.                                                 Esta es su casa. \r\nThis is her coat.                                                   Este es su abrigo.\r\nTheir school is bigger tan ours.                        Su escuela es mas grande como la mía.   	\r\nThe car is theirs.                                                 El carro es de ellos.\r\n', 'Y', 3);
INSERT INTO `seccion` VALUES (7, '', '', 'Y', 4);
INSERT INTO `seccion` VALUES (8, 'Examples', 'I painted the house myself.                                       Pinté la casa yo mismo.\r\nYou cut yourself with a knife.                                   Te cortaste con un cuchillo.\r\nHe cooked a chicken himself                                     Él mismo cocino un pollo.\r\nShe hurt herself                                                           Ella se lastimó. \r\nThe stereo has broken by itself                                 El estéreo se ha roto por sí mismo. \r\nWe can do it ourselves                                               Podemos hacerlo nosotros mismos. \r\nThey had to cook for themselves                            Tuvieron que cocinar por ellos mismos.\r\nTo see oneself in the mirror.                                     Verse en el espejo. \r\n', 'Y', 4);
INSERT INTO `seccion` VALUES (9, '', '', 'Y', 5);
INSERT INTO `seccion` VALUES (10, 'Affirmatives Examples', 'Formula: subject + verb to be + complement \r\nI am a dentist                                            Yo soy un dentista\r\nYou are in the university                        Tú estás en la universidad\r\nHe’s an archaeologist                             Él es arqueólogo. \r\nShe is a lawyer                                          Ella es una abogada\r\nIt is under the table                                  Esta debajo de la mesa\r\nWe’re playing baseball                          Nosotros estamos jugando beisbol \r\nThey are electricians                               Ello son electricistas \r\n', 'Y', 5);
INSERT INTO `seccion` VALUES (11, 'Negative Examples:', 'Formula: subject + verb to be + not + complement\r\nI´m not an economist                         Yo no soy un economista\r\nYou are not in the house                   Tú no estás en la casa\r\nHe is not a Farmer                             Él no es un granjero\r\nShe’s not doing the work                 Ella no está haciendo el trabajo.\r\nIt’s not cloudy                                    No esta nublado\r\nWe are not neighbors                       No somos vecinos. \r\nThey’re not painters                          Ellos no son pintores. \r\n', 'Y', 5);
INSERT INTO `seccion` VALUES (12, 'Interrogative Examples', 'Formula: verb to be + subject + complement \r\nAm i at home?                                 ¿estoy en casa? \r\nAre you a teacher?                         ¿eres profesor?\r\nIs he my cousin?                             ¿él es mi primo?\r\nIs she a housewife?                        ¿ella es ama de casa? \r\nIs it for animals?                              ¿es para animales?\r\nAre we Friends?                               ¿somos amigos?\r\nAre they dating?                             ¿Ellos están saliendo?\r\n', 'Y', 5);

-- ----------------------------
-- Table structure for tematica_curso
-- ----------------------------
DROP TABLE IF EXISTS `tematica_curso`;
CREATE TABLE `tematica_curso`  (
  `id_tematica_curso` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tematica_curso` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tematica_curso` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tematica_curso`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tematica_curso
-- ----------------------------
INSERT INTO `tematica_curso` VALUES (1, 'Idiomas', 'nn');
INSERT INTO `tematica_curso` VALUES (2, 'Ciencias Basicas', 'nn');

-- ----------------------------
-- Table structure for tipo_actividad
-- ----------------------------
DROP TABLE IF EXISTS `tipo_actividad`;
CREATE TABLE `tipo_actividad`  (
  `id_tipo_actividad` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_actividad` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_actividad` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_actividad`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_actividad
-- ----------------------------
INSERT INTO `tipo_actividad` VALUES (1, 'Teorico', 'nn');

-- ----------------------------
-- Table structure for tipo_contrato
-- ----------------------------
DROP TABLE IF EXISTS `tipo_contrato`;
CREATE TABLE `tipo_contrato`  (
  `id_tipo_contrato` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_contrato` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_contrato` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_contrato`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_contrato
-- ----------------------------
INSERT INTO `tipo_contrato` VALUES (1, 'Prestacion de Servicos', 'nn');

-- ----------------------------
-- Table structure for tipo_doc
-- ----------------------------
DROP TABLE IF EXISTS `tipo_doc`;
CREATE TABLE `tipo_doc`  (
  `id_tipo_documento` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_documento` varchar(50) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_documento` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_documento`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_doc
-- ----------------------------
INSERT INTO `tipo_doc` VALUES (1, 'Cedula de Ciudadania', 'nn');

-- ----------------------------
-- Table structure for tipo_empresa
-- ----------------------------
DROP TABLE IF EXISTS `tipo_empresa`;
CREATE TABLE `tipo_empresa`  (
  `id_tipo_empresa` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_empresa` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_empresa` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_empresa`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_empresa
-- ----------------------------
INSERT INTO `tipo_empresa` VALUES (1, 'Publica', 'nn');
INSERT INTO `tipo_empresa` VALUES (2, 'Privada', 'nn');

-- ----------------------------
-- Table structure for tipo_examen
-- ----------------------------
DROP TABLE IF EXISTS `tipo_examen`;
CREATE TABLE `tipo_examen`  (
  `id_tipo_examen` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_examen` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_examen` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_examen`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_examen
-- ----------------------------
INSERT INTO `tipo_examen` VALUES (1, 'Quiz', 'Examen Corto');
INSERT INTO `tipo_examen` VALUES (2, 'Examen Final', 'Final Unidad');

-- ----------------------------
-- Table structure for tipo_multimedia
-- ----------------------------
DROP TABLE IF EXISTS `tipo_multimedia`;
CREATE TABLE `tipo_multimedia`  (
  `id_tipo_multimedia` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_multimedia` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_multimedia` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_multimedia`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_multimedia
-- ----------------------------
INSERT INTO `tipo_multimedia` VALUES (1, 'Video', 'nn');
INSERT INTO `tipo_multimedia` VALUES (2, 'Imagen', 'nn');
INSERT INTO `tipo_multimedia` VALUES (3, 'Texto', 'nn');
INSERT INTO `tipo_multimedia` VALUES (4, 'Audio', 'nn');
INSERT INTO `tipo_multimedia` VALUES (5, 'Animacion', 'nn');

-- ----------------------------
-- Table structure for tipo_pob
-- ----------------------------
DROP TABLE IF EXISTS `tipo_pob`;
CREATE TABLE `tipo_pob`  (
  `id_tipo_poblacion` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_poblacion` varchar(30) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_poblacion` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_poblacion`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_pob
-- ----------------------------
INSERT INTO `tipo_pob` VALUES (1, 'Ninguno', 'nn');

-- ----------------------------
-- Table structure for tipo_pregunta
-- ----------------------------
DROP TABLE IF EXISTS `tipo_pregunta`;
CREATE TABLE `tipo_pregunta`  (
  `id_tipo_pregunta` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_pregunta` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_tipo_pregunta` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`id_tipo_pregunta`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipo_pregunta
-- ----------------------------
INSERT INTO `tipo_pregunta` VALUES (1, 'Completar', 'nn');

-- ----------------------------
-- Table structure for unidad
-- ----------------------------
DROP TABLE IF EXISTS `unidad`;
CREATE TABLE `unidad`  (
  `id_unidad` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_unidad` varchar(100) CHARACTER SET utf8mb4  NOT NULL,
  `descripcion_unidad` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `estado_unidad` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `Curso_nivelid_curso_nivel` int(10) NOT NULL,
  PRIMARY KEY (`id_unidad`) USING BTREE,
  INDEX `FKUnidad392068`(`Curso_nivelid_curso_nivel`) USING BTREE,
  CONSTRAINT `FKUnidad392068` FOREIGN KEY (`Curso_nivelid_curso_nivel`) REFERENCES `curso_nivel` (`Id_curso_nivel`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of unidad
-- ----------------------------
INSERT INTO `unidad` VALUES (1, 'Pronombres', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (2, 'Verbo', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (3, 'Articulos', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (4, 'Preposiciones', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (5, 'Vocabulario', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (6, 'Vocabulario basico', 'nn', 'Y', 4);
INSERT INTO `unidad` VALUES (7, 'Numeros,fechas y hora', 'nn', 'Y', 4);

-- ----------------------------
-- Table structure for unidad_examen
-- ----------------------------
DROP TABLE IF EXISTS `unidad_examen`;
CREATE TABLE `unidad_examen`  (
  `Unidadid_unidad` int(10) NOT NULL,
  `Examenid_examen` int(10) NOT NULL,
  `estado_unidad_examen` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  PRIMARY KEY (`Unidadid_unidad`, `Examenid_examen`) USING BTREE,
  INDEX `FKUnidad_Exa72059`(`Examenid_examen`) USING BTREE,
  CONSTRAINT `FKUnidad_Exa66686` FOREIGN KEY (`Unidadid_unidad`) REFERENCES `unidad` (`id_unidad`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKUnidad_Exa72059` FOREIGN KEY (`Examenid_examen`) REFERENCES `examen` (`id_examen`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of unidad_examen
-- ----------------------------
INSERT INTO `unidad_examen` VALUES (1, 1, 'Y');

-- ----------------------------
-- Table structure for usuario
-- ----------------------------
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario`  (
  `id_usuario` int(10) NOT NULL AUTO_INCREMENT,
  `nombre_usuario` varchar(15) CHARACTER SET utf8mb4  NOT NULL,
  `contraseña_usuario` varchar(10) CHARACTER SET utf8mb4  NOT NULL,
  `estado_usuario` enum('Y','N') CHARACTER SET utf8mb4  NOT NULL,
  `PersonaId_Persona` int(10) NOT NULL,
  PRIMARY KEY (`id_usuario`) USING BTREE,
  INDEX `FKUsuario377896`(`PersonaId_Persona`) USING BTREE,
  CONSTRAINT `FKUsuario377896` FOREIGN KEY (`PersonaId_Persona`) REFERENCES `persona` (`id_persona`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of usuario
-- ----------------------------
INSERT INTO `usuario` VALUES (1, 'Dorioga', 'root', 'Y', 1117528719);

-- ----------------------------
-- Table structure for usuario_pregunta
-- ----------------------------
DROP TABLE IF EXISTS `usuario_pregunta`;
CREATE TABLE `usuario_pregunta`  (
  `Usuarioid_usuario` int(10) NOT NULL,
  `Preguntaid_pregunta` int(10) NOT NULL,
  `opcion_respuesta_usuario_pregunta` int(10) NOT NULL,
  `fecha_realizacion` date NOT NULL,
  PRIMARY KEY (`Usuarioid_usuario`, `Preguntaid_pregunta`) USING BTREE,
  INDEX `FKUsuario_Pr292990`(`Preguntaid_pregunta`) USING BTREE,
  CONSTRAINT `FKUsuario_Pr292990` FOREIGN KEY (`Preguntaid_pregunta`) REFERENCES `pregunta` (`id_pregunta`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FKUsuario_Pr801918` FOREIGN KEY (`Usuarioid_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4  ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of usuario_pregunta
-- ----------------------------
INSERT INTO `usuario_pregunta` VALUES (1, 1, 1, '2019-07-24');

-- ----------------------------
-- Procedure structure for Pr_cargar_actividad
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_actividad`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_actividad`(IN `id_unidad` int)
BEGIN
SELECT
actividad.id_actividad AS id_actividad,
actividad.nombre_actividad AS nombre_actividad,
actividad.num_seccion_actividad AS numero_secciones,
seccion.id_seccion AS id_seccion,
seccion.titulo_seccion AS Seccion,
seccion.contenido_seccion AS Contenido_seccion,
multimedia.id_multimedia AS id_multimedia,
multimedia.nombre_multimedia AS nombre_multimedia,
multimedia.url_multimedia AS url,
clasificacion.nombre_clasificacion AS Clasificacion
FROM
actividad
INNER JOIN seccion ON seccion.Actividadid_actividad = actividad.id_actividad
INNER JOIN multimedia ON multimedia.Seccionid_seccion = seccion.id_seccion
INNER JOIN clasificacion ON multimedia.Clasificacionid_clasificacion = clasificacion.id_clasificacion
WHERE
actividad.id_actividad = 1 AND
actividad.estado_actividad = 'Y'
ORDER BY
id_seccion ASC ;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_cargar_contenido
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_contenido`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_contenido`(IN id_actividad INT)
BEGIN
SELECT
actividad.id_actividad,
actividad.nombre_actividad,
actividad.descripcion_actividad,
seccion.id_seccion,
seccion.titulo_seccion,
seccion.contenido_seccion,
multimedia.id_multimedia,
multimedia.url_multimedia

FROM
actividad
INNER JOIN seccion ON seccion.Actividadid_actividad = actividad.id_actividad
INNER JOIN multimedia ON multimedia.Seccionid_seccion = seccion.id_seccion
WHERE
actividad.id_actividad= id_actividad  AND seccion.estado_seccion = 'Y' AND
multimedia.estado_multimedia = 'Y' AND
actividad.estado_actividad = 'Y';

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_cargar_curso
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_curso`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_curso`(IN `documento` int)
BEGIN
	SELECT
curso.nombre_curso AS Nombre_Curso,
curso.id_curso AS Id_curso
FROM
curso_usuario
INNER JOIN curso ON curso_usuario.Cursoid_curso = curso.id_curso
WHERE
curso_usuario.Usuarioid_usuario =  documento AND
curso_usuario.estado_usuario_curso = 'Y';


END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_cargar_nivel
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_nivel`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_nivel`(IN `id_curso` int)
BEGIN
SELECT
nivel.id_nivel as id_nivel,
nivel.nombre_nivel AS Nombre_Nivel,
curso_nivel.fecha_inicio_curso_nivel AS Fecha_Inicio
FROM
nivel
INNER JOIN curso_nivel ON curso_nivel.Nivelid_nivel = nivel.id_nivel
WHERE
curso_nivel.Cursoid_curso = id_curso and nivel.estado_nivel='Y';

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_cargar_permiso
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_permiso`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_permiso`(IN `id_rol` int)
BEGIN
SELECT
permiso.id_permiso AS Permiso,
permiso.nombre_permiso AS Nombre_permiso
FROM
rol_permiso
INNER JOIN permiso ON rol_permiso.Permisoid_permiso = permiso.id_permiso
WHERE
rol_permiso.estado_rol_permiso = 1 AND
rol_permiso.Rolid_rol =id_rol;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_cargar_unidad
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_cargar_unidad`;
delimiter ;;
CREATE PROCEDURE `Pr_cargar_unidad`(IN `id_nivel` int)
BEGIN
	SELECT
unidad.id_unidad AS Id_unidad,
unidad.nombre_unidad AS Nombre_unidad
FROM
unidad
WHERE
unidad.Nivelid_nivel = id_nivel AND
unidad.estado_unidad = 'Y';

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Pr_iniciar_sesion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pr_iniciar_sesion`;
delimiter ;;
CREATE PROCEDURE `Pr_iniciar_sesion`(IN us varchar(50), passw varchar(50))
BEGIN

SELECT p.id_persona, concat(p.nombre1_persona,' ' ,p.apellido1_persona) as nombre, r.id_rol, r.nombre_rol from usuario as u 
inner join persona as p on (u.PersonaId_Persona=p.id_persona) 
inner join rol_usuario as ru on (ru.Usuarioid_usuario=u.id_usuario)
inner join rol as r on (r.id_rol=ru.Rolid_rol)
where (u.contraseña_usuario= passw   and u.nombre_usuario=us );

END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
