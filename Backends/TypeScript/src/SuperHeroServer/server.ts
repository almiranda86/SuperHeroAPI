/** source/server.ts */
import http from 'http';
import express, { Express } from 'express';
import morgan from 'morgan';
import routes from '../SuperHeroRoutes/routes';
import { createConnection } from 'typeorm';
import DatabaseConfiguration from "../SuperHeroRepository/Configuration/DatabaseConfiguration";


const PORT = process.env.PORT || 6060;

const router: Express = express();

/** Logging */
router.use(morgan('dev'));
/** Parse the request */
router.use(express.urlencoded({ extended: false }));
/** Takes care of JSON data */
router.use(express.json());

/** RULES OF OUR API */
router.use((req, res, next) => {
    // set the CORS policy
    res.header('Access-Control-Allow-Origin', '*');
    // set the CORS headers
    res.header('Access-Control-Allow-Headers', 'origin, X-Requested-With,Content-Type,Accept, Authorization');
    // set the CORS method headers
    if (req.method === 'OPTIONS') {
        res.header('Access-Control-Allow-Methods', 'GET PATCH DELETE POST');
        return res.status(200).json({});
    }
    next();
});

/** Routes */
router.use('/', routes);

/** Error handling */
router.use((req, res, next) => {
    const error = new Error('not found');
    return res.status(404).json({
        message: error.message
    });
});


createConnection(DatabaseConfiguration).then(_connection => {
    router.listen(PORT, () => {
     /** Server */
     console.log("Server is running on port", PORT);
    });
  }).catch(err => {
    console.log("Unable to connect to db", err);
    process.exit(1)
  })